using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingQuestionAggregate;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingQuestionAggregate.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Facade.ReadingContext.ReadingQuestionAggregate
{
    public class ReadingQuestionTypeQueryFacade : IReadingQuestionTypeQueryFacade
    {
        public IEnumerable<ReadingQuestionTypeQueryFacadeDto> GetReadingQuestionTypeList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ReadingQuestionTypes.Where(a => a.IsActive == true && a.IsDeleted == false)
                            select new ReadingQuestionTypeQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                CodeName = i.CodeName,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted
                            }).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public ReadingQuestionTypeQueryFacadeDto GetReadingQuestionType(Guid readingQuestionTypeId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ReadingQuestionTypes.Where(a => a.IsActive == true && a.IsDeleted == false && a.Id == readingQuestionTypeId)
                            select new ReadingQuestionTypeQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                CodeName = i.CodeName,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted
                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
