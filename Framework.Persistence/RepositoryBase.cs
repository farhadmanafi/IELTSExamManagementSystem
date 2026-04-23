using Framework.Core.Domain;
using Framework.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Persistence
{
    public abstract class RepositoryBase<TAggregateRoot>
        where TAggregateRoot : EntityBase, IAggregateRoot<TAggregateRoot>, new()
    {
        protected readonly DbContextBase context;

        protected RepositoryBase(IDbContext context)
        {
            //this.context = context as DbContextBase;
            this.context = (DbContextBase)context;

        }
        protected DbSet<TAggregateRoot> Set
        {
            get
            {
                return context.Set<TAggregateRoot>();
            }
        }
        //protected virtual IQueryable<TAggregateRoot> Set
        //{
        //    get
        //    {
        //        var set = context.Set<TAggregateRoot>().AsQueryable();
        //        var includeExpressions = new TAggregateRoot().GetAggregateExpressions();
        //        foreach (var expression in includeExpressions)
        //        {
        //            if (expression != null)
        //                set.Include(expression).Load();
        //        }
        //        return set;
        //    }
        //}
        //protected void Create(TAggregateRoot aggregateRoot)
        //{
        //    context.Set<TAggregateRoot>().Add(aggregateRoot);
        //}


        //protected void Update(TAggregateRoot aggregateRoot)
        //{
        //    context.Entry(aggregateRoot).State = EntityState.Modified;
        //}


        //protected void Delete(TAggregateRoot aggregateRoot)
        //{
        //    context.Set<TAggregateRoot>().Remove(aggregateRoot);
        //}
        protected IQueryable<TAggregateRoot> SetForQuery
        {
            get
            {
                var setForQuery = context.Set<TAggregateRoot>().AsQueryable();
                var includeExpressions = new TAggregateRoot().GetAggregateExpressions();
                return includeExpressions == null ? setForQuery : includeExpressions
                    .Aggregate(setForQuery, (current, expression) => current.Include(expression));
            }
            //get
            //{
            //    var setForQuery = context.Set<TAggregateRoot>().AsQueryable();
            //    var includeExpressions = new TAggregateRoot().GetAggregateExpressions();
            //    return includeExpressions == null ? setForQuery : includeExpressions.Aggregate(setForQuery, (current, expression) => current.Include(expression));
            //}
        }

        protected TAggregateRoot GetById(Guid id)
        {

            return SetForQuery.Single(c => c.Id == id);
        }

    }
}
