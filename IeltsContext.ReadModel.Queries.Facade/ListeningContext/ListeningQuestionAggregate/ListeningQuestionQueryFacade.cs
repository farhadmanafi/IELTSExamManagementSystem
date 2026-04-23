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
using Framework.Mapper;

namespace ExamContext.ReadModel.Queries.Facade.ListeningContext.ListeningQuestionAggregate
{
    public class ListeningQuestionQueryFacade : IListeningQuestionQueryFacade
    {
        public IEnumerable<ListeningQuestionQueryFacadeDto> GetListeningQuestionListForGridView(ref DataTableAjaxPostModel filters, Guid id)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                    var data = (from i in context.ListeningQuestions.Where(a => a.ListeningExamId == id && a.IsDeleted == false)
                                let ListeningQuestionType = (from lt in context.ListeningQuestionTypes where i.ListeningQuestionTypeId == lt.Id select lt).FirstOrDefault()
                                select new ListeningQuestionQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    Title = i.Title,
                                    Description = i.Description,
                                    OrderNo = i.OrderNo,
                                    IsActive = i.IsActive,
                                    IsDeleted = i.IsDeleted,
                                    Score=i.Score,
                                    ListeningExamId = i.ListeningExamId,
                                    ListeningExamSectionId = i.ListeningExamSectionId,
                                    ListeningExamQuestionBlockId = i.ListeningExamQuestionBlockId,
                                    ListeningQuestionTypeId =i.ListeningQuestionTypeId,
                                    ListeningQuestionTypeTitle= ListeningQuestionType.Title,
                                    ListeningQuestionTypeCodeName = ListeningQuestionType.CodeName
                                });

                    var Result = data.Where(v =>
                                (titleSerach_ByName == null ||
                                (titleSerach_ByName != null && (v.Title.Contains(titleSerach_ByName.ToString()) ||
                                                                      v.Description.Contains(titleSerach_ByName.ToString()))
                                                                      ))).AsQueryable();

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

        public ListeningQuestionQueryFacadeDto GetListeningQuestion(Guid listeningQuestionId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ListeningQuestions.Where(a => a.Id == listeningQuestionId)
                            select new ListeningQuestionQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                OrderNo = i.OrderNo,
                                Score = i.Score,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                ListeningExamId = i.ListeningExamId,
                                ListeningExamSectionId = i.ListeningExamSectionId,
                                ListeningExamQuestionBlockId = i.ListeningExamQuestionBlockId,
                                ListeningQuestionTypeId =i.ListeningQuestionTypeId,
                                ListeningQuestionTypeTitle = i.ListeningQuestionType.Title//,
                                //listeningQuestionAnswersQueryFacadeDtos = (List<ListeningQuestionAnswersQueryFacadeDto>)i.ListeningQuestionAnswers

                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<ListeningQuestionQueryFacadeDto> GetListeningQuestionList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ListeningQuestions.Where(a => a.IsActive == true && a.IsDeleted == false)
                            select new ListeningQuestionQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                OrderNo = i.OrderNo,
                                Score = i.Score,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                ListeningExamId = i.ListeningExamId,
                                ListeningExamSectionId = i.ListeningExamSectionId,
                                ListeningExamQuestionBlockId = i.ListeningExamQuestionBlockId,
                                ListeningQuestionTypeId = i.ListeningQuestionTypeId,
                                ListeningQuestionTypeTitle = i.ListeningQuestionType.Title

                            }).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<ListeningQuestionQueryFacadeDto> GetListeningQuestionUserPanelList(Guid listeningExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ListeningQuestions.Where(a => a.IsDeleted == false && a.ListeningExamId == listeningExamId)
                            let listeningQuestionType = (from us in context.ListeningQuestionTypes where i.ListeningQuestionTypeId == us.Id select us).FirstOrDefault()
                            let listeningExamSection = (from se in context.ListeningExamSections where i.ListeningExamSectionId == se.Id select se).FirstOrDefault()
                            let listeningExamQuestionBlock = (from bl in context.ListeningExamQuestionBlocks where i.ListeningExamQuestionBlockId == bl.Id select bl).FirstOrDefault()
                            select new ListeningQuestionQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                OrderNo = i.OrderNo,
                                ListeningExamId = i.ListeningExamId,
                                ListeningExamSectionId = listeningExamSection.Id,
                                ListeningExamSectionOrderNo = listeningExamSection.OrderNo,
                                ListeningExamSectionTitle = listeningExamSection.Title,
                                ListeningExamQuestionBlockId = listeningExamQuestionBlock.Id,
                                ListeningExamQuestionBlockOrderNo = listeningExamQuestionBlock.OrderNo,
                                ListeningExamQuestionBlockTitle = listeningExamQuestionBlock.Title,
                                ListeningExamQuestionBlockDescription = listeningExamQuestionBlock.Description,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                ListeningQuestionTypeId = i.ListeningQuestionTypeId,
                                ListeningQuestionTypeTitle = listeningQuestionType.Title,
                                ListeningQuestionTypeCodeName = listeningQuestionType.CodeName,
                                ListeningQuestionAnswers = (List<ListeningQuestionAnswersQueryFacadeDto>)Mapper.Map<ListeningQuestionAnswer, ListeningQuestionAnswersQueryFacadeDto>(i.ListeningQuestionAnswers.OrderBy(a => a.OrderNo))
                            }).OrderBy(a => a.OrderNo).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

    }
}
