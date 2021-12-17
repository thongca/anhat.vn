using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hfmart.Domain.Entities
{
    public class ModelBase
    {
        [Key]
        public string Id { get; set; }
    }
}
