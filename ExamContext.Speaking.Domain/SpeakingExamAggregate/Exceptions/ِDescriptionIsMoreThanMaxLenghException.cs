using ExamContext.Speaking.Resources;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Domain.SpeakingExamAggregate.Exceptions
{
    public class DescriptionIsMoreThanMaxLenghException : DomainException
    {
        public override string Message => SpeakingExceptionResource.DescriptionIsMoreThanMaxLenghException;
    }
}
