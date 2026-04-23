using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Aplication.Contracts.WritingUserAnswerAggregate
{
    public class WritingUserAnswerCommand : Command
    {
        public IList<AddWritingUserAnswerCommand> addWritingUserAnswerCommand { get; set; }
    }
}
