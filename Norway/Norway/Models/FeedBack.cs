using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Norway.Models
{
    public class FeedBack
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Please Enter Your Name !")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please Enter A Title !")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Please Enter The Content !")]
        public string Content { get; set; }

        public string Contact { get; set; }
        public DateTime PostTime { get; set; }
        public bool CheckStatus { get; set; }
    }
}