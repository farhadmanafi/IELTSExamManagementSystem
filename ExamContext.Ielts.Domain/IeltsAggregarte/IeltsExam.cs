using ExamContext.Ielts.Domain.Contracts.IeltsAggregarte;
using ExamContext.Ielts.Domain.IeltsAggregarte.Exceptions;
using ExamContext.Ielts.Domain.IeltsAggregarte.Services;
using Framework.Core.Domain;
using Framework.Domain;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Domain.IeltsAggregarte
{
    public class IeltsExam : EntityBase, IAggregateRoot<IeltsExam>
    {
        public IeltsExam()
        {

        }

        public IeltsExam(IeltsExamDto dto)
        {
            //Title = dto.Title;
            TitleSetter(dto.Title);
            DescriptionSetter(dto.Description);
            //Description = dto.Description;
            UserId = dto.UserId;
            ActivedDate = dto.ActivedDate;
            DeactivedDate = dto.DeactivedDate;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }


        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public DateTime? ActivedDate { get; set; }
        public DateTime? DeactivedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<IeltsExamPrice> IeltsExamPriceList { get; set; }

        public IEnumerable<Expression<Func<IeltsExam, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }

        public void DescriptionSetter(string description)
        {
            if (description.Length > IeltsExamContextContextExceptionBoundaries.IeltsExamDescriptionMAXLength)
            {
                throw new DescriptionIsMoreThanMaxLenghException();
            }
            this.Description = description;
        }

        public void TitleSetter(string title)
        {
            if (title.Length > IeltsExamContextContextExceptionBoundaries.IeltsExamTitleMAXLength)
            {
                throw new TitleIsMoreThanMaxLenghException();
            }
            this.Title = title;
        }
    }
}
