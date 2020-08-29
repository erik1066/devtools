using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.WebUI.Models
{
    public sealed class Base64EncodingModel
    {
        [Required]
        public string Input { get; set; } = string.Empty;

        public string Output { get; set; } = string.Empty;
    }
}
