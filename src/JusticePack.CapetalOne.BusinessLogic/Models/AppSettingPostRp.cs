using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JusticePack.CapetalOne.BusinessLogic.Models
{
    public class AppSettingPostRp
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
