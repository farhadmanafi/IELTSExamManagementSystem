using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingQuestionAggregate;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingQuestionAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Framework.Mapper;

namespace ExamContext.ReadModel.Queries.Facade.ReadingContext.ReadingQuestionAggregate
{
    public class ReadingQuestionQueryFacade : IReadingQuestionQueryFacade
    {
        public ReadingQuestionQueryFacadeDto GetReadingQuestion(Guid readingQuestionId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ReadingQuestions.Where(a => a.IsDeleted == false && a.Id == readingQuestionId)
                            select new ReadingQuestionQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                OrderNo = i.OrderNo,
                                Score = i.Score,
                                ReadingExamId=i.ReadingExamId,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                ReadingQuestionTypeId = i.ReadingQuestionTypeId,
                                ReadingExamSectionId = i.ReadingExamSectionId,
                                ReadingExamQuestionBlockId = i.ReadingExamQuestionBlockId,
                                ReadingQuestionTypeTitle = i.ReadingQuestionType.Title
                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<ReadingQuestionQueryFacadeDto> GetReadingQuestionList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ReadingQuestions.Where(a => a.IsDeleted == false)
                            select new ReadingQuestionQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                OrderNo = i.OrderNo,
                                Score = i.Score,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                ReadingQuestionTypeId = i.ReadingQuestionTypeId,
                                ReadingExamSectionId = i.ReadingExamSectionId,
                                ReadingExamQuestionBlockId = i.ReadingExamQuestionBlockId,
                                ReadingQuestionTypeTitle = i.ReadingQuestionType.Title
                            }).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<ReadingQuestionQueryFacadeDto> GetReadingQuestionListForGridView(ref DataTableAjaxPostModel filters, Guid id)
        {
            try
            {
                var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.ReadingQuestions.Where(a => a.ReadingExamId == id && a.IsDeleted == false)
                                let ReadingQuestionType = (from rt in context.ReadingQuestionTypes where i.ReadingQuestionTypeId == rt.Id select rt).FirstOrDefault()
                                select new ReadingQuestionQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                OrderNo = i.OrderNo,
                                Score = i.Score,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                ReadingQuestionTypeId = i.ReadingQuestionTypeId,
                                ReadingExamSectionId = i.ReadingExamSectionId,
                                ReadingExamQuestionBlockId = i.ReadingExamQuestionBlockId,
                                ReadingQuestionTypeTitle = ReadingQuestionType.Title,
                                ReadingQuestionTypeCodeName= ReadingQuestionType.CodeName
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

        public IEnumerable<ReadingQuestionQueryFacadeDto> GetReadingQuestionUserPanelList(Guid readingExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ReadingQuestions.Where(a => a.IsDeleted == false && a.ReadingExamId == readingExamId)
                            let ReadingQuestionType = (from us in context.ReadingQuestionTypes where i.ReadingQuestionTypeId == us.Id select us).FirstOrDefault()
                            let ReadingExamSection = (from se in context.ReadingExamSections where i.ReadingExamSectionId == se.Id select se).FirstOrDefault()
                            let ReadingExamQuestionBlock = (from bl in context.ReadingExamQuestionBlocks where i.ReadingExamQuestionBlockId == bl.Id select bl).FirstOrDefault()
                            select new ReadingQuestionQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                OrderNo = i.OrderNo,
                                ReadingExamId = i.ReadingExamId,
                                ReadingExamSectionId = ReadingExamSection.Id,
                                ReadingExamSectionOrderNo = ReadingExamSection.OrderNo,
                                ReadingExamSectionTitle = ReadingExamSection.Title,
                                ReadingExamSectionReadingText = ReadingExamSection.ReadingText,
                                ReadingExamQuestionBlockId = ReadingExamQuestionBlock.Id,
                                ReadingExamQuestionBlockOrderNo = ReadingExamQuestionBlock.OrderNo,
                                ReadingExamQuestionBlockTitle = ReadingExamQuestionBlock.Title,
                                ReadingExamQuestionBlockDescription = ReadingExamQuestionBlock.Description,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                ReadingQuestionTypeId = i.ReadingQuestionTypeId,
                                ReadingQuestionTypeTitle = ReadingQuestionType.Title,
                                ReadingQuestionTypeCodeName = ReadingQuestionType.CodeName,
                                ReadingQuestionAnswers = (List<ReadingQuestionAnswersQueryFacadeDto>)Mapper.Map<ReadingQuestionAnswer, ReadingQuestionAnswersQueryFacadeDto>(i.ReadingQuestionAnswers.OrderBy(a => a.OrderNo))
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
