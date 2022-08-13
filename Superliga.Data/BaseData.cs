using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superliga.Data
{
    public class BaseData
    {
        protected readonly SetData data;

        public BaseData()
        {
            data = new SetData();
        }
    }
}
