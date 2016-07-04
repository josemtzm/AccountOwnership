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
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public Client Client { get; set; }
        [Required]
        public Employee EVP { get; set; }
        [Required]
        public Employee SVP { get; set; }
        [Required]
        public Employee VP { get; set; }
        [Required]
        public Employee ED { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        //[Required]
        public Employee POC { get; set; }
        [Required]
        public DateTime LastModifiedDate { get; set; }
        [Required]
        public DateTime GoLiveDate { get; set; }
        [Required]
        public DateTime CloseDate { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
