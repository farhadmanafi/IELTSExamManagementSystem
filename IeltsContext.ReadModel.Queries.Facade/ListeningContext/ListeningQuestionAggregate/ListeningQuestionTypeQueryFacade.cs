using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningQuestionAggregate;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningQuestionAggregate.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Facade.ListeningContext.ListeningQuestionAggregate
{
    public class ListeningQuestionTypeQueryFacade : IListeningQuestionTypeQueryFacade
    {
        public IEnumerable<ListeningQuestionTypeQueryFacadeDto> GetListeningQuestionTypeListQueryFacade()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ListeningQuestionTypes.Where(a => a.IsActive == true && a.IsDeleted == false)
                            select new ListeningQuestionTypeQueryFacadeDto()
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

        public ListeningQuestionTypeQueryFacadeDto GetListeningQuestionTypeQueryFacade(Guid listeningQuestionTypeId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ListeningQuestionTypes.Where(a => a.IsActive == true && a.IsDeleted == false && a.Id == listeningQuestionTypeId)
                            select new ListeningQuestionTypeQueryFacadeDto()
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
