using ExamContext.Listening.Aplication.Contracts.ListeningExamAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Listening.Facade.Contracts.ListeningExamAggregate
{
    public interface IListeningExamSectionCommandFacade
    {
        void AddListeningExamSection(AddListeningExamSectionCommand command);
        void UpdateListeningExamSection(UpdateListeningExamSectionCommand command);
        void DeleteListeningExamSection(DeleteListeningExamSectionCommand command);
    }
}
