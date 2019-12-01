using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ApiSimpleApp.Commons
{
    public static class SQLHelper
    {
        public static void CloseConnection(SqlCommand cmd)
        {
            if (cmd != null)
            {
                if (cmd.Connection != null)
                {
                    cmd.Connection.Close();
                }
            }
        }

    }
}
