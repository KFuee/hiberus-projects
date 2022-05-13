using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurantes.Models
{
    public class Restaurant
    {
        public long RestaurantId { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string City { get; set; }

        [Required]
        [MaxLength(30)]
        public string Country { get; set; }

        public virtual ICollection<RestaurantReview> RestaurantReviews { get; set; }
    }
}