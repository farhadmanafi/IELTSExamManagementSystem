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
    public class ListeningExamSectionQueryFacade : IListeningExamSectionQueryFacade
    {
        public ListeningExamSectionQueryFacadeDto GetListeningExamSection(Guid ListeningExamSectionId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ListeningExamSections.Where(a => a.IsActive == true &&
                            a.IsDeleted == false && a.Id == ListeningExamSectionId)
                            select new ListeningExamSectionQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                OrderNo = i.OrderNo,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                ListeningExamId=i.ListeningExamId

                            }).FirstOrDefault();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<ListeningExamSectionQueryFacadeDto> GetListeningExamSectionList()
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ListeningExamSections.Where(a => a.IsActive == true &&
                            a.IsDeleted == false )
                            select new ListeningExamSectionQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                OrderNo = i.OrderNo,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                ListeningExamId = i.ListeningExamId

                            }).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<ListeningExamSectionQueryFacadeDto> GetListeningExamSectionListByListeningExamId(Guid listeningExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.ListeningExamSections.Where(a => a.ListeningExamId == listeningExamId &&
                            a.IsDeleted == false )
                            select new ListeningExamSectionQueryFacadeDto()
                            {
                                Id = i.Id,
                                Title = i.Title,
                                OrderNo = i.OrderNo,
                                IsActive = i.IsActive,
                                IsDeleted = i.IsDeleted,
                                ListeningExamId = i.ListeningExamId

                            }).ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<ListeningExamSectionQueryFacadeDto> GetListeningExamSectionListForGridView(ref DataTableAjaxPostModel filters, Guid id)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.ListeningExamSections.Where(a => a.ListeningExamId == id && a.IsDeleted == false)
                                //let listeningExam = (from le in context.ListeningExams where i.ListeningExamId == le.Id select le).FirstOrDefault()
                                select new ListeningExamSectionQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    Title = i.Title,
                                    OrderNo = i.OrderNo,
                                    IsActive = i.IsActive,
                                    IsDeleted = i.IsDeleted,
                                    ListeningExamId =i.ListeningExamId// listeningExam.Id
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
