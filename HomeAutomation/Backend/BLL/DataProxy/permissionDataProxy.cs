﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.DAL;
using Peasy.DataProxy.EF6;

namespace Backend.BLL.DataProxy
{
    public class permissionDataProxy : EF6DataProxyBase<permission, permission, int>
    {
        protected override DbContext GetDbContext()
        {
            return new HomeAutomationDbEntities();
        }
    }
}