using ExamContext.OnlinePlacement.Aplication.Contracts.PlacementExamAggregate;
using ExamContext.OnlinePlacement.Domain.Contracts.PlacementExamAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementExamAggregate;
using ExamContext.OnlinePlacement.Domain.PlacementExamAggregate.Services;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.OnlinePlacement.Aplication.PlacementExamAggregate
{
    public class AddPlacementExamPriceCommandHandler : ICommandHandler<AddPlacementExamPriceCommand>
    {
        private readonly IPlacementExamPriceRepository iPlacementExamPriceRepository;
        public AddPlacementExamPriceCommandHandler(IPlacementExamPriceRepository iPlacementExamPriceRepository)
        {
            this.iPlacementExamPriceRepository = iPlacementExamPriceRepository;
        }
        public void Execute(AddPlacementExamPriceCommand command)
        {
            var oldIeltsExam = iPlacementExamPriceRepository.GetPlacementExamPriceByExamPlacementExamPriceId(command.PlacementExamId);
            if (oldIeltsExam != null)
            {
                oldIeltsExam.DeactivedDate = DateTime.Now;
                oldIeltsExam.IsActive = false;
                iPlacementExamPriceRepository.UpdatePlacementExamPrice(oldIeltsExam);
            }
            var placementExamPriceDto = Mapper.Map<AddPlacementExamPriceCommand, PlacementExamPriceDto>(command);
            var placementExamPrice = new PlacementExamPrice(placementExamPriceDto);

            iPlacementExamPriceRepository.AddPlacementExamPrice(placementExamPrice);
        }
    }
}
