using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.Common
{
    /// <summary>
    /// 日期时间处理
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// 固定Format yyyy-MM-dd HH:mm:ss
        /// </summary>
        public static readonly string MyDateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        /// <summary>
        /// 获取Unix时间戳 10位 到秒
        /// </summary>
        /// <returns></returns>
        public static long GetUnixTimeSeconds() => GetUnixTimeSeconds(DateTime.UtcNow);
        /// <summary>
        /// 获取指定时间的Unix时间戳 10位 到秒
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long GetUnixTimeSeconds(DateTime dateTime) => new DateTimeOffset(dateTime).ToUnixTimeSeconds();
        /// <summary>
        /// 获取Unix时间戳 13位 到毫秒
        /// </summary>
        /// <returns></returns>
        public static long GetUnixTimeMilliseconds() => GetUnixTimeMilliseconds(DateTime.UtcNow);
        /// <summary>
        /// 获取指定时间的Unix时间戳 13位 到毫秒
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long GetUnixTimeMilliseconds(DateTime dateTime) => new DateTimeOffset(dateTime).ToUnixTimeMilliseconds();
        /// <summary>
        /// 10位Unix时间戳转DateTime
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime FromUnixTimeSeconds(long timestamp) => DateTimeOffset.FromUnixTimeSeconds(timestamp).LocalDateTime;
        /// <summary>
        /// 13位Unix时间戳转DateTime
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime FromUnixTimeMilliseconds(long timestamp) => DateTimeOffset.FromUnixTimeMilliseconds(timestamp).LocalDateTime;
        
    }
}
