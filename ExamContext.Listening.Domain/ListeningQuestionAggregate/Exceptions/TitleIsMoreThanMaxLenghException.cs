using ExamContext.Listening.Resources;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Domain.ListeningQuestionAggregate.Exceptions
{
    public class TitleIsMoreThanMaxLenghException: DomainException
    {
        public override string Message => ListeningExceptionResource.TitleIsMoreThanMaxLenghException;
    }
}
