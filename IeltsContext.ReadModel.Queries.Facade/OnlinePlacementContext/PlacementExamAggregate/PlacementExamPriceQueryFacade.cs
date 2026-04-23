using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementExamAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;


namespace ExamContext.ReadModel.Queries.Facade.OnlinePlacementContext.PlacementExamAggregate
{
    public class PlacementExamPriceQueryFacade : IPlacementExamPriceQueryFacade
    {
        public IEnumerable<PlacementExamPriceQueryFacadeDto> GetPlacementExamPriceFilteringList(ref DataTableAjaxPostModel filters, Guid id)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.PlacementExamPrices.Where(a => a.PlacementExamId == id && a.IsDeleted == false)
                                select new PlacementExamPriceQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    PriceAmount = i.PriceAmount,
                                    DiscontentAmount = i.DiscontentAmount,
                                    ActivedDate = i.ActivedDate,
                                    DeactivedDate = i.DeactivedDate,
                                    PlacementExamId = i.PlacementExamId,
                                    IsActive = i.IsActive,
                                    IsDeleted = i.IsDeleted//,

                                });

                    //var Result = data.Where(v =>
                    //            (titleSerach == null ||
                    //            (titleSerach != null && (v.PriceAmount.ToString().Contains(titleSerach.ToString()))
                    //                                                  ))).AsQueryable();
                    var Result = data;
                    filters.filteredResultsCount = Result.Count();

                    var sort = (filters.order != null ? filters.columns[filters.order[0].column].data : "") + " " + (filters.order != null ? filters.order[0].dir.ToLower() : "");

                    Result = Result.OrderBy(sort).Skip(filters.start).Take(filters.length);
                    sort = sort == "activedDate_Persian desc" ? "activedDate desc" : sort;
                    sort = sort == "activedDate_Persian asc" ? "activedDate asc" : sort;

                    sort = sort == "deActivedDate_Persian desc" ? "deActivedDate desc" : sort;
                    sort = sort == "deActivedDate_Persian asc" ? "deActivedDate asc" : sort;

                    var ResultFinal = Result.ToList();
                    ResultFinal.ForEach(a => a.ActivedDate_Persian = DateConverter.MiladiToShamsiConvert(a.ActivedDate, true));
                    ResultFinal.ForEach(a => a.DeActivedDate_Persian = DateConverter.MiladiToShamsiConvert(a.DeactivedDate, true));

                    return ResultFinal.ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public bool IaAnyActivePlacementExamPriceWithGivenExamId(Guid placementExamId)
        {
            using (var context = new ExamContextReadModelDBContext())
            {
                return context.PlacementExamPrices.Any(a => a.PlacementExamId == placementExamId && a.IsActive == true);
            }
        }
    }
}
