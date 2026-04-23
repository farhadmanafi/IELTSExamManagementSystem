using ExamContext.Ielts.Domain.Contracts.ParticipantsAggregate;
using Framework.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamContext.Ielts.Domain.ParticipantsAggregate
{
    public class IeltsExamParticipantsStatus : EntityBase
    {
        public IeltsExamParticipantsStatus()
        {

        }
        public IeltsExamParticipantsStatus(IeltsExamParticipantsStatusDto dto)
        {
            Title = dto.Title;
            IsActive = dto.IsActive;
            IsDeleted = dto.IsDeleted;
        }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<IeltsExamParticipants> IeltsExamParticipantsList { get; set; }

    }
}
