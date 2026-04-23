using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.IeltsExamContext.ParticipantsAggregate
{
    public class IeltsExamParticipantsQueryFacade : IIeltsExamParticipantsQueryFacade
    {
        public Guid GetCustomerIdFromParticipantId(Guid participantId)
        {
            using (var context = new ExamContextReadModelDBContext())
            {
                return context.IeltsExamParticipants.FirstOrDefault(a => a.Id == participantId).CustomerId;
            }
        }

        public IEnumerable<IeltsExamParticipantsQueryFacadeDto> GetIeltsExamFilteringList(ref DataTableAjaxPostModel filters, Guid ieltsExamId)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.IeltsExamParticipants.Where(a => a.IeltsExamId == ieltsExamId && a.IsDeleted == false)
                                let user = (from us in context.AspUsers where i.CustomerId.ToString() == us.Id select us).FirstOrDefault()
                                let ExamPrice = (from ep in context.IeltsExamPrices where i.IeltsExamPriceId == ep.Id select ep).FirstOrDefault()
                                let IeltsExam = (from ie in context.IeltsExams where i.IeltsExamId == ie.Id select ie).FirstOrDefault()
                                select new IeltsExamParticipantsQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    CustomerId = i.CustomerId,
                                    UserName = user.UserName,
                                    IeltsExamId = i.IeltsExamId,
                                    ExamTitle = IeltsExam.Title,
                                    IeltsExamPriceId = i.IeltsExamPriceId,
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

        public IEnumerable<IeltsExamParticipantsQueryFacadeDto> GetIeltsExamFilteringListByCustomerId(ref DataTableAjaxPostModel filters, Guid customerId)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.IeltsExamParticipants.Where(a => a.CustomerId == customerId && a.IsDeleted == false)
                                let user = (from us in context.AspUsers where i.CustomerId.ToString() == us.Id select us).FirstOrDefault()
                                let ExamPrice = (from ep in context.IeltsExamPrices where i.IeltsExamPriceId == ep.Id select ep).FirstOrDefault()
                                let IeltsExam = (from ie in context.IeltsExams where i.IeltsExamId == ie.Id select ie).FirstOrDefault()
                                select new IeltsExamParticipantsQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    CustomerId = i.CustomerId,
                                    IeltsExamParticipantsStatusId = i.IeltsExamParticipantsStatusId,
                                    UserName = user.UserName,
                                    IeltsExamId = i.IeltsExamId,
                                    ExamTitle = IeltsExam.Title,
                                    IeltsExamPriceId = i.IeltsExamPriceId,
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
