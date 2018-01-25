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
            string create = "INSERT INTO CLIENT(name, address, phone, pps) VALUES('"+obj.Name+"','"+obj.Address+ "','"+obj.Phone+ "','"+obj.Pps+"')";

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
            string delete = "DELETE from client WHERE idclient = '"+obj.IdClient+"'";

            try
            {
                sqlCmd = new SqlCommand(delete, objConnectionDB.getCon());
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

        public bool find(Client obj)
        {
            bool hasRecords;
            string find = "SELECT * FROM client where idclient='" + obj.IdClient + "'";

            try
            {
                sqlCmd = new SqlCommand(find, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                //sqlCmd.ExecuteNonQuery(); //We dont execute this command in this case
                SqlDataReader reader = sqlCmd.ExecuteReader();
                hasRecords = reader.Read();
                if(hasRecords)
                {
                    obj.Name = reader[1].ToString();
                    obj.Address = reader[2].ToString();
                    obj.Phone = reader[3].ToString();
                    obj.Pps = reader[5].ToString();

                    obj.Status = 99;

                }
                else
                {
                    obj.Status = 1;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objConnectionDB.getCon().Close();
                objConnectionDB.closeDB();
            }
            return hasRecords;
        }

        public List<Client> findAll()
        {
            List<Client> clientList = new List<Client>();
            string findAll = "SELECT * FROM client order by name asc";

            try
            {
                sqlCmd = new SqlCommand(findAll, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                //sqlCmd.ExecuteNonQuery(); //We dont execute this command in this case
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while(reader.Read())
                {
                    Client objClient = new Client();
                    objClient.IdClient = Convert.ToInt64(reader[0].ToString());
                    objClient.Name = reader[1].ToString();
                    objClient.Address = reader[2].ToString();
                    objClient.Phone = reader[3].ToString();
                    objClient.Pps = reader[4].ToString();
                    clientList.Add(objClient);

                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objConnectionDB.getCon().Close();
                objConnectionDB.closeDB();
            }
            return clientList;
        }

        public void update(Client obj)
        {
            string update = "UPDATE client set name= '" + obj.Name + "', phone='"+obj.Phone+"', address='"+obj.Address+"', pps='"+obj.Pps+"'";

            try
            {
                sqlCmd = new SqlCommand(update, objConnectionDB.getCon());
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
        public bool findClientByPPS(Client objClient)
        {
            bool hasRecords;
            string find = "select * from Client where pps='" + objClient.Pps + "'";
            try
            {
                sqlCmd = new SqlCommand(find, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();

                SqlDataReader reader = sqlCmd.ExecuteReader();
                hasRecords = reader.Read();
                if (hasRecords)
                {
                    objClient.Name = reader[1].ToString();
                    objClient.Address = reader[2].ToString();
                    objClient.Phone = reader[3].ToString();
                    objClient.Pps = reader[4].ToString();

                    objClient.Status = 99;

                }
                else
                {
                    objClient.Status = 1;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                objConnectionDB.getCon().Close();
                objConnectionDB.closeDB();
            }
            return hasRecords;
        }

        public List<Client> findAllClient(Client objClient)
        {
            List<Client> listClients = new List<Client>();
            string findAll = "select* from Client where Name like '%" + objClient.Name + "%' or cpf like '%" + objClient.Pps + "%' or idClient like '%" + objClient.IdClient + "%' ";
            try
            {

                sqlCmd = new SqlCommand(findAll, objConnectionDB.getCon());
                objConnectionDB.getCon().Open();
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    Client clientObj = new Client();
                    objClient.IdClient = Convert.ToInt64(reader[0].ToString());
                    objClient.Name = reader[1].ToString();

                    objClient.Address = reader[2].ToString();
                    objClient.Phone = reader[3].ToString();
                    objClient.Pps = reader[4].ToString();
                    listClients.Add(objClient);

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConnectionDB.getCon().Close();
                objConnectionDB.closeDB();
            }

            return listClients;

        }
    }
}

