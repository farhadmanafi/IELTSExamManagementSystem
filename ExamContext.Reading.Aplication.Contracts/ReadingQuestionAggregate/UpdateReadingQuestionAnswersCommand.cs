using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Aplication.Contracts.ReadingQuestionAggregate
{
   public class UpdateReadingQuestionAnswersCommand:Command
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCorrect { get; set; }

        public Guid ReadingQuestionId { get; set; }
    }
}
