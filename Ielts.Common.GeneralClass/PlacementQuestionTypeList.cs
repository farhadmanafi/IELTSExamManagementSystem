using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ielts.Common.GeneralClass
{
    public static class PlacementQuestionTypeList
    {
        public readonly static Guid CheckBox = new Guid("C9A9A822-8019-4E39-ADB7-3B2BB64D0A2C");
        public readonly static Guid RadioButton = new Guid("11E10751-9DDB-48D2-9E59-5810891FF2E7");
        public readonly static Guid ComboBox = new Guid("87338316-1ab6-4e04-8184-6adb625383a5");
        public readonly static Guid TextArea = new Guid("93315763-7c2f-4efe-9264-843a2cb8ffdc");
        public readonly static Guid TextBox = new Guid("C3CAC2C4-D7F3-4CC4-8C0B-994EEA9EBF26");
    }
}