using System;
using System.Collections.Generic;

#nullable disable

namespace ExamContext.ReadModel.Context.Models.ExamContextReadModelDBContext
{
    public partial class ListeningQuestionType
    {
        public ListeningQuestionType()
        {
            ListeningQuestions = new HashSet<ListeningQuestion>();
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string CodeName { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual ICollection<ListeningQuestion> ListeningQuestions { get; set; }
    }
}
