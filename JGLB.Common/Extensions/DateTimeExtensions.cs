using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.Common
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 获取格式化字符串 yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string MyFormat(this DateTime dateTime) => dateTime.ToString(DateTimeHelper.MyDateTimeFormat);
    }
}
