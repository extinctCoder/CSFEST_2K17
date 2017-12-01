using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.DAL;
using Peasy.DataProxy.EF6;

namespace Backend.BLL.DataProxy
{
    public class switch_conditionDataProxy : EF6DataProxyBase<switch_condition, switch_condition, long>
    {
        protected override DbContext GetDbContext()
        {
            return new HomeAutomationDbEntities();
        }
    }
}
