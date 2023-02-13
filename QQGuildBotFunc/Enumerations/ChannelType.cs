﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQGuildBotFunc.Enumerations
{
    /// <summary>
    /// 频道类型
    /// </summary>
    public enum ChannelType
    {
        /// <summary>
        /// 文字子频道
        /// </summary>
        Text = 0,
        /// <summary>
        /// 语音子频道
        /// </summary>
        Voice = 2,
        /// <summary>
        /// 子频道分组
        /// </summary>
        Category = 4,
        /// <summary>
        /// 直播子频道
        /// </summary>
        Live = 10005,
        /// <summary>
        /// 应用子频道
        /// </summary>
        Application = 10006,
        /// <summary>
        /// 论坛子频道
        /// </summary>
        Forum = 10007
    }
}
