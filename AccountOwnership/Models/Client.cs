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
        public int IdParent { get; set; }
        public long Code { get; set; }
        public string Name { get; set; }
    }
}
