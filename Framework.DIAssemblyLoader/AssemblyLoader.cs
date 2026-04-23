using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DIAssemblyLoader
{
    public class AssemblyLoader
    {
        private static List<Assembly> loadedAssemblies;
        private readonly string assemblyHeader;

        public AssemblyLoader(string nameSpace)
        {
            assemblyHeader = nameSpace;
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            var x = Directory.GetFiles(directory, assemblyHeader + "*.dll", SearchOption.AllDirectories);
            loadedAssemblies = x.Select(Assembly.LoadFrom).ToList();
        }

        private IList<Assembly> GetAllAssemblies()
        {
            var resault = loadedAssemblies.Where(a => a.FullName.Contains(assemblyHeader)).ToList();
            return resault;
        }

        public static IEnumerable<T> DiscoverInstances<T>()
        {
            return
                loadedAssemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsClass && !t.IsAbstract)
                .Where(t => t.GetInterface(typeof(T).Name) != null)
                .Select(Activator.CreateInstance)
                .OfType<T>();
        }

        public IList<Assembly> GetAssemblies(Type HasType)
        {
            var BaseClassName = HasType.Name;

            var resault = GetAllAssemblies();
            return GetAllAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(a => a.BaseType != null && a.BaseType.Name == BaseClassName)
                .Select(a => a.Assembly)
                .ToList();
        }


        public IList<Type> GetTypes(Type BaseType)
        {
            var BaseClassName = BaseType.Name;

            return GetAllAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(a => a.BaseType != null && a.BaseType.Name == BaseClassName && a.IsClass && !a.IsAbstract)
                .ToList();
        }


        public IList<Type> GetClassByInterface(Type baseInterFace)
        {
            var baseClassName = baseInterFace.Name;

            var result = GetAllAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(a => a.GetInterfaces().Any(b => b.Name == baseClassName) && a.IsClass && !a.IsAbstract)
                .ToList();

            return result;
        }


        public IList<object> GetInstanceByInterface(Type baseInterFace)
        {
            try
            {
                var baseClassName = baseInterFace.Name;

                var a = GetAllAssemblies();
                var b = a.SelectMany(a => a.GetTypes());
                var c = b.Where(a => a.GetInterfaces().Any(b => b.Name == baseClassName));
                var d = c.Distinct();
                var e = d.Select(Activator.CreateInstance);
                return e.ToList();
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
