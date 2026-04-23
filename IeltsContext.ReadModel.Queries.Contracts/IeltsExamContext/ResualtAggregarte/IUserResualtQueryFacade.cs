using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ResualtAggregarte.DataContracts;
using Framework.Facade;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ResualtAggregarte
{
    public interface IUserResualtQueryFacade:IQueryFacade
    {
        IEnumerable<UserExamResultListQueryFacade> GetUserExamResultFilteringList(ref DataTableAjaxPostModel filters, Guid customerId, Guid ieltsExamParticipantsId);
        IeltsExamUserResultQueryFacadeDto GetUserExamResult(Guid examId, Guid customerId);
    }
}
