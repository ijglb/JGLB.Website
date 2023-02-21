using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGLB.Website.Data
{
    public class ServerStatsResponse
    {
        public ServerStats[] servers { get; set; }
        public string updated { get; set; }
    }

    public class ServerStats
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        public string type { get; set; }
        public string host { get; set; }
        /// <summary>
        /// 位置描述
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 在线
        /// </summary>
        public bool online4 { get; set; }
        public bool online6 { get; set; }
        public bool ip_status { get; set; }
        /// <summary>
        /// 在线时间
        /// </summary>
        public string uptime { get; set; }
        /// <summary>
        /// 负载 1分钟
        /// </summary>
        public decimal load_1 { get; set; }
        public decimal load_5 { get; set; }
        public decimal load_15 { get; set; }
        public decimal ping_10010 { get; set; }
        public decimal ping_189 { get; set; }
        public decimal ping_10086 { get; set; }
        public long time_10010 { get; set; }
        public long time_189 { get; set; }
        public long time_10086 { get; set; }
        public long tcp_count { get; set; }
        public long udp_count { get; set; }
        public long process_count { get; set; }
        public long thread_count { get; set; }
        /// <summary>
        /// 实时网络（入）
        /// </summary>
        public long network_rx { get; set; }
        /// <summary>
        /// 实时网络（出）
        /// </summary>
        public long network_tx { get; set; }
        /// <summary>
        /// 流量（入）
        /// </summary>
        public long network_in { get; set; }
        /// <summary>
        /// 流量（出）
        /// </summary>
        public long network_out { get; set; }
        /// <summary>
        /// cpu占用
        /// </summary>
        public long cpu { get; set; }
        /// <summary>
        /// 总内存
        /// </summary>
        public long memory_total { get; set; }
        /// <summary>
        /// 已用内存
        /// </summary>
        public long memory_used { get; set; }
        /// <summary>
        /// 总swap
        /// </summary>
        public long swap_total { get; set; }
        /// <summary>
        /// 已用swap
        /// </summary>
        public long swap_used { get; set; }
        /// <summary>
        /// 硬盘总大小
        /// </summary>
        public long hdd_total { get; set; }
        /// <summary>
        /// 已用硬盘
        /// </summary>
        public long hdd_used { get; set; }
        public string custom { get; set; }

        /// <summary>
        /// 在线状态
        /// </summary>
        public bool Online => online4 || online6;

        public bool IsWin => host.StartsWith("win");
    }
}
