using ExamContext.ReadModel.Queries.Contracts.GeneralContext.MenuAggregate.DataContracts;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.GeneralContext.MenuAggregate
{
    public interface IMenuQueryFacade : IQueryFacade
    {
        IEnumerable<MenuQueryFacadeDto> GetMenus();
    }
}
