using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Norway.Models
{
    /// <summary>
    /// 用户组
    /// <remarks>
    /// Created at 2016.08.04
    /// </remarks>
    /// </summary>
    public class UserGroup
    {
        [Key]
        public int GroupID { get; set; }

        /// <summary>
        /// 用户组名称
        /// </summary>
        [Required(ErrorMessage ="必填")]
        [StringLength(20,MinimumLength =2,ErrorMessage ="{1}到{0}个字")]
        [Display(Name ="用户组名称")]
        public string Name { get; set; }

        /// <summary>
        /// 用户组类型
        /// 0-普通类型，1-特权类型，3-管理员类型
        /// </summary>
        [Required(ErrorMessage ="必填")]
        [Display(Name ="用户组类型")]
        public int GroupType { get; set; }

        /// <summary>
        /// 用户组说明
        /// </summary>
        [Required(ErrorMessage ="必填")]
        [StringLength(20,ErrorMessage ="不得少于{0}个字")]
        [Display(Name ="用户组说明")]
        public string Description { get; set; }
    }
}