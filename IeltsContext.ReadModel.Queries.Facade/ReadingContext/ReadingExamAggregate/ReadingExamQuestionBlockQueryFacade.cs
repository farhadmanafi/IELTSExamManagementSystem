using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.ReadingContext.ReadingExamAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.ReadingContext.ReadingExamAggregate
{
    public class ReadingExamQuestionBlockQueryFacade : IReadingExamQuestionBlockQueryFacade
    {
        public ReadingExamQuestionBlockQueryFacadeDto GetReadingExamQuestionBlock(Guid readingExamQuestionBlockId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ReadingExamQuestionBlocks.Where(a =>a.IsDeleted == false && a.Id == readingExamQuestionBlockId)
                            select new ReadingExamQuestionBlockQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                ReadingExamSectionId=i.ReadingExamSectionId,
                                OrderNo = i.OrderNo,
                                Description = i.Description,
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

        public IEnumerable<ReadingExamQuestionBlockQueryFacadeDto> GetReadingExamQuestionBlockList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ReadingExamQuestionBlocks.Where(a => a.IsDeleted == false)
                            select new ReadingExamQuestionBlockQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                ReadingExamSectionId = i.ReadingExamSectionId,
                                OrderNo = i.OrderNo,
                                Description = i.Description,
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

        public IEnumerable<ReadingExamQuestionBlockQueryFacadeDto> GetReadingExamQuestionBlockListForGridView(ref DataTableAjaxPostModel filters, Guid id)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.ReadingExamQuestionBlocks.Where(a => a.ReadingExamSectionId == id && a.IsDeleted == false)
                            select new ReadingExamQuestionBlockQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                ReadingExamSectionId = i.ReadingExamSectionId,
                                OrderNo = i.OrderNo,
                                Description = i.Description,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted
                            });

                    var Result = data.Where(v =>
                                (titleSerach == null ||
                                (titleSerach != null && (v.Title.Contains(titleSerach.ToString()) |
                                                        v.Description.Contains(titleSerach.ToString()))
                                                                      ))).AsQueryable();

                    filters.filteredResultsCount = Result.Count();

                    var sort = (filters.order != null ? filters.columns[filters.order[0].column].data : "") + " " + (filters.order != null ? filters.order[0].dir.ToLower() : "");

                    Result = Result.OrderBy(sort).Skip(filters.start).Take(filters.length);

                    var ResultFinal = Result.ToList();
                    return ResultFinal.ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<ReadingExamQuestionBlockQueryFacadeDto> GetReadingExamQuestionBlocListByReadingSectionId(Guid readingExamSectionId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ReadingExamQuestionBlocks.Where(a => a.IsDeleted == false && a.ReadingExamSectionId == readingExamSectionId)
                            select new ReadingExamQuestionBlockQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                ReadingExamSectionId = i.ReadingExamSectionId,
                                OrderNo = i.OrderNo,
                                Description = i.Description,
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
    }
}
