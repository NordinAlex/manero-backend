using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using Manero_backend;


namespace Manero_backend.DTOs.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Size field is required.")]
        public string Size { get; set; }

        [Required(ErrorMessage = "The ImageUrls field is required.")]
        public ICollection<string> ImageUrls { get; set; }

        [Required(ErrorMessage = "The Type field is required.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "The Tags field is required.")]
        public ICollection<string> Tags { get; set; }
    }
}
