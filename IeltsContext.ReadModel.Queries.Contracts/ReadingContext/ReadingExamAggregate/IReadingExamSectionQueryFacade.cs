using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingExamAggregate.DataContracts;
using Framework.Facade;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingExamAggregate
{
    public interface IReadingExamSectionQueryFacade:IQueryFacade
    {
        IEnumerable<ReadingExamSectionQueryFacadeDto> GetReadingExamSectionList();
        IEnumerable<ReadingExamSectionQueryFacadeDto> GetReadingExamSectionListByReadingExamId(Guid readingExamId);
        IEnumerable<ReadingExamSectionQueryFacadeDto> GetReadingExamSectionListForGridView(ref DataTableAjaxPostModel filters, Guid id);
        ReadingExamSectionQueryFacadeDto GetReadingExamSection(Guid readingExamSectionId);
    }
}
