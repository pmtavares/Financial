using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ClientDAO : Required<Client>
    {
        private ConnectionDB objConnectionDB;
        private SqlCommand sqlCmd;

        public ClientDAO()
        {
            objConnectionDB = ConnectionDB.connectionStatus();
            
        }

        public void create1(Client obj)
        {
            string create = "INSERT INTO CLIENT(name, address, phone, pps) VALUES('"+obj.Name+",'"+obj.Address+ ",'"+obj.Phone+ ",'"+obj.Pps+"')";

            try
            {
                sqlCmd = new SqlCommand(create, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                obj.Status = 1;
            }
            finally
            {
                objConnectionDB.getCon().Close();
                objConnectionDB.closeDB();
            }
        }
        public void create(Client obj)
        {
            string create = "sp_client_add" + obj.Name + "," + obj.Address + "," + obj.Phone + ","+ obj.Pps;

            try
            {
                sqlCmd = new SqlCommand(create, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                obj.Status = 1;
            }
            finally
            {
                objConnectionDB.getCon().Close();
                objConnectionDB.closeDB();
            }
        }

        public void delete(Client obj)
        {
            throw new NotImplementedException();
        }

        public bool find(Client obj)
        {
            throw new NotImplementedException();
        }

        public List<Client> findAll()
        {
            throw new NotImplementedException();
        }

        public void update(Client obj)
        {
            throw new NotImplementedException();
        }
    }
}
