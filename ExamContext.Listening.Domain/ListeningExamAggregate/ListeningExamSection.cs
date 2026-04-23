using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamContext.Listening.Domain.Contracts.ListeningExamAggregate;
using ExamContext.Listening.Domain.ListeningExamAggregate.Exceptions;
using Framework.Core.Domain;
using Framework.Domain;
using Ielts.Common.GeneralClass;

namespace ExamContext.Listening.Domain.ListeningExamAggregate
{
    public class ListeningExamSection : EntityBase, IAggregateRoot<ListeningExamSection>
    {
        public ListeningExamSection()
        {

        }
        public ListeningExamSection(ListeningExamSectionDto dto)
        {
            TitleSetter(dto.Title);
            ListeningExamId = dto.ListeningExamId;
            OrderNo = dto.OrderNo;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }

        public string Title { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public Guid ListeningExamId { get; set; }
        [ForeignKey("ListeningExamId")]
        public ListeningExam CurrentListeningExam { get; set; }
        public ICollection<ListeningExamQuestionBlock> ListeningExamQuestionBlockList { get; set; }

        public void TitleSetter(string title)
        {
            if (title.Length > ListeningContextExceptionBoundaries.ListeningExamSectionTitleMAXLength)
            {
                throw new TitleIsMoreThanMaxLenghException();
            }
            this.Title = title;
        }

        public IEnumerable<System.Linq.Expressions.Expression<Func<ListeningExamSection, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
