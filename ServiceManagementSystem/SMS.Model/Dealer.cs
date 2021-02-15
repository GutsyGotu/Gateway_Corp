using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBS.Model
{
    public class Dealer
    {
        public int Id { get; set; }
        public string DealerNo { get; set; }
        public string  Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }           
    }
}
