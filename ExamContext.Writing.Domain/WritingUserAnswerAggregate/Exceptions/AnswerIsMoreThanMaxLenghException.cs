using ExamContext.Writing.Resources;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Writing.Domain.WritingUserAnswerAggregate.Exceptions
{
    public class AnswerIsMoreThanMaxLenghException: DomainException
    {
        public override string Message => WritingExceptionResource.AnswerIsMoreThanMaxLenghException;
    }
}
