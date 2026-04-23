using ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingExamAggregate.DataContracts;
using Framework.Facade;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.WritingContext.WritingExamAggregate
{
    public interface IWritingExamSectionQueryFacade:IQueryFacade
    {
        IEnumerable<WritingExamSectionQueryFacadeDto> GetWritingExamSectionList();
        WritingExamSectionQueryFacadeDto GetWritingExamSectionById(Guid writingExamSectionId);
        IEnumerable<WritingExamSectionQueryFacadeDto> GetWritingExamSectionListForGridView(ref DataTableAjaxPostModel filters, Guid id);
        IEnumerable<WritingExamSectionQueryFacadeDto> GetWritingExamSectionListForUserPanel(Guid writingExamId);
        IEnumerable<WrtingExamUserAnswersPerSectionQueryFacade> GetWrtingExamUserAnswersPerSectionByExamId(Guid? id, Guid customerId);
    }
}
