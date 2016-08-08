using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Norway.Models
{
    /// <summary>
    /// 用户配置
    /// <remarks>
    /// Created at 2016.08.07
    /// </remarks>
    /// </summary>
    public class UserConfig
    {
        [Key]
        public int ConfigID { get; set; }

        /// <summary>
        /// 禁止使用的用户名
        /// 用户名之间用“|”隔开
        /// </summary>
        [Display(Name = "禁止使用的用户名")]
        public string ProhibitUserName { get; set; }

        /// <summary>
        /// 启用管理员验证
        /// </summary>
        [Display(Name = "启用管理员验证")]
        [Required(ErrorMessage = "必填")]
        public bool EnableAdminVerify { get; set; }

        /// <summary>
        /// 启用邮件验证
        /// </summary>
        [Display(Name = "启用邮件验证")]
        [Required(ErrorMessage = "必填")]
        public bool EnableEmailVerify { get; set; }

        /// <summary>
        /// 默认用户组Id
        /// </summary>
        [Display(Name = "默认用户组Id")]
        [Required(ErrorMessage = "必填")]
        public int DefaultGroupId { get; set; }
    }
}