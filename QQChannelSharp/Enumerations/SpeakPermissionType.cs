using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQChannelSharp.Enumerations
{
    /// <summary>
    /// 发言权限类型
    /// </summary>
    public enum SpeakPermissionType
    {
        /// <summary>
        /// 公开发言权限
        /// </summary>
        Public = 0,
        /// <summary>
        /// 指定成员可发言
        /// </summary>
        AdminAndMember = 1,
    }
}
