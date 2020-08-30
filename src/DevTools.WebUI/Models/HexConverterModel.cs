using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.WebUI.Models
{
    public sealed class HexConverterModel
    {
        [Required]
        public string Hex { get; set; } = string.Empty;
    }
}
