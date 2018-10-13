using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JusticePack.CapetalOne.BusinessLogic.Models
{
    public class AppSettingPutRp
    {
        [Required]
        public string Value { get; set; }
    }
}
