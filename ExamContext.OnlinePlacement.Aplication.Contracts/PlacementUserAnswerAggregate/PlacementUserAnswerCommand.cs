using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementUserScoreAggregate;
using Framework.Core.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Aplication.Contracts.PlacementUserAnswerAggregate
{
    public class PlacementUserAnswerCommand : Command
    {
        public IList<AddPlacementUserAnswerCommand> addPlacementUserAnswerList { get; set; }
        public AddPlacementUserScoreCommand addPlacementUserScoreCommand { get; set; }
    }
}
