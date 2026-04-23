using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.ParticipantsAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.OnlinePlacementContext.ParticipantsAggregate
{
    public class OnlinePlacementParticipantsQueryFacade : IOnlinePlacementParticipantsQueryFacade
    {
        public Guid GetCustomerIdFromParticipantId(Guid participantId)
        {
            using (var context = new ExamContextReadModelDBContext())
            {
                return context.PlacementExamParticipants.FirstOrDefault(a => a.Id == participantId).CustomerId;
            }
        }

        public IEnumerable<OnlinePlacementParticipantsQueryFacadeDto> GetOnlinePlacementFilteringList(ref DataTableAjaxPostModel filters, Guid OnlinePlacementId)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.PlacementExamParticipants.Where(a => a.PlacementExamId == OnlinePlacementId && a.IsDeleted == false)
                                let user = (from us in context.AspUsers where i.CustomerId.ToString() == us.Id select us).FirstOrDefault()
                                let ExamPrice = (from ep in context.PlacementExamPrices where i.PlacementExamPriceId == ep.Id select ep).FirstOrDefault()
                                let OnlinePlacement = (from ie in context.PlacementExams where i.PlacementExamId == ie.Id select ie).FirstOrDefault()
                                select new OnlinePlacementParticipantsQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    CustomerId = i.CustomerId,
                                    UserName = user.UserName,
                                    OnlinePlacementId = i.PlacementExamId,
                                    ExamTitle = OnlinePlacement.Title,
                                    OnlinePlacementPriceId = i.PlacementExamPriceId,
                                    PriceAmount = ExamPrice.PriceAmount,
                                    DiscontentAmount = ExamPrice.DiscontentAmount,
                                    RegisterDate = i.RegisterDate,
                                    IsActive = i.IsActive,
                                    IsDeleted = i.IsDeleted
                                });

                    var Result = data.Where(v =>
                                (titleSerach == null ||
                                (titleSerach != null && (v.UserName.Contains(titleSerach.ToString()) ||
                                                                      v.ExamTitle.Contains(titleSerach.ToString()))
                                                                      ))).AsQueryable();

                    filters.filteredResultsCount = Result.Count();

                    var sort = (filters.order != null ? filters.columns[filters.order[0].column].data : "") + " " + (filters.order != null ? filters.order[0].dir.ToLower() : "");

                    Result = Result.OrderBy(sort).Skip(filters.start).Take(filters.length);
                    sort = sort == "registerDatePersian desc" ? "registerDate desc" : sort;
                    sort = sort == "registerDatePersian asc" ? "registerDate asc" : sort;

                    var ResultFinal = Result.ToList();
                    ResultFinal.ForEach(a => a.RegisterDatePersian = DateConverter.MiladiToShamsiConvert(a.RegisterDate, true));
                    return ResultFinal.ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<OnlinePlacementParticipantsQueryFacadeDto> GetOnlinePlacementFilteringListByCustomerId(ref DataTableAjaxPostModel filters, Guid customerId)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.PlacementExamParticipants.Where(a => a.CustomerId == customerId && a.IsDeleted == false)
                                let user = (from us in context.AspUsers where i.CustomerId.ToString() == us.Id select us).FirstOrDefault()
                                let ExamPrice = (from ep in context.PlacementExamPrices where i.PlacementExamPriceId == ep.Id select ep).FirstOrDefault()
                                let OnlinePlacement = (from ie in context.PlacementExams where i.PlacementExamId == ie.Id select ie).FirstOrDefault()
                                select new OnlinePlacementParticipantsQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    CustomerId = i.CustomerId,
                                    OnlinePlacementParticipantsStatusId = i.PlacementExamParticipantsStatusId,
                                    UserName = user.UserName,
                                    OnlinePlacementId = i.PlacementExamId,
                                    ExamTitle = OnlinePlacement.Title,
                                    OnlinePlacementPriceId = i.PlacementExamPriceId,
                                    PriceAmount = ExamPrice.PriceAmount,
                                    DiscontentAmount = ExamPrice.DiscontentAmount,
                                    RegisterDate = i.RegisterDate,
                                    IsActive = i.IsActive,
                                    IsDeleted = i.IsDeleted
                                });

                    var Result = data.Where(v =>
                                (titleSerach == null ||
                                (titleSerach != null && (v.UserName.Contains(titleSerach.ToString()) ||
                                                                      v.ExamTitle.Contains(titleSerach.ToString()))
                                                                      ))).AsQueryable();

                    filters.filteredResultsCount = Result.Count();

                    var sort = (filters.order != null ? filters.columns[filters.order[0].column].data : "") + " " + (filters.order != null ? filters.order[0].dir.ToLower() : "");

                    Result = Result.OrderBy(sort).Skip(filters.start).Take(filters.length);
                    sort = sort == "registerDatePersian desc" ? "registerDate desc" : sort;
                    sort = sort == "registerDatePersian asc" ? "registerDate asc" : sort;

                    var ResultFinal = Result.ToList();
                    ResultFinal.ForEach(a => a.RegisterDatePersian = DateConverter.MiladiToShamsiConvert(a.RegisterDate, true));
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
