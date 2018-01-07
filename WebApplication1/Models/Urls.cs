using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Urls
    {
        public int ID { get; set; }
        [Display(Name = "网址")]
        public string href { get; set; }
        [Display(Name = "内容")]
        public string text { get; set; }
        [Display(Name = "状态")]
        public string status { get; set; }
        [Display(Name = "排序")]
        public string sortId { get; set; }
        [Display(Name = "分类")]
        public string catalog { get; set; }

    }
}
