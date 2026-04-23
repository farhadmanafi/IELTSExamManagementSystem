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
    public class ReadingExamSectionQueryFacade : IReadingExamSectionQueryFacade
    {
        public ReadingExamSectionQueryFacadeDto GetReadingExamSection(Guid readingExamSectionId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ReadingExamSections.Where(a => a.Id == readingExamSectionId 
                                                                                    && a.IsDeleted == false)
                            select new ReadingExamSectionQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                ReadingText = i.ReadingText,
                                OrderNo = i.OrderNo,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                ReadingExamId=i.ReadingExamId

                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<ReadingExamSectionQueryFacadeDto> GetReadingExamSectionList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ReadingExamSections.Where(a => a.IsDeleted == false )
                            select new ReadingExamSectionQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                ReadingText = i.ReadingText,
                                OrderNo = i.OrderNo,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                ReadingExamId = i.ReadingExamId
                            }).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<ReadingExamSectionQueryFacadeDto> GetReadingExamSectionListByReadingExamId(Guid readingExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ReadingExamSections.Where(a => a.ReadingExamId == readingExamId
                                                                                    && a.IsDeleted == false)
                            select new ReadingExamSectionQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                ReadingText = i.ReadingText,
                                OrderNo = i.OrderNo,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                ReadingExamId = i.ReadingExamId
                            }).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<ReadingExamSectionQueryFacadeDto> GetReadingExamSectionListForGridView(ref DataTableAjaxPostModel filters, Guid id)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.ReadingExamSections.Where(a => a.ReadingExamId== id && a.IsDeleted == false)
                            select new ReadingExamSectionQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                ReadingText = i.ReadingText,
                                OrderNo = i.OrderNo,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                ReadingExamId = i.ReadingExamId

                            });

                    var Result = data.Where(v =>
                                (titleSerach == null ||
                                (titleSerach != null && (v.Title.Contains(titleSerach.ToString()))
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
    }
}
