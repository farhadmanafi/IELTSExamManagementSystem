using ExamContext.Listening.Resources;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Domain.ListeningUserAnswerAggregate.Exceptions
{
    public class AnswerIsMoreThanMaxLenghException: DomainException
    {
        public override string Message => ListeningExceptionResource.AnswerIsMoreThanMaxLenghException;
    }
}
