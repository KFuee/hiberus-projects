using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurantes.Models
{
    public class RestaurantReview
    {
        public long RestaurantReviewId { get; set; }

        [Range(1, 10)]
        public int Rating { get; set; }

        [Required]
        public string Body { get; set; }

        public string ReviewerName { get; set; } = "Anónimo";

        public long RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}