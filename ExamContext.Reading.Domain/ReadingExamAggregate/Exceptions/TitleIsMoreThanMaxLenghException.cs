using ExamContext.Reading.Resources;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Reading.Domain.ReadingExamAggregate.Exceptions
{
    public class TitleIsMoreThanMaxLenghException: DomainException
    {
        public override string Message => ReadingExceptionResource.TitleIsMoreThanMaxLenghException;
    }
}
