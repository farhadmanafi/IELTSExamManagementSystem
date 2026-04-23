using ExamContext.Ielts.Domain.Contracts.IeltsAggregarte;
using ExamContext.Ielts.Domain.IeltsAggregarte.Services;
using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Domain.IeltsAggregarte
{
    public class IeltsExamPrice : EntityBase, IAggregateRoot<IeltsExamPrice>
    {
        public IeltsExamPrice()
        {

        }
        public IeltsExamPrice(IeltsExamPriceDto dto)
        {
            IeltsExamId = dto.IeltsExamId;
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

        public Guid IeltsExamId { get; set; }
        [ForeignKey("IeltsExamId")]
        public IeltsExam IeltsExamCurrent { get; set; }

        public IEnumerable<System.Linq.Expressions.Expression<Func<IeltsExamPrice, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
