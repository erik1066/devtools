using System;
using System.ComponentModel.DataAnnotations;

namespace DevTools.WebUI.Models
{
    public sealed class RgbConverterModel
    {
        [Required]
        [Range(0, 255)]
        public int R { get; set; } = 0;

        [Required]
        [Range(0, 255)]
        public int G { get; set; } = 0;

        [Required]
        [Range(0, 255)]
        public int B { get; set; } = 0;
    }
}
