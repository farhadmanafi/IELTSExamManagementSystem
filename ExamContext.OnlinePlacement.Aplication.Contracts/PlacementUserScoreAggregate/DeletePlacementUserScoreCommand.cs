using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Aplication.Contracts.PlacementUserScoreAggregate
{
    public class DeletePlacementUserScoreCommand : Command
    {
        public Guid Id { get; set; }
    }
}
