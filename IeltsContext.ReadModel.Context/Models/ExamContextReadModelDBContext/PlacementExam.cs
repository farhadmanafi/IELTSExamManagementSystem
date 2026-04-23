using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class PlacementExam
    {
        public PlacementExam()
        {
            PlacementExamPrices = new HashSet<PlacementExamPrice>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ActivedDate { get; set; }
        public DateTime? DeActivedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual ICollection<PlacementExamPrice> PlacementExamPrices { get; set; }
    }
}
