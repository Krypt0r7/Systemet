using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemetAPI.Models
{
    public class SystemetService
    {
        public static List<SysSortTable> GetAllProd()
        {
            var context = new VRContext();

            return context.SysSortTable.ToList();
        }
    }
}
