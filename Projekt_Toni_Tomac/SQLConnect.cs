using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Projekt_Toni_Tomac
{
    public static class SQLConnect
    {
        public static SqlConnection Connection()
        {
            return new SqlConnection(@"Data Source=DESKTOP-86Q4JNC;Initial Catalog=master;Integrated Security=True");
        }
    }
}
  