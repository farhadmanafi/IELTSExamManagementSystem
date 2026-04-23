using ExamContext.ReadModel.Queries.Contracts.GeneralContext.UserPanelMenuAggregate.DataContracts;
using Framework.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.GeneralContext.UserPanelMenuAggregate
{
    public interface IUserPanelMenuQueryFacade : IQueryFacade
    {
        IEnumerable<UserPanelMenuQueryFacadeDto> GetMenusHeaderTop();
        IEnumerable<UserPanelMenuQueryFacadeDto> GetMenusHeaderBottom();
    }
}
