using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superliga.Entities;

namespace Superliga.Data
{
    public class SetData
    {
        public Partner partner { get; set; }

        public SetData()
        {
             partner= new Partner();
        }
    }
}
