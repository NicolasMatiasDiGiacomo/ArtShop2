using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Data.Model
{
    public partial class Error : IdentityBase
    {

        public Error()
        {
            this.ErrorDate = DateTime.Now;
            this.ChangedOn = DateTime.Now;
            this.CreatedOn = DateTime.Now;
            this.CreatedBy = "monitor@artshop.com";
            this.ChangedBy = "monitor@artshop.com";
        }

        [MaxLength]
        public string UserId { get; set; }
        public Nullable<System.DateTime> ErrorDate { get; set; }
        [MaxLength(40)]
        public string IpAddress { get; set; }
        [MaxLength]
        public string UserAgent { get; set; }
        [MaxLength]
        public string Exception { get; set; }
        [MaxLength]
        public string Message { get; set; }
        [MaxLength]
        public string Everything { get; set; }
        [MaxLength(500)]
        public string HttpReferer { get; set; }
        [MaxLength(500)]
        public string PathAndQuery { get; set; }
    }
}