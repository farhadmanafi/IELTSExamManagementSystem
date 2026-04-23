using ExamContext.Reading.Resources;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Domain.ReadingQuestionAggregate.Exceptions
{
    public class TimerExceededValidLengthException : DomainException
    {
        public override string Message => ReadingExceptionResource.TimerExceededValidLengthException;
    }
}
