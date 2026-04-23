using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Aplication.Contracts.PlacementQuestionAggregate
{
    public class DeletePlacementQuestionTypeCommand : Command
    {
        public Guid Id { get; set; }
    }
}
