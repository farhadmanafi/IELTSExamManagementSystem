using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Aplication.Contracts.ListeningExamAggregate
{
    public class UpdateListeningExamSectionCommand:Command
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int OrderNo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ListeningExamId { get; set; }
    }
}
