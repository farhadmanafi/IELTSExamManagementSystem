using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Aplication.Contracts.ReadingExamAggregate
{
    public class DeleteReadingExamSectionCommand:Command
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int? TimerMinuties { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
