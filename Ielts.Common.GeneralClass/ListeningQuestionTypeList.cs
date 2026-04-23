using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ielts.Common.GeneralClass
{
    public static class ListeningQuestionTypeList
    {
        public readonly static Guid CheckBox = new Guid("C1C652D2-80DA-46A4-A63A-1BDD29FAD711");
        public readonly static Guid RadioButton = new Guid("741A7F3B-E914-4F00-8FBF-24785BFF4472");
        public readonly static Guid ComboBox = new Guid("299B95ED-B613-4472-9C81-2A5F06DB99A4");
        public readonly static Guid TextArea = new Guid("C08AF043-4135-4613-9C51-6483B956AC90");
        public readonly static Guid TextBox = new Guid("DAF826AD-1924-4CD8-96C0-72D9CD64F83C");
    }
}
