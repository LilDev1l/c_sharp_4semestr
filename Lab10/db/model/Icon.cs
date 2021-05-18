using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10.db.model
{
    public class Icon
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public byte[] Photo { get; set; }
    }
}
