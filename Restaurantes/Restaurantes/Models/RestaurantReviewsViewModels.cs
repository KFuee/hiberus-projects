using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurantes.Models
{
    public class RestaurantReviewsIndexViewModel
    {
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<RestaurantReview> RestaurantReviews { get; set; }

        public RestaurantReview RestaurantReview;
    }
}