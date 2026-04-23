using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Aplication.Contracts.ListeningUserAnswerAggregate
{
    public class ListeningUserAnswerCommand : Command
    {
        public IList<AddListeningUserAnswerCommand> addListeningUserAnswerCommand { get; set; }
    }
}
