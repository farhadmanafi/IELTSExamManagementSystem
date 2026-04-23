using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ielts.Common.GeneralClass
{
    public static class BankTransactionTypeList
    {
        /// <summary>
        /// ارسال به بانک
        /// </summary>
        public readonly static Guid SendToBank = new Guid("7cf8ebd6-bc99-4480-b2b5-5e174c0e9c1b");
        /// <summary>
        /// پرداخت موفق
        /// </summary>
        public readonly static Guid SucsessTransaction = new Guid("2b12443a-8738-4f14-90a0-65afcb37c846");
        /// <summary>
        /// پرداخت ناموفق
        /// </summary>
        public readonly static Guid ErrorTransaction = new Guid("145b0f01-daa8-4bd9-9817-89099980f8a4");
        /// <summary>
        /// منتظر ارسال پاسخ بانک
        /// </summary>
        public readonly static Guid NotResponseBank = new Guid("1b574b13-77c7-4564-a72d-bac015fd594d");
    }
}
