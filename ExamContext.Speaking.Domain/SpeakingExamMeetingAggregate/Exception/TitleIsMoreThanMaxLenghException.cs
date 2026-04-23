using ExamContext.Speaking.Resources;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Speaking.Domain.SpeakingExamMeetingAggregate.Exceptions
{
    public class TitleIsMoreThanMaxLenghException: DomainException
    {
        public override string Message => SpeakingExceptionResource.TitleIsMoreThanMaxLenghException;
    }
}
