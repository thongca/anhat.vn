using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hfmart.Domain.Request
{
    public class SearchBase
    {
        public int page { get; set; }
        public int pagesize { get; set; }
    }
}
