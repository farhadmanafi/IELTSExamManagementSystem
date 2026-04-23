using ExamContext.Ielts.Aplication.Contracts.IeltsAggregarte;
using ExamContext.Ielts.Domain.Contracts.IeltsAggregarte;
using ExamContext.Ielts.Domain.IeltsAggregarte;
using ExamContext.Ielts.Domain.IeltsAggregarte.Services;
using Framework.Application;
using Framework.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Aplication.IeltsAggregarte
{
    public class UpdateIeltsExamCommandHandler : ICommandHandler<UpdateIeltsExamCommand>
    {
        private readonly IIelitsRepository ielitsRepository;
        public UpdateIeltsExamCommandHandler(IIelitsRepository ielitsRepository)
        {
            this.ielitsRepository = ielitsRepository;
        }
        public void Execute(UpdateIeltsExamCommand command)
        {
            var ieltsExam = ielitsRepository.GetIeltsExam(command.Id);
            //Changest
            ieltsExam.TitleSetter(command.Title);
            ieltsExam.DescriptionSetter(command.Description);
            ieltsExam.ActivedDate = command.ActivedDate;
            ieltsExam.DeactivedDate = command.DeactivedDate;
            ieltsExam.IsActive = command.IsActive;
            ieltsExam.IsDeleted = command.IsDeleted;

            ielitsRepository.UpdateIeltsExam(ieltsExam);
            //var ieltsExamDto = Mapper.Map<UpdateIeltsExamCommand, IeltsExamDto>(command);
            //var newIeltsExam = new IeltsExam(ieltsExamDto);
            //ielitsRepository.AddIeltsExam(newIeltsExam);
        }
    }
}
