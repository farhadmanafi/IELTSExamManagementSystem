using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserScoreAggregate;
using ExamContext.ReadModel.Queries.Contracts.OnlinePlacementContext.PlacementUserScoreAggregate.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.OnlinePlacementContext.PlacementUserScoreAggregate
{
    public class PlacementUserScoreQueryFacade : IPlacementUserScoreQueryFacade
    {
        public PlacementUserScoreQueryFacadeDto GetPlacementUserScore(Guid placementUserScoreId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.PlacementUserScores.Where(a => a.Id == placementUserScoreId)
                            select new PlacementUserScoreQueryFacadeDto()
                            {
                                Id = i.Id,
                                PlacementExamId = i.PlacementExamId,
                                CustomerId = i.CustomerId,
                                LevelScoreId = i.LevelScoreId,
                                ExamDate = i.ExamDate,
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

        public IEnumerable<PlacementUserScoreQueryFacadeDto> GetPlacementUserScoreList(ref DataTableAjaxPostModel filters)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    //var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                    var data = (from i in context.PlacementUserScores
                                let placementExam = (from p in context.PlacementExams where i.PlacementExamId == p.Id select p).FirstOrDefault()
                                let user = (from us in context.AspUsers where i.CustomerId.ToString() == us.Id select us).FirstOrDefault()
                                  let level = (from l in context.LevelScores where i.LevelScoreId == l.Id select l).FirstOrDefault()
                                  select new PlacementUserScoreQueryFacadeDto()
                                  {
                                      Id = i.Id,
                                      PlacementExamId = i.PlacementExamId,
                                      PlacementExamTitle = placementExam.Title,
                                      CustomerId = i.CustomerId,
                                      UserName = user.UserName,
                                      LevelScoreId = i.LevelScoreId,
                                      LevelScoreName = level.Title,
                                      ExamDate = i.ExamDate,
                                      IsActive = i.IsActive,
                                      IsDeleted = i.IsDeleted

                                  });
                    var Result = data;
                    //var Result = data.ToList().Where(v =>
                    //            (titleSerach_ByName == null ||
                    //            (titleSerach_ByName != null && (v.UserId.Contains(titleSerach_ByName.ToString()))))).AsQueryable();

                    filters.filteredResultsCount = data.Count();

                    var sort = (filters.order != null ? filters.columns[filters.order[0].column].data : "") + " " + (filters.order != null ? filters.order[0].dir.ToLower() : "");
                    sort = sort == "examDate_Persian desc" ? "examDate desc" : sort;
                    sort = sort == "examDate_Persian asc" ? "examDate asc" : sort;

                    Result = Result.OrderBy(sort).Skip(filters.start).Take(filters.length);

                    var ResultFinal = Result.ToList();
                    ResultFinal.ToList().ForEach(a => a.ExamDate_Persian = DateConverter.MiladiToShamsiConvert(a.ExamDate, true));
                    return ResultFinal.ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<PlacementUserScoreQueryFacadeDto> GetPlacementUserScoreByIdList(ref DataTableAjaxPostModel filters, Guid onlinePlacemenId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    //var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                    var data = (from i in context.PlacementUserScores.Where(a=> a.PlacementExamId == onlinePlacemenId)
                                let placementExam = (from p in context.PlacementExams where i.PlacementExamId == p.Id select p).FirstOrDefault()
                                let user = (from us in context.AspUsers where i.CustomerId.ToString() == us.Id select us).FirstOrDefault()
                                  let level = (from l in context.LevelScores where i.LevelScoreId == l.Id select l).FirstOrDefault()
                                  select new PlacementUserScoreQueryFacadeDto()
                                  {
                                      Id = i.Id,
                                      PlacementExamId = i.PlacementExamId,
                                      PlacementExamTitle = placementExam.Title,
                                      CustomerId = i.CustomerId,
                                      UserName = user.UserName,
                                      LevelScoreId = i.LevelScoreId,
                                      LevelScoreName = level.Title,
                                      ExamDate = i.ExamDate,
                                      IsActive = i.IsActive,
                                      IsDeleted = i.IsDeleted

                                  });
                    var Result = data;
                    //var Result = data.ToList().Where(v =>
                    //            (titleSerach_ByName == null ||
                    //            (titleSerach_ByName != null && (v.UserId.Contains(titleSerach_ByName.ToString()))))).AsQueryable();

                    filters.filteredResultsCount = data.Count();

                    var sort = (filters.order != null ? filters.columns[filters.order[0].column].data : "") + " " + (filters.order != null ? filters.order[0].dir.ToLower() : "");
                    sort = sort == "examDate_Persian desc" ? "examDate desc" : sort;
                    sort = sort == "examDate_Persian asc" ? "examDate asc" : sort;

                    Result = Result.OrderBy(sort).Skip(filters.start).Take(filters.length);

                    var ResultFinal = Result.ToList();
                    ResultFinal.ToList().ForEach(a => a.ExamDate_Persian = DateConverter.MiladiToShamsiConvert(a.ExamDate, true));
                    return ResultFinal.ToList();
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public PlacementUserScoreQueryFacadeDto GetPlacementUserScoreByCustomer(Guid customerId, Guid placementExamId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    return (from i in context.PlacementUserScores.Where(a => a.CustomerId == customerId && a.PlacementExamId == placementExamId)
                            select new PlacementUserScoreQueryFacadeDto()
                            {
                                Id = i.Id,
                                PlacementExamId = i.PlacementExamId,
                                CustomerId = i.CustomerId,
                                LevelScoreId = i.LevelScoreId,
                                ExamDate = i.ExamDate,
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

        public IEnumerable<PlacementUserScoreQueryFacadeDto> GetPlacementUserScoreByCustomerIdList(ref DataTableAjaxPostModel filters, Guid customerId)
        {
            try
            {
                using (var context = new ExamContextReadModelDBContext())
                {
                    //var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                    var data = (from i in context.PlacementUserScores.Where(a=> a.CustomerId == customerId)
                                  let placementExam = (from p in context.PlacementExams where i.PlacementExamId == p.Id select p).FirstOrDefault()
                                  let user = (from us in context.AspUsers where i.CustomerId.ToString() == us.Id select us).FirstOrDefault()
                                  let level = (from l in context.LevelScores where i.LevelScoreId == l.Id select l).FirstOrDefault()
                                  select new PlacementUserScoreQueryFacadeDto()
                                  {
                                      Id = i.Id,
                                      PlacementExamId = i.PlacementExamId,
                                      PlacementExamTitle = placementExam.Title,
                                      CustomerId = i.CustomerId,
                                      UserName = user.UserName,
                                      LevelScoreId = i.LevelScoreId,
                                      LevelScoreName = level.Title,
                                      ExamDate = i.ExamDate,
                                      IsActive = i.IsActive,
                                      IsDeleted = i.IsDeleted

                                  });
                    var Result = data;
                    //var Result = data.ToList().Where(v =>
                    //            (titleSerach_ByName == null ||
                    //            (titleSerach_ByName != null && (v.UserId.Contains(titleSerach_ByName.ToString()))))).AsQueryable();

                    filters.filteredResultsCount = data.Count();

                    var sort = (filters.order != null ? filters.columns[filters.order[0].column].data : "") + " " + (filters.order != null ? filters.order[0].dir.ToLower() : "");
                    sort = sort == "examDate_Persian desc" ? "examDate desc" : sort;
                    sort = sort == "examDate_Persian asc" ? "examDate asc" : sort;

                    Result = Result.OrderBy(sort).Skip(filters.start).Take(filters.length);

                    var ResultFinal = Result.ToList();
                    ResultFinal.ToList().ForEach(a => a.ExamDate_Persian = DateConverter.MiladiToShamsiConvert(a.ExamDate,true));
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
