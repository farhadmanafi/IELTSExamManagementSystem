using ExamContext.Ielts.Domain.Contracts.ResualtAggregarte;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Domain.ResualtAggregarte
{
    public class IeltsResualtLevel : EntityBase
    {
        public IeltsResualtLevel()
        {

        }
        public IeltsResualtLevel(IeltsResualtLevelDto dto)
        {
            Title = dto.Title;
            OrderNo = dto.OrderNo;
            Description = dto.Description;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }
        public string Title { get; set; }
        public int OrderNo { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<UserResualt> UserResualtList { get; set; }


    }
}
