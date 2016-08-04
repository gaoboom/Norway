using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Norway.Models
{
    /// <summary>
    /// 用户模型类
    /// <remarks>
    /// Created at 2016.08.03
    /// </remarks>
    /// </summary>
    public class User
    {
        [Key]
        public int UserID { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage ="必填")]
        [StringLength(20,MinimumLength =4,ErrorMessage ="{1}到{0}个字符")]
        [Display(Name ="用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 用户组ID
        /// </summary>
        [Required(ErrorMessage ="必填")]
        [Display(Name ="用户组ID")]
        public int GroupID { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        [Required(ErrorMessage ="必填")]
        [StringLength(20,MinimumLength =4,ErrorMessage = "{1}到{0}个字符")]
        [Display(Name ="用户昵称")]
        public string NickName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage ="必填")]
        [StringLength(20,MinimumLength =6,ErrorMessage = "{1}到{0}个字符")]
        [DataType(DataType.Password)]
        [Display(Name ="密码")]
        public string Password { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Required(ErrorMessage ="必填")]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="邮箱")]
        public string Email { get; set; }

        /// <summary>
        /// 用户状态
        /// 0-正常，1-锁定，2-未通过邮件验证，3-未通过管理员验证
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegistTime { get; set; }

        /// <summary>
        /// 上次登录时间
        /// </summary>
        public DateTime LoginTime { get; set; }

        /// <summary>
        /// 上次登录IP
        /// </summary>
        public string LoginIP { get; set; }

        public virtual UserGroup Group { get; set; }
    }
}