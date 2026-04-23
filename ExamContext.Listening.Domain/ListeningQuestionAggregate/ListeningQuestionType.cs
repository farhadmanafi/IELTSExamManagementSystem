using ExamContext.Listening.Domain.Contracts.ListeningQuestionAggregate;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Domain.ListeningQuestionAggregate
{
    public class ListeningQuestionType : EntityBase
    {
        public ListeningQuestionType()
        {

        }
        public ListeningQuestionType(ListeningQuestionTypeDto dto)
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

        public ICollection<ListeningQuestion> ListeningQuestionList { get; set; }


    }
}
