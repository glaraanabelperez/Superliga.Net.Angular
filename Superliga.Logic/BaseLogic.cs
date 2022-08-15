using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superliga.Data
{
    public class BaseLogic
    {
        protected readonly BaseData base_ ;
        public BaseLogic()
        {
            base_ = new BaseData();
        }
    }
}
