﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Data.Model
{
    class CartItem : IdentityBase
    {
        [Required]
        public int CartId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}