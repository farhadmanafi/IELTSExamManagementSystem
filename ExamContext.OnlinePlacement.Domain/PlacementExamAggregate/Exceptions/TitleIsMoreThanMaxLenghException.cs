using ExamContext.OnlinePlacement.Resources;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Domain.PlacementExamAggregate.Exceptions
{
    public class TitleIsMoreThanMaxLenghException: DomainException
    {
        public override string Message => PlacementExceptionResource.TitleIsMoreThanMaxLenghException;
    }
}
