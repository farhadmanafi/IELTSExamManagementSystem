using ExamContext.OnlinePlacement.Domain.Contracts.PlacementExamAggregate;
using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.PlacementExamAggregate
{
    public class PlacementExamPrice : EntityBase, IAggregateRoot<PlacementExamPrice>
    {
        public PlacementExamPrice()
        {

        }
        public PlacementExamPrice(PlacementExamPriceDto dto)
        {
            PlacementExamId = dto.PlacementExamId;
            PriceAmount = dto.PriceAmount;
            DiscontentAmount = dto.DiscontentAmount;
            ActivedDate = dto.ActivedDate;
            DeactivedDate = dto.DeactivedDate;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }
        public long PriceAmount { get; set; }
        public int? DiscontentAmount { get; set; }
        public DateTime? ActivedDate { get; set; }
        public DateTime? DeactivedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Guid PlacementExamId { get; set; }
        [ForeignKey("PlacementExamId")]
        public PlacementExam PlacementExamCurrent { get; set; }

        public IEnumerable<Expression<Func<PlacementExamPrice, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
