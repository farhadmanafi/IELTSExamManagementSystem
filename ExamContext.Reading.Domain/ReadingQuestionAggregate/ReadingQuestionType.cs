using ExamContext.Reading.Domain.Contracts.ReadingQuestionAggregate;
using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Domain.ReadingQuestionAggregate
{
    public class ReadingQuestionType : EntityBase, IAggregateRoot<ReadingQuestionType>
    {
        public ReadingQuestionType()
        {

        }
        public ReadingQuestionType(ReadingQuestionTypeDto dto)
        {
            Title = dto.Title;
            CodeName = dto.CodeName;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }

        public string Title { get; set; }
        public string CodeName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<ReadingQuestion> ReadingQuestionList { get; set; }

        public IEnumerable<System.Linq.Expressions.Expression<Func<ReadingQuestionType, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
