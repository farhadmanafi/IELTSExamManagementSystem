using ExamContext.OnlinePlacement.Domain.Contracts.PlacementQuestionAggregate;
using Framework.Core.Domain;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.PlacementQuestionAggregate
{
    public class PlacementQuestionType : EntityBase, IAggregateRoot<PlacementQuestionType>
    {
        public PlacementQuestionType()
        {

        }
        public PlacementQuestionType(PlacementQuestionTypeDto dto)
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

        public ICollection<PlacementQuestion> PlacementQuestionList { get; set; }

        public IEnumerable<Expression<Func<PlacementQuestionType, dynamic>>> GetAggregateExpressions()
        {
            throw new NotImplementedException();
        }
    }
}
