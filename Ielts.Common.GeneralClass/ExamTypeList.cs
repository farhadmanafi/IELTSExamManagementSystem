using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ielts.Common.GeneralClass
{
    public static class ExamTypeList
    {
        /// <summary>
        /// آزمون تعیین سطح
        /// </summary>
        public readonly static Guid OnlinePlacement = new Guid("59f5ff6e-930e-4d19-8805-807eb44aed09");
        /// <summary>
        /// آزمون آیلتس
        /// </summary>
        public readonly static Guid IeltsExam = new Guid("e3e055ac-1ccd-489d-bad6-14f1321e6b1e");
    }
}
