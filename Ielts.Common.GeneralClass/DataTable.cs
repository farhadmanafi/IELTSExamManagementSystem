using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ielts.Common.GeneralClass
{
    public class DataTableAjaxPostModel
    {
        // properties are not capital due to json mapping
        public int draw { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public int filteredResultsCount { get; set; }
        public List<Column> columns { get; set; }
        public Search search { get; set; }
        public List<Order> order { get; set; }
        public bool localPaging { get; set; }
    }

    public class Column
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public Search search { get; set; }

        public string SaerchText
        {
            get
            {
                if (search.value != null)
                {
                    if (search.value.Contains("|to|"))
                    {
                        return null;
                    }
                    else
                    {
                        return search.value;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        public DateTime? SaerchDateFrom
        {
            get
            {
                if (search.value != null)
                {
                    if (search.value.Contains("|to|"))
                    {
                        var m = new datatableMethods();
                        var d = search.value.Replace("to|", "").Split('|');

                        var year = m.GetNumber(d[0].Substring(0, 4));
                        var month = m.GetNumber(d[0].Substring(5, 2));
                        var day = m.GetNumber(d[0].Substring(8, 2));
                        if (year == null || month == null || day == null)
                        {
                            return null;
                        }
                        //var d1 = Persia.Calendar.ConvertToGregorian((int)year, (int)month, (int)day, Persia.DateType.Gerigorian);
                        return null;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        public DateTime? SaerchDateTo
        {
            get
            {
                if (search.value != null)
                {
                    if (search.value.Contains("|to|"))
                    {
                        var m = new datatableMethods();
                        var d = search.value.Replace("to|", "").Split('|');

                        var year = m.GetNumber(d[1].Substring(0, 4));
                        var month = m.GetNumber(d[1].Substring(5, 2));
                        var day = m.GetNumber(d[1].Substring(8, 2));
                        if (year == null || month == null || day == null)
                        {
                            return null;
                        }
                        //var d1 = Persia.Calendar.ConvertToGregorian((int)year, (int)month, (int)day, Persia.DateType.Gerigorian);
                        return null;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }

    public class Search
    {
        public string value { get; set; }
        public string regex { get; set; }
    }

    public class Order
    {
        public int column { get; set; }
        public string dir { get; set; }
    }
    public class datatableMethods
    {
        public int? GetNumber(string persianNumber)
        {
            string englishNumber = "";
            foreach (char ch in persianNumber)
            {
                englishNumber += char.GetNumericValue(ch);
            }
            var R = 0;
            int.TryParse(englishNumber, out R);
            if (R == 0)
            {
                return null;
            }
            return R;
        }
    }
}
