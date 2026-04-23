using ExamContext.ReadModel.Queries.Contracts.UserContext.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.UserContext
{
    public interface IUserSpecificationQueryFacade
    {
        IList<UserSpecificationQueryFacadeDto> GetUserSpecification(ref DataTableAjaxPostModel filters);
    }
}
