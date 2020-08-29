using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.WebUI.Models
{
    public sealed class JsonPathModel
    {
        [Required]
        [MinLength(1)]
        public string Input { get; set; } = string.Empty;

        public string Output { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        public string JsonPath { get; set; } = string.Empty;
    }
}
