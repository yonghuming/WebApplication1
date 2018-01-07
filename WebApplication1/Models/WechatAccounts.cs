using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class WechatAccounts
    {
        public int ID { get; set; }

        [Display(Name="微信公众号名称")]
        public string wechatName { get; set; }
    }
}
