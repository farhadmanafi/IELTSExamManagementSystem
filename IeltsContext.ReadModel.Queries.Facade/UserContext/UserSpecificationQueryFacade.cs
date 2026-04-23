using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.UserContext;
using ExamContext.ReadModel.Queries.Contracts.UserContext.DataContracts;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ExamContext.ReadModel.Queries.Facade.UserContext
{
    public class UserSpecificationQueryFacade : IUserSpecificationQueryFacade
    {
        public IList<UserSpecificationQueryFacadeDto> GetUserSpecification(ref DataTableAjaxPostModel filters)
        {
            try
            {
                var titleSerach = filters.columns?.Where(a => a.SaerchText != null).FirstOrDefault()?.SaerchText;

                var titleSerach_ByName = filters.columns?.Where(v => v.data.ToLower() == "title")?.FirstOrDefault()?.SaerchText;

                using (var context = new ExamContextReadModelDBContext())
                {
                    var data = (from i in context.AspUsers.Where(a => a.Email != "admin@admin.com")
                                select new UserSpecificationQueryFacadeDto()
                                {
                                    Id = i.Id,
                                    FirstName = i.FirstName,
                                    LastName = i.LastName,
                                    UserName = i.UserName,
                                    MobileNumber = i.MobileNumber, 
                                    Email = i.Email
                                });

                    var Result = data.Where(v =>
                                (titleSerach == null ||
                                (titleSerach != null && (v.UserName.Contains(titleSerach.ToString()) ||
                                                                      v.MobileNumber.Contains(titleSerach.ToString()) ||
                                                                      v.FirstName.Contains(titleSerach.ToString()) ||
                                                                      v.LastName.Contains(titleSerach.ToString()) ||
                                                                      v.Email.Contains(titleSerach.ToString()))
                                                                      ))).AsQueryable();

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
    }
}
