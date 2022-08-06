
using System.ComponentModel.DataAnnotations;

namespace Catelog.Dtos
{
    public record CreateItemDto
    {
        [Required]
        public String? Name { get; init; }
        [Required]
        [Range(1, 100)]
        public decimal Price { get; init; }

    }
}