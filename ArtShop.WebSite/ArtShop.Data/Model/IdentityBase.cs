using System;
using System.ComponentModel.DataAnnotations;
//Se requiere el DataAnnotations para agregar el tipo de campo.

namespace ArtShop.Data.Model
{
    public class IdentityBase
    {
        //Aqui los campos Key y Required definen el tipo de campo. 
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [MaxLength(50)]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime ChangedOn { get; set; }
        [MaxLength(50)]
        public string ChangedBy { get; set; }
    }
}