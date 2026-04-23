using ExamContext.OnlinePlacement.Domain.Contracts.PlacementExamAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementExamAggregate.Exceptions;
using Framework.Core.Domain;
using Framework.Domain;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.PlacementExamAggregate
{
    public class PlacementExam : EntityBase, IAggregateRoot<PlacementExam>
    {
        public PlacementExam()
        {

        }
        public PlacementExam(PlacementExamDto dto)
        {
            TitleSetter(dto.Title);
            DescriptionSetter(dto.Description);
            ActivedDate = dto.ActivedDate;
            DeActivedDate = dto.DeActivedDate;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ActivedDate { get; set; }
        public DateTime? DeActivedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public void DescriptionSetter(string description)
        {
            if (description.Length > PlacementContextExceptionBoundaries.PlacementExamDescriptionMAXLength)
            {
                throw new DescriptionIsMoreThanMaxLenghException();
            }
            this.Description = description;
        }

        public void TitleSetter(string title)
        {
            if (title.Length > PlacementContextExceptionBoundaries.PlacementExamTitleMAXLength)
            {
                throw new TitleIsMoreThanMaxLenghException();
            }
            this.Title = title;
        }

        public ICollection<PlacementExamPrice> PlacementExamPriceList { get; set; }

        public IEnumerable<Expression<Func<PlacementExam, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
