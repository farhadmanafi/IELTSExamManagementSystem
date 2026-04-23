using ExamContext.OnlinePlacement.Resources;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.PlacementUserAnswerAggregate.Exceptions
{
    public class AnswerIsMoreThanMaxLenghException: DomainException
    {
        public override string Message => PlacementExceptionResource.AnswerIsMoreThanMaxLenghException;
    }
}
