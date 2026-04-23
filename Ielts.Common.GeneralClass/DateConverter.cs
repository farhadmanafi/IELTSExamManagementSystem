using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ielts.Common.GeneralClass
{
    public static class DateConverter
    {
        public static string MiladiToShamsiConvert(DateTime? d = null, bool? isShowClock = false)
        {
            if (d == null)
                return "";

            DateTime datevalue = (Convert.ToDateTime(d.ToString()));
            if (datevalue.Year < 1700)
                return string.Format("{0}/{1}/{2}", datevalue.Year, datevalue.Month, datevalue.Day);

            PersianCalendar pc = new PersianCalendar();
            if (isShowClock == true)
                return string.Format("{0}/{1}/{2} {3}:{4}", pc.GetYear((DateTime)d), pc.GetMonth((DateTime)d), pc.GetDayOfMonth((DateTime)d), datevalue.Hour, datevalue.Minute);
            else
                return string.Format("{0}/{1}/{2}", pc.GetYear((DateTime)d), pc.GetMonth((DateTime)d), pc.GetDayOfMonth((DateTime)d));
        }

        public static DateTime ShamsiToMiladiConvert(string datePersian)
        {
            if (datePersian == null)
                return DateTime.Now;

            var _datePersian = datePersian.Split('/');
            DateTime georgianDateTime = new DateTime(int.Parse(_datePersian[0]), int.Parse(_datePersian[1]), int.Parse(_datePersian[2]), new System.Globalization.PersianCalendar());
            return georgianDateTime;
        }

    }
}
