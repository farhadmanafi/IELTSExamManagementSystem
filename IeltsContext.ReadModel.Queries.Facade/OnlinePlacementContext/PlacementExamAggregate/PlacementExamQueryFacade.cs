using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementExamAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.OnlinePlacementContext.PlacementExamAggregate
{
    public class PlacementExamQueryFacade : IPlacementExamQueryFacade
    {
        public PlacementExamQueryFacadeDto GetPlacementExam(Guid placementExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.PlacementExams.Where(a => a.Id == placementExamId)
                            select new PlacementExamQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                ActivedDate = i.ActivedDate,
                                DeActivedDate = i.DeActivedDate,
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

        public PlacementExamQueryFacadeDto GetPlacementExamForUserpanel(Guid placementExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.PlacementExams.Where(a => a.Id == placementExamId)
                            let placementExamPrice = (from le in context.PlacementExamPrices where i.Id == le.PlacementExamId && le.IsActive == true select le).FirstOrDefault()
                            select new PlacementExamQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                Description = i.Description,
                                ActivedDate = i.ActivedDate,
                                DeActivedDate = i.DeActivedDate,
                                PlacementExamPriceId = placementExamPrice.Id,
                                PriceAmount = placementExamPrice.PriceAmount,
                                DiscontentAmount = placementExamPrice.DiscontentAmount,
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

        public IEnumerable<PlacementExamQueryFacadeDto> GetPlacementExamList(ref DataTableAjaxPostModel filters)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.PlacementExams.Where(a => a.IsDeleted == false)
                                select new PlacementExamQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    Title = i.Title,
                                    Description = i.Description,
                                    ActivedDate = i.ActivedDate,
                                    DeActivedDate = i.DeActivedDate,
                                    IsActive = i.IsActive,
                                    IsDeleted = i.IsDeleted
                                });

                    var Result = data.Where(v =>
                                (titleSerach == null ||
                                (titleSerach != null && (v.Title.Contains(titleSerach.ToString()) ||
                                                                      v.Description.Contains(titleSerach.ToString()))
                                                                      ))).AsQueryable();

                    filters.filteredResultsCount = Result.Count();

                    var sort = (filters.order != null ? filters.columns[filters.order[0].column].data : "") + " " + (filters.order != null ? filters.order[0].dir.ToLower() : "");

                    sort = sort == "activedDate_Persian desc" ? "activedDate desc" : sort;
                    sort = sort == "activedDate_Persian asc" ? "activedDate asc" : sort;

                    sort = sort == "deActivedDate_Persian desc" ? "deActivedDate desc" : sort;
                    sort = sort == "deActivedDate_Persian asc" ? "deActivedDate asc" : sort;

                    Result = Result.OrderBy(sort).Skip(filters.start).Take(filters.length);

                    var ResultFinal = Result.ToList();
                    ResultFinal.ForEach(a => a.ActivedDate_Persian = DateConverter.MiladiToShamsiConvert(a.ActivedDate, true));
                    ResultFinal.ForEach(a => a.DeActivedDate_Persian = DateConverter.MiladiToShamsiConvert(a.DeActivedDate, true));
                    return ResultFinal.ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<PlacementExamQueryFacadeDto> GetPlacementExamActiveList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.PlacementExams.Where(a => a.IsActive == true && a.IsDeleted == false)
                                select new PlacementExamQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    Title = i.Title,
                                    Description = i.Description,
                                    ActivedDate = i.ActivedDate,
                                    DeActivedDate = i.DeActivedDate,
                                    IsActive = i.IsActive,
                                    IsDeleted = i.IsDeleted
                                }).ToList();

                    data.ForEach(a => a.ActivedDate_Persian = DateConverter.MiladiToShamsiConvert(a.ActivedDate, true));
                    data.ForEach(a => a.DeActivedDate_Persian = DateConverter.MiladiToShamsiConvert(a.DeActivedDate, true));
                    return data.ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
