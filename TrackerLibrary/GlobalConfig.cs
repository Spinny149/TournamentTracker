using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

        public static void InitializeConnections(bool datbase, bool textFiles)
        {
            if (datbase)
            {
                //TODO: Set up SQL connector properly
                SqlConnector sql = new SqlConnector();
                Connections.Add(sql);
            }

            if(textFiles) 
            {
                // TODO: Create Text File connection
                TextConnector  text = new TextConnector();
                Connections.Add(text);
            }
        }
    }
}
