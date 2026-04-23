using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningQuestionAggregate;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningQuestionAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.ListeningContext.ListeningQuestionAggregate
{
    public class ListeningQuestionAnswersQueryFacade : IListeningQuestionAnswersQueryFacade
    {
        public IEnumerable<ListeningQuestionAnswersQueryFacadeDto> GetListeningQuestionAnswerListForGridView(ref DataTableAjaxPostModel filters, Guid id)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                    var data = (from i in context.ListeningQuestionAnswers.Where(a => a.ListeningQuestionId == id && a.IsDeleted == false)
                                select new ListeningQuestionAnswersQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    Title = i.Title,
                                    Description = i.Description,
                                    OrderNo = i.OrderNo,
                                    IsCorrect = (bool)i.IsCorrect,
                                    IsActive = i.IsActive,
                                    IsDeleted = i.IsDeleted,
                                    ListeningQuestionId = i.ListeningQuestionId
                                });

                    var Result = data.Where(v =>
                                (titleSerach_ByName == null ||
                                (titleSerach_ByName != null && (v.Title.Contains(titleSerach_ByName.ToString()))))).AsQueryable();

                    filters.filteredResultsCount = Result.Count();

                    var sort = (filters.order != null ? filters.columns[filters.order[0].column].data : "") + " " + (filters.order != null ? filters.order[0].dir.ToLower() : "");

                    Result = Result.OrderBy(sort).Skip(filters.start).Take(filters.length);
                    return Result.ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public ListeningQuestionAnswersQueryFacadeDto GetListeningQuestionAnswers(Guid listeningQuestionAnswersId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ListeningQuestionAnswers.Where(a => a.Id == listeningQuestionAnswersId)
                            select new ListeningQuestionAnswersQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                OrderNo = i.OrderNo,
                                IsCorrect = (bool)i.IsCorrect,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                ListeningQuestionId=i.ListeningQuestionId
                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<ListeningQuestionAnswersQueryFacadeDto> GetListeningQuestionAnswersList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ListeningQuestionAnswers.Where(a => a.IsActive == true &&
                            a.IsDeleted == false )
                            select new ListeningQuestionAnswersQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                OrderNo = i.OrderNo,
                                IsCorrect = (bool)i.IsCorrect,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                ListeningQuestionId=i.ListeningQuestionId
                            }).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
