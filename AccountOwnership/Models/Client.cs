using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountOwnership.Models
{
    public class Client
    {
        public int Id { get; set; }
        public Client Parent{ get; set; }
        public string Name { get; set; }
        public string GL_CLT_CD { get; set; }
        public bool Active { get; set; }
    }
}
