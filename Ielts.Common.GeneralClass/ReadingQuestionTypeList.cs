using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ielts.Common.GeneralClass
{
    public static class ReadingQuestionTypeList
    {
        public readonly static Guid CheckBox = new Guid("173EA7FA-0942-4CED-A66C-3F48BE65CC13");
        public readonly static Guid RadioButton = new Guid("D8F00147-E0D4-4A1C-8FB0-693F1B686E7B");
        public readonly static Guid ComboBox = new Guid("69B16751-40D5-4AD3-AD0A-AD3FED73569C");
        public readonly static Guid TextArea = new Guid("94520E4E-6171-4501-B253-B4A372AEDEC9");
        public readonly static Guid TextBox = new Guid("C35AD5FB-0379-4DAF-B30A-F60EA6CD279A");
    }
}
