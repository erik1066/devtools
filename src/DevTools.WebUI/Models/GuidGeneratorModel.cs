using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.WebUI.Models
{
    public sealed class GuidGeneratorModel
    {
        [Required]
        [Range(1, 500_000)]
        public int NumberToGenerate { get; set; } = 1;

        public bool Uppercase { get; set; }

        public bool Braces { get; set; }

        public bool Hyphens { get; set; } = true;

        public bool Base64Encode { get; set; }

        public bool Rfc7515 { get; set; }

        public bool Urlencode { get; set; }
    }
}
