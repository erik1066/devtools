using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevTools.WebUI.Models
{
    public sealed class FileEncryptionModel
    {
        [Required]
        [MinLength(1)]
        [MaxLength(128)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        [MaxLength(128)]
        public string InitVector { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        [MaxLength(128)]
        public string Salt { get; set; } = string.Empty;
    }
}
