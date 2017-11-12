using System.Data.SqlClient;

namespace Model.DAO
{
    class ConnectionDB
    {
        private static ConnectionDB objConnectionDB = null;
        private SqlConnection con;

        //connection
        private ConnectionDB()
        {
            con = new SqlConnection("Data Source=DESKTOP-LRS8LGG\\SQLEXPRESS; Initial Catalog=DBFinancial; Integrated Security=True");
        }

        public static ConnectionDB connectionStatus()
        {
            if(objConnectionDB == null)
            {
                objConnectionDB = new ConnectionDB();
            }

            return objConnectionDB;
        }

        public SqlConnection getCon()
        {
            return con;
        }

        public void closeDB()
        {
            objConnectionDB = null;
        }

    }
}
