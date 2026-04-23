using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Aplication.Contracts.ReadingQuestionAggregate
{
    public class AddReadingQuestionTypeCommand:Command
    {
        public string Title { get; set; }
        public string CodeName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
