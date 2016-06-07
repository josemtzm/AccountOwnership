using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountOwnership.Models
{
    public class Record
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        // Foreign Key
        //public int EVPId { get; set; }
        // Navigation property
        public Employee EVP { get; set; }
        // Foreign Key
        //public int SVPId { get; set; }
        // Navigation property
        public Employee SVP { get; set; }
        // Foreign Key
        //public int VPId { get; set; }
        // Navigation property
        public Employee VP { get; set; }
        // Foreign Key
        //public int EDId { get; set; }
        // Navigation property
        public Employee ED { get; set; }
        //[Required]
        public string GL_CLT_CD { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        //[Required]
        public string POC { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }
        [Required]
        public DateTime GoLiveDate { get; set; }
        [Required]
        public DateTime CloseDate { get; set; }
        // Foreign Key
        //public int StatusId { get; set; }
        // Navigation property
        [Required]
        public Status Status { get; set; }
    }
}
