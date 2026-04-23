using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningExamAggregate;
using ExamContext.ReadModel.Queries.Contracts.ListeningContext.ListeningExamAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.ListeningContext.ListeningExamAggregate
{
    public class ListeningExamQueryFacade : IListeningExamQueryFacade
    {
        public ListeningExamQueryFacadeDto GetListeningExamById(Guid listeningExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ListeningExams.Where(a => a.Id == listeningExamId)
                            select new ListeningExamQueryFacadeDto()
                            {
                                Id = i.Id,
                                IeltsExamId = i.IeltsExamId,
                                Description = i.Description,
                                Title = i.Title,
                                VoiceSource = i.VoiceSource,
                                TimerMinuties = i.TimerMinuties,
                                IsActive = (bool)i.IsActive,
                                IsDeleted = (bool)i.IsDeleted
                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<ListeningExamQueryFacadeDto> GetListeningExamList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ListeningExams.Where(a => a.IsDeleted == false)
                            select new ListeningExamQueryFacadeDto()
                            {
                                Id = i.Id,
                                IeltsExamId = i.IeltsExamId,
                                Description = i.Description,
                                Title = i.Title,
                                VoiceSource = i.VoiceSource,
                                TimerMinuties = i.TimerMinuties,
                                IsActive = (bool)i.IsActive,
                                IsDeleted = (bool)i.IsDeleted
                            }).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<ListeningExamQueryFacadeDto> GetListeningExamByFilteringList(ref DataTableAjaxPostModel filters, Guid examId)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.ListeningExams.Where(a => a.IeltsExamId == examId && a.IsDeleted == false)
                            select new ListeningExamQueryFacadeDto()
                            {
                                Id = i.Id,
                                IeltsExamId = i.IeltsExamId,
                                Description = i.Description,
                                Title = i.Title,
                                VoiceSource = i.VoiceSource,
                                TimerMinuties = i.TimerMinuties,
                                IsActive = (bool)i.IsActive,
                                IsDeleted = (bool)i.IsDeleted//,
                                //listeningExamQuestionBlocks = (List<ListeningExamQuestionBlockQueryFacadeDto>)i.ListeningExamQuestionBlocks

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

        public ListeningExamQueryFacadeDto GetListeningExamForUserPanel(Guid id)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.ListeningExams.Where(a => a.Id == id && a.IsDeleted == false)
                            select new ListeningExamQueryFacadeDto()
                            {
                                Id = i.Id,
                                IeltsExamId = i.IeltsExamId,
                                Description = i.Description,
                                Title = i.Title,
                                PreVoiceSource = i.PreVoiceSource,
                                VoiceSource = i.VoiceSource,
                                TimerMinuties = i.TimerMinuties,
                                IsActive = (bool)i.IsActive,
                                IsDeleted = (bool)i.IsDeleted//,
                                //listeningExamQuestionBlocks = (List<ListeningExamQuestionBlockQueryFacadeDto>)i.ListeningExamQuestionBlocks

                            });

                    return data.FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public int GetListeningExamCount(Guid id)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return  context.ListeningExams.Where(a=>a.IeltsExamId==id && a.IsActive==true).Count();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public Guid GetIeltsExamByListeningExamId(Guid listeningExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return context.ListeningExams.FirstOrDefault(a => a.Id == listeningExamId).IeltsExamId;
                }
                            
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
