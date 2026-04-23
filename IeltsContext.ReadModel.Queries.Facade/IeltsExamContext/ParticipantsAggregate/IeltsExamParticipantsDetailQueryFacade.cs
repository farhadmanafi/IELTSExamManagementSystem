using ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.ParticipantsAggregate.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.ReadModel.Queries.Facade.IeltsExamContext.ParticipantsAggregate
{
    public class IeltsExamParticipantsDetailQueryFacade : IIeltsExamParticipantsDetailQueryFacade
    {
        public IeltsExamParticipantsDetailQueryFacadeDto GetIeltsExamParticipantsDetailById(Guid id)
        {
            using (var context = new ExamContextReadModelDBContext())
            {
                return (from i in context.IeltsExamParticipantsDetails.Where(f => f.Id == id)
                        select new IeltsExamParticipantsDetailQueryFacadeDto()
                        {
                            Id = i.Id,
                            ListeningExamId = i.ListeningExamId,
                            ListeningExamIsGive = i.ListeningExamIsGive,
                            ListeningExamStartDateTime = i.ListeningExamStartDateTime,
                            ListeningExamEndDateTime = i.ListeningExamEndDateTime,
                            ListeningExamRegisterDateTime = i.ListeningExamRegisterDateTime,
                            ReadingExamId = i.ReadingExamId,
                            ReadingExamIsGive = i.ReadingExamIsGive,
                            ReadingExamStartDateTime = i.ReadingExamStartDateTime,
                            ReadingExamEndDateTime = i.ReadingExamEndDateTime,
                            ReadingExamRegisterDateTime = i.ReadingExamRegisterDateTime,
                            WritingExamId = i.WritingExamId,
                            WritingExamIsGive = i.WritingExamIsGive,
                            WritingExamStartDateTime = i.WritingExamStartDateTime,
                            WritingExamEndDateTime = i.WritingExamEndDateTime,
                            WritingExamRegisterDateTime = i.WritingExamRegisterDateTime,
                            SpeakingExamId = i.SpeakingExamId,
                            SpeakingExamIsSetSession = i.SpeakingExamIsSetSession,
                            IeltsExamParticipantsId = i.IeltsExamParticipantsId,
                        }).FirstOrDefault();
            }
        }

        public IeltsExamParticipantsDetailQueryFacadeDto GetIeltsExamParticipantsDetailByIeltsExamParticipantsId(Guid ieltsExamParticipantsId)
        {
            using (var context = new ExamContextReadModelDBContext())
            {
                return (from i in context.IeltsExamParticipantsDetails.Where(f => f.IeltsExamParticipantsId == ieltsExamParticipantsId)
                        select new IeltsExamParticipantsDetailQueryFacadeDto()
                        {
                            Id = i.Id,
                            ListeningExamId = i.ListeningExamId,
                            ListeningExamIsGive = i.ListeningExamIsGive,
                            ListeningExamStartDateTime = i.ListeningExamStartDateTime,
                            ListeningExamEndDateTime = i.ListeningExamEndDateTime,
                            ListeningExamRegisterDateTime = i.ListeningExamRegisterDateTime,
                            ReadingExamId = i.ReadingExamId,
                            ReadingExamIsGive = i.ReadingExamIsGive,
                            ReadingExamStartDateTime = i.ReadingExamStartDateTime,
                            ReadingExamEndDateTime = i.ReadingExamEndDateTime,
                            ReadingExamRegisterDateTime = i.ReadingExamRegisterDateTime,
                            WritingExamId = i.WritingExamId,
                            WritingExamIsGive = i.WritingExamIsGive,
                            WritingExamStartDateTime = i.WritingExamStartDateTime,
                            WritingExamEndDateTime = i.WritingExamEndDateTime,
                            WritingExamRegisterDateTime = i.WritingExamRegisterDateTime,
                            SpeakingExamId = i.SpeakingExamId,
                            SpeakingExamIsSetSession = i.SpeakingExamIsSetSession,
                            IeltsExamParticipantsId = i.IeltsExamParticipantsId,
                        }).FirstOrDefault();
            }
        }
    }
}
