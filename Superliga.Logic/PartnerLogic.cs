using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Superliga.Data;
using Superliga.Entities;

namespace Superliga.Logic
{

    public class PartnerLogic : BaseData
    {
        public string test;

        public PartnerLogic()
        {
             test = data.partner.tes2;
        }

        public String getSring()
        {
            return test;
        }

    }
}
