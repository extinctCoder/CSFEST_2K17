using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHomeAutomation.CustomControls;
using SmartHomeAutomation.db;

namespace SmartHomeAutomation.DAL
{
    internal static class dbHandler
    {
        private static HomeAutomationDbEntities _db = new HomeAutomationDbEntities();

        public static HomeAutomationDbEntities DB
        {
            get {
                try
                {
                    dbHandler._db = dbHandler._db == null ? new HomeAutomationDbEntities() : dbHandler._db;
                    dbHandler._db.Database.Connection.Open();
                    dbHandler._db.Database.Connection.Close();
                    return dbHandler._db;
                }
                catch (Exception e)
                {
                    StatusBar.setConsoleTxt(e.Message);
                    dbHandler._db = null;
                }
                return dbHandler._db;
            }
            private set { }
        }

        public static void syncronizeDB()
        {
            dbHandler._db.SaveChanges();
        }
    }
}
