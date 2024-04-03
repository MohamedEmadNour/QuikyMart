using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuikyMart.Data.Entites
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
