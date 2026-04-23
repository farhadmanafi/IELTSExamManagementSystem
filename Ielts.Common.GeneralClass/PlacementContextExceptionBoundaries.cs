using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ielts.Common.GeneralClass
{
    public static class PlacementContextExceptionBoundaries
    {
        public static int PlacementExamTitleMAXLength = 11000;
        public static int PlacementExamDescriptionMAXLength = 15000;

        public static int TimerMinutiesMIN = 1;
        public static int TimerMinutiesMAX = 100;

        public static int PlacementQuestionTitleMAXLength = 11000;
        public static int PlacementQuestionDescriptionMAXLength = 15000;

        public static int PlacementQuestionBlockTitleMAXLength = 11000;
        public static int PlacementQuestionBlockDescriptionMAXLength = 15000;

        public static int PlacementQuestionAnswerTitleMAXLength = 11000;
        public static int PlacementQuestionAnswerDescriptionMAXLength = 15000;

        public static int PlacementAnswerTextMAXLength = 11000;
    }
}
