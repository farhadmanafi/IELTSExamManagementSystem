using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.IeltsAggregarte.DataContracts;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.IeltsAggregarte.IeltsAggregarte;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.IeltsExamContext.IeltsAggregarte
{
    public class IeltsExamQueryFacade : IIeltsExamQueryFacade
    {
        public IeltsExamQueryFacadeDto GetIeltsExamByIdForUserpanel(Guid id)
        {
            using (var context = new ExamContextReadModelDBContext())
            {
                var data  = (from i in context.IeltsExams.Where(f => f.Id == id)
                        let ieltsExamPrices = (from p in context.IeltsExamPrices where i.Id == p.IeltsExamId select p).FirstOrDefault(a=>a.IsActive == true)
                        let listeningExam = (from le in context.ListeningExams where i.Id == le.IeltsExamId select le).FirstOrDefault()
                        let readingExam = (from re in context.ReadingExams where i.Id == re.IeltsExamId select re).FirstOrDefault()
                        let speakingExam = (from se in context.SpeakingExams where i.Id == se.IeltsExamId select se).FirstOrDefault()
                        let writingExam = (from we in context.WritingExams where i.Id == we.IeltsExamId select we).FirstOrDefault()
                        select new IeltsExamQueryFacadeDto()
                        {
                            Id = i.Id,
                            Title = i.Title,
                            Description = i.Description,
                            UserId = i.UserId,
                            IeltsExamPriceId = ieltsExamPrices.Id,
                            PriceAmount = ieltsExamPrices.PriceAmount,
                            DiscontentAmount = ieltsExamPrices.DiscontentAmount,
                            ActivedDate = i.ActivedDate,
                            DeActivedDate = i.DeactivedDate,
                            IsActive = i.IsActive,
                            IsDeleted = i.IsDeleted,
                            ListeningExamId = listeningExam.Id,
                            ReadingExamId = readingExam.Id,
                            SpeakigExamId = speakingExam.Id,
                            WritingExamId = writingExam.Id
                        }).FirstOrDefault();
                return data;
            }
            
        }

        public IEnumerable<IeltsExamQueryFacadeDto> GetIeltsExamFilteringList(ref DataTableAjaxPostModel filters)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.IeltsExams.Where(a => a.IsDeleted == false)
                                let user = (from us in context.AspUsers where i.UserId.ToString() == us.Id select us).FirstOrDefault()
                                let listeningExam=(from le in context.ListeningExams where i.Id==le.IeltsExamId select le).FirstOrDefault()
                                let readingExam=(from re in context.ReadingExams where i.Id==re.IeltsExamId select re).FirstOrDefault()
                                let speakingExam=(from se in context.SpeakingExams where i.Id==se.IeltsExamId select se).FirstOrDefault()
                                let writingExam=(from we in context.WritingExams where i.Id==we.IeltsExamId select we).FirstOrDefault()
                                select new IeltsExamQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    Title = i.Title,
                                    UserId = i.UserId,
                                    UserName = user.UserName,
                                    ActivedDate = i.ActivedDate,
                                    DeActivedDate = i.DeactivedDate,
                                    IsActive = i.IsActive,
                                    IsDeleted = i.IsDeleted,
                                    ListeningExamId=listeningExam.Id,
                                    ReadingExamId=readingExam.Id,
                                    SpeakigExamId=speakingExam.Id,
                                    WritingExamId=writingExam.Id
                                });

                    var Result = data.Where(v =>
                                (titleSerach == null ||
                                (titleSerach != null && (v.Title.Contains(titleSerach.ToString()) ||
                                                                      v.Description.Contains(titleSerach.ToString()))
                                                                      ))).AsQueryable();

                    filters.filteredResultsCount = Result.Count();

                    var sort = (filters.order != null ? filters.columns[filters.order[0].column].data : "") + " " + (filters.order != null ? filters.order[0].dir.ToLower() : "");

                    Result = Result.OrderBy(sort).Skip(filters.start).Take(filters.length);
                    sort = sort == "activedDate_Persian desc" ? "activedDate desc" : sort;
                    sort = sort == "activedDate_Persian asc" ? "activedDate asc" : sort;

                    sort = sort == "deActivedDate_Persian desc" ? "deActivedDate desc" : sort;
                    sort = sort == "deActivedDate_Persian asc" ? "deActivedDate asc" : sort;

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

        public IEnumerable<IeltsExamResultQueryFacadeDto> GetIeltsExamResulFilteringList(ref DataTableAjaxPostModel filters)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.IeltsExams.Where(a => a.IsDeleted == false)
                                select new IeltsExamResultQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    Title = i.Title
                                });

                    var Result = data.Where(v =>
                                (titleSerach == null ||
                                (titleSerach != null && (v.Title.Contains(titleSerach.ToString()))))).AsQueryable();

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

        IeltsExamQueryFacadeDto IIeltsExamQueryFacade.GetIeltsExamById(Guid id)
        {
            using (var context = new ExamContextReadModelDBContext())
            {
                return (from i in context.IeltsExams.Where(f => f.Id == id)
                        select new IeltsExamQueryFacadeDto()
                        {
                            Id = i.Id,
                            Title = i.Title,
                            Description = i.Description,
                            UserId = i.UserId,
                            ActivedDate = i.ActivedDate,
                            DeActivedDate = i.DeactivedDate,
                            IsActive = i.IsActive,
                            IsDeleted = i.IsDeleted
                        }).FirstOrDefault();
            }
        }

        IList<IeltsExamQueryFacadeDto> IIeltsExamQueryFacade.GetIeltsExamList()
        {
            using (var context = new ExamContextReadModelDBContext())
            {
                return (from i in context.IeltsExams
                        where i.IsActive == true && i.IsDeleted == false
                        select new IeltsExamQueryFacadeDto()
                        {
                            Id = i.Id,
                            Title = i.Title,
                            Description = i.Description,
                            UserId = i.UserId,
                            ActivedDate = i.ActivedDate,
                            DeActivedDate = i.DeactivedDate,
                            IsActive = i.IsActive,
                            IsDeleted = i.IsDeleted
                        }).ToList();
            }
        }
    }
}
