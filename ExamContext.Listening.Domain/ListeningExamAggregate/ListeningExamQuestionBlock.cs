using ExamContext.Listening.Domain.Contracts.ListeningExamAggregate;
using ExamContext.Listening.Domain.ListeningExamAggregate.Exceptions;
using Framework.Core.Domain;
using Framework.Domain;
using Ielts.Common.GeneralClass;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Domain.ListeningExamAggregate
{
    public class ListeningExamQuestionBlock : EntityBase, IAggregateRoot<ListeningExamQuestionBlock>
    {
        public ListeningExamQuestionBlock()
        {

        }
        public ListeningExamQuestionBlock(ListeningExamQuesionBlockDto dto)
        {
            ListeningExamSectionId = dto.ListeningExamSectionId;
            TitleSetter(dto.Title);
            OrderNo = dto.OrderNo;
            DescriptionSetter(dto.Description);
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }


        public Guid ListeningExamSectionId { get; set; }
        [ForeignKey("ListeningExamSectionId")]
        public ListeningExamSection CurrentListeningExamSection { get; set; }

        public string Title { get; set; }
        public int OrderNo { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }


        public void DescriptionSetter(string description)
        {
            //if (description.Length > ListeningContextExceptionBoundaries.ListeningQuestionBlockDescriptionMAXLength)
            //{
            //    throw new DescriptionIsMoreThanMaxLenghException();
            //}
            this.Description = description;
        }

        public void TitleSetter(string title)
        {
            if (title.Length > ListeningContextExceptionBoundaries.ListeningQuestionBlockTitleMAXLength)
            {
                throw new TitleIsMoreThanMaxLenghException();
            }
            this.Title = title;
        }
        public IEnumerable<Expression<Func<ListeningExamQuestionBlock, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
