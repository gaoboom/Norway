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
    }
}