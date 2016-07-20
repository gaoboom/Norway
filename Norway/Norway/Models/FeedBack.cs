using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Norway.Models
{
    public class FeedBack
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Contact { get; set; }
        public DateTime PostTime { get; set; }
        public bool CheckStatus { get; set; }
    }
}