using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace APIDers1.Service.DTOs
{
    public record CategoryPostDto
    {
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        [NotNull]
        public string  Name { get; set; }
    }
}
