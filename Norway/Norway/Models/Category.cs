using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Norway.Models
{
    /// <summary>
    /// 栏目模型类
    /// </summary>
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        /// <summary>
        /// 栏目类型
        /// </summary>
        [Required(ErrorMessage ="{0}必填")]
        [Display(Name ="栏目类型")]
        public CategoryType Type { get; set; }

        /// <summary>
        /// 父栏目ID
        /// </summary>
        [Required(ErrorMessage ="必填")]
        [Display(Name ="父栏目")]
        public int ParentID { get; set; }

        /// <summary>
        /// 深度【表示栏目所在的层次，根栏目为0，以此类推】
        /// </summary>
        [Required()]
        [Display(Name ="栏目深度")]
        public int Depth { get; set; }

        /// <summary>
        /// 栏目名称
        /// </summary>
        [Required(ErrorMessage ="{0}必填")]
        [StringLength(50,ErrorMessage ="不得多于{0}个字")]
        [Display(Name ="栏目名称")]
        public string Name { get; set; }

        /// <summary>
        /// 栏目说明
        /// </summary>
        [DataType(DataType.MultilineText)]
        [StringLength(1000,ErrorMessage ="不得多于{0}个字")]
        [Display(Name ="栏目说明")]
        public string Description { get; set; }

        /// <summary>
        /// 栏目顺序【同级栏目数字越小越靠前】
        /// </summary>
        [Display(Name ="栏目顺序")]
        public int Order { get; set; }

        /// <summary>
        /// 打开方式
        /// </summary>
        [Display(Name ="打开方式")]
        public string Target { get; set; }
    }
}