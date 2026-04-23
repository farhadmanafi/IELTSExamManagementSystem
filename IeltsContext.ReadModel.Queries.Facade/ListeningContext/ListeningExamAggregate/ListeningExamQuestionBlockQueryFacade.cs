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
    public class ListeningExamQuestionBlockQueryFacade : IListeningExamQuestionBlockQueryFacade
    {
        public IEnumerable<ListeningExamQuestionBlockQueryFacadeDto> GetListeningExamQuestionBlockListForGridView(ref DataTableAjaxPostModel filters, Guid id)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.ListeningExamQuestionBlocks.Where(a => a.ListeningExamSectionId == id && a.IsDeleted == false  )
                                    //let listeningExam = (from le in context.ListeningExams where i.ListeningExamId == le.Id select le).FirstOrDefault()
                                select new ListeningExamQuestionBlockQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    Title = i.Title,
                                    OrderNo = i.OrderNo,
                                    Description = i.Description,
                                    IsActive = i.IsActive,
                                    IsDeleted = i.IsDeleted,
                                    ListeningExamSectionId = i.ListeningExamSectionId// listeningExam.Id
                                });

                    var Result = data.Where(v =>
                                (titleSerach == null ||
                                (titleSerach != null && (v.Title.Contains(titleSerach.ToString())| 
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

        public ListeningExamQuestionBlockQueryFacadeDto GetListeningExamQuestionBlock(Guid ListeningExamQuestionBlocId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ListeningExamQuestionBlocks.Where(a => a.IsActive == true &&
                            a.IsDeleted == false && a.Id == ListeningExamQuestionBlocId)
                            select new ListeningExamQuestionBlockQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                ListeningExamSectionId=i.ListeningExamSectionId,
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

        public IEnumerable<ListeningExamQuestionBlockQueryFacadeDto> GetListeningExamQuestionBlocList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ListeningExamQuestionBlocks.Where(a => a.IsActive == true && a.IsDeleted == false)
                            select new ListeningExamQuestionBlockQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                ListeningExamSectionId=i.ListeningExamSectionId,
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

        public IEnumerable<ListeningExamQuestionBlockQueryFacadeDto> GetListeningExamQuestionBlocListByListeningSectionId(Guid listeningExamSectionId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ListeningExamQuestionBlocks.Where(a => a.ListeningExamSectionId == listeningExamSectionId && a.IsDeleted == false)
                            select new ListeningExamQuestionBlockQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                ListeningExamSectionId=i.ListeningExamSectionId,
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
