using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ielts.Common.GeneralClass
{
    public static class ReadingContextExceptionBoundaries
    {
        public static int ReadingExamTitleMAXLength = 100;

        public static int TimerMinutiesMIN = 1;
        public static int TimerMinutiesMAX = 100;

        public static int ReadingQuestionTitleMAXLength = 11000;
        public static int ReadingQuestionDescriptionMAXLength = 15000;

        public static int ReadingExamSectionTitleMAXLength = 11000;

        public static int ReadingQuestionBlockTitleMAXLength = 11000;
        public static int ReadingQuestionBlockDescriptionMAXLength = 15000;

        public static int ReadingQuestionAnswerTitleMAXLength = 11000;
        public static int ReadingQuestionAnswerDescriptionMAXLength = 15000;

        public static int ReadingAnswerTextMAXLength = 11000;
        public static int ReadingExamDescriptionMAXLength = 15000;
    }
}
