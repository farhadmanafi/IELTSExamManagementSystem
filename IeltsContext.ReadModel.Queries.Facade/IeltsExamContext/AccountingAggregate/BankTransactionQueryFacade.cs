using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.AccountingContext.AccountingAggregate;
using ExamContext.ReadModel.Queries.Contracts.AccountingContext.AccountingAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.IeltsExamContext.AccountingAggregate
{
    public class BankTransactionQueryFacade : IBankTransactionQueryFacade
    {
        public BankTransactionListQueryFacadeDto GetBankTransactionByPaymentId(Guid paymentId)
        {
            using (var context = new ExamContextReadModelDBContext())
            {
                var data = (from bt in context.BankTransactions.Where(a=>a.Id == paymentId)
                            join TransactionType in context.BankTransactionTypes on bt.BankTransactionTypeId equals TransactionType.Id
                            join Participants in context.IeltsExamParticipants on bt.ParticipantsId equals Participants.Id
                            //join ExamPrice in context.IeltsExamPrices on Participants.IeltsExamPriceId equals ExamPrice.Id
                            join IeltsExam in context.IeltsExams on Participants.IeltsExamId equals IeltsExam.Id
                            join user in context.AspUsers on Participants.CustomerId.ToString() equals user.Id

                            select new BankTransactionListQueryFacadeDto()
                            {
                                IeltsExamParticipantsId = bt.ParticipantsId,
                                BankTransactionTypeId = bt.BankTransactionTypeId,
                                BankTransactionTitle = TransactionType.Title,
                                IeltsExamPriceId = Participants.IeltsExamPriceId,
                                //PriceAmount = ExamPrice.PriceAmount,
                                //DiscontentAmount = ExamPrice.DiscontentAmount,
                                CalculatedPriceAmount = bt.PaymentPriceAmount,
                                //CalculatedPriceAmount= ExamPrice.PriceAmount-(ExamPrice.PriceAmount* ExamPrice.DiscontentAmount/100),
                                CustomerId = Participants.CustomerId,
                                CustomerName = user.UserName,
                                IeltsExamTitle = IeltsExam.Title,
                                PaymentDateTime = bt.PaymentDateTime,
                                BankTransactionCode = bt.BankTransactionCode
                            });

                return data.FirstOrDefault();
            }
        }

        public IList<BankTransactionListQueryFacadeDto> GetBankTransactionList(ref DataTableAjaxPostModel filters)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from bt in context.BankTransactions
                                join TransactionType in context.BankTransactionTypes on bt.BankTransactionTypeId equals TransactionType.Id 
                                join ExamType in context.ExamTypes on bt.ExamTypeId equals ExamType.Id 
                                join Participants in context.IeltsExamParticipants on bt.ParticipantsId equals Participants.Id
                                join ExamPrice in context.IeltsExamPrices on Participants.IeltsExamPriceId equals ExamPrice.Id 
                                join IeltsExam in context.IeltsExams on Participants.IeltsExamId equals IeltsExam.Id
                                join user in context.AspUsers on Participants.CustomerId.ToString() equals user.Id

                                //let TransactionType = (from trt in context.BankTransactionTypes where i.BankTransactionTypeId == trt.Id select trt).FirstOrDefault()
                                //let Participants = (from p in context.IeltsExamParticipants where i.IeltsExamParticipantsId == p.Id select p).FirstOrDefault()
                                //let ExamPrice = (from ep in context.IeltsExamPrices where Participants.IeltsExamPriceId == ep.Id select ep).FirstOrDefault()
                                //let IeltsExam = (from ie in context.IeltsExams where Participants.IeltsExamId == ie.Id select ie).FirstOrDefault()
                                //let user = (from us in context.AspUsers where i.CustomerId.ToString() == us.Id select us).FirstOrDefault()
                                select new BankTransactionListQueryFacadeDto()
                                {
                                    IeltsExamParticipantsId=bt.ParticipantsId,
                                    BankTransactionTypeId=bt.BankTransactionTypeId,
                                    BankTransactionTitle= TransactionType.Title,
                                    ExamTypeId = bt.ExamTypeId,
                                    ExamTypeTitle = ExamType.Title,
                                    IeltsExamPriceId =Participants.IeltsExamPriceId,
                                    PriceAmount=ExamPrice.PriceAmount,
                                    DiscontentAmount=ExamPrice.DiscontentAmount,
                                    CalculatedPriceAmount= bt.PaymentPriceAmount,
                                    //CalculatedPriceAmount= ExamPrice.PriceAmount-(ExamPrice.PriceAmount* ExamPrice.DiscontentAmount/100),
                                    CustomerId =Participants.CustomerId,
                                    CustomerName=user.UserName,
                                    IeltsExamTitle=IeltsExam.Title,
                                    PaymentDateTime=bt.PaymentDateTime,
                                    BankTransactionCode=bt.BankTransactionCode
                                });

                    var Result = data.Where(v =>
                                (titleSerach == null ||
                                (titleSerach != null && (v.BankTransactionTitle.Contains(titleSerach.ToString()) ||
                                                                      v.IeltsExamTitle.Contains(titleSerach.ToString())||
                                                                      v.CustomerName.Contains(titleSerach.ToString()))
                                                                      ))).AsQueryable();

                    filters.filteredResultsCount = Result.Count();

                    var sort = (filters.order != null ? filters.columns[filters.order[0].column].data : "") + " " + (filters.order != null ? filters.order[0].dir.ToLower() : "");

                    Result = Result.OrderBy(sort).Skip(filters.start).Take(filters.length);
                    sort = sort == "PaymentDateTimePersian desc" ? "PaymentDateTime desc" : sort;
                    sort = sort == "PaymentDateTimePersian asc" ? "PaymentDateTime asc" : sort;

                    var ResultFinal = Result.ToList();
                    ResultFinal.ForEach(a => a.PaymentDateTimePersian = DateConverter.MiladiToShamsiConvert(a.PaymentDateTime, true));
                    return ResultFinal.ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IList<BankTransactionListQueryFacadeDto> GetBankTransactionListForGivenCustomer(ref DataTableAjaxPostModel filters,Guid customerId)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from bt in context.BankTransactions
                                join TransactionType in context.BankTransactionTypes on bt.BankTransactionTypeId equals TransactionType.Id
                                join ExamType in context.ExamTypes on bt.ExamTypeId equals ExamType.Id
                                join Participants in context.IeltsExamParticipants on bt.ParticipantsId equals Participants.Id
                                //join ExamPrice in context.IeltsExamPrices on Participants.IeltsExamPriceId equals ExamPrice.Id
                                join IeltsExam in context.IeltsExams on Participants.IeltsExamId equals IeltsExam.Id
                                join user in context.AspUsers on Participants.CustomerId.ToString() equals user.Id

                                select new BankTransactionListQueryFacadeDto()
                                {
                                    IeltsExamParticipantsId = bt.ParticipantsId,
                                    BankTransactionTypeId = bt.BankTransactionTypeId,
                                    BankTransactionTitle = TransactionType.Title,
                                    ExamTypeId = bt.ExamTypeId,
                                    ExamTypeTitle = ExamType.Title,
                                    IeltsExamPriceId = Participants.IeltsExamPriceId,
                                    //PriceAmount = ExamPrice.PriceAmount,
                                    //DiscontentAmount = ExamPrice.DiscontentAmount,
                                    CalculatedPriceAmount = bt.PaymentPriceAmount,
                                    //CalculatedPriceAmount= ExamPrice.PriceAmount-(ExamPrice.PriceAmount* ExamPrice.DiscontentAmount/100),
                                    CustomerId = Participants.CustomerId,
                                    CustomerName = user.UserName,
                                    IeltsExamTitle = IeltsExam.Title,
                                    PaymentDateTime = bt.PaymentDateTime,
                                    BankTransactionCode = bt.BankTransactionCode
                                });

                    var Result = data.Where(v =>v.CustomerId==customerId &&
                                (titleSerach == null ||
                                (titleSerach != null && (v.BankTransactionTitle.Contains(titleSerach.ToString()) ||
                                                                      v.IeltsExamTitle.Contains(titleSerach.ToString()) ||
                                                                      v.CustomerName.Contains(titleSerach.ToString()))
                                                                      ))).AsQueryable();

                    filters.filteredResultsCount = Result.Count();

                    var sort = (filters.order != null ? filters.columns[filters.order[0].column].data : "") + " " + (filters.order != null ? filters.order[0].dir.ToLower() : "");

                    Result = Result.OrderBy(sort).Skip(filters.start).Take(filters.length);
                    sort = sort == "PaymentDateTimePersian desc" ? "PaymentDateTime desc" : sort;
                    sort = sort == "PaymentDateTimePersian asc" ? "PaymentDateTime asc" : sort;

                    var ResultFinal = Result.ToList();
                    ResultFinal.ForEach(a => a.PaymentDateTimePersian = DateConverter.MiladiToShamsiConvert(a.PaymentDateTime, true));
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
