using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connection { get; private set; }



        public static void InitializeConnections(DatabaseType db)
        {
            if (db == DatabaseType.Sql)
            {
                //TODO: Set up SQL connector properly
                SqlConnector sql = new SqlConnector();
                Connection = sql;
            }
            else if (db == DatabaseType.TextFile) 
            {
                // TODO: Create Text File connection
                TextConnector  text = new TextConnector();
                Connection = text;
            }
        }

    public static string CnnString(string name)
    {
        return ConfigurationManager.ConnectionStrings[name].ConnectionString;
    }

    }
}
