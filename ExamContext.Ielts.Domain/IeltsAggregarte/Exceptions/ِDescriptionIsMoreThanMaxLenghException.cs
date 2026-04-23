using ExamContext.Ielts.Resources;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Domain.IeltsAggregarte.Exceptions
{
    public class DescriptionIsMoreThanMaxLenghException : DomainException
    {
        public override string Message => IeltsExamExceptionResource.DescriptionIsMoreThanMaxLenghException;
    }
}
