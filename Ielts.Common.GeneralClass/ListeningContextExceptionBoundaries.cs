using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ielts.Common.GeneralClass
{
    public static class ListeningContextExceptionBoundaries
    {
        public static int ListeningExamTitleMAXLength = 100;

        public static int TimerMinutiesMIN = 1;
        public static int TimerMinutiesMAX = 100;

        public static int ListeningQuestionTitleMAXLength = 11000;
        public static int ListeningQuestionDescriptionMAXLength = 15000;

        public static int ListeningExamSectionTitleMAXLength = 11000;
        public static int ListeningQuestionBlockTitleMAXLength = 15000;
        public static int ListeningQuestionBlockDescriptionMAXLength = 15000;

        public static int ListeningQuestionAnswerTitleMAXLength = 11000;
        public static int ListeningQuestionAnswerDescriptionMAXLength = 15000;

        public static int ListeningAnswerTextMAXLength = 11000;

        public static int ListeningExamDescriptionMAXLength = 15000;
    }
}
