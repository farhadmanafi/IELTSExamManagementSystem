using ExamContext.Listening.Resources;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Domain.ListeningQuestionAggregate.Exceptions
{
    public class DescriptionIsMoreThanMaxLenghException : DomainException
    {
        public override string Message => ListeningExceptionResource.DescriptionIsMoreThanMaxLenghException;
    }
}
