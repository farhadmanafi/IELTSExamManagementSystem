using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Aplication.Contracts.ReadingUserAnswerAggregate
{
    public class ReadingUserAnswerCommand : Command
    {
        public IList<AddReadingUserAnswerCommand> addReadingUserAnswerCommand { get; set; }
    }
}
