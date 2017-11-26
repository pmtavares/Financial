using Model.DAO;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Bus
{
    public class ClientBus
    {
        private ClientDAO objClientDao;

        public ClientBus()
        {
            objClientDao = new ClientDAO();

        }

        public void create(Client objClient)
        {
            bool verification = true;

            string Name = objClient.Name;
            if (Name == null)
            {
                objClient.Status = 20;
                return;
            }
            else
            {
                Name = objClient.Name.Trim();
                verification = Name.Length <= 30 && Name.Length > 0;
                if (!verification)
                {
                    objClient.Status = 2;
                    return;
                }

            }
            //end validar Name



            //begin validar Address retorna Status=6
            string Address = objClient.Address;
            if (Address == null)
            {
                objClient.Status = 60;
                return;
            }
            else
            {
                Address = objClient.Address.Trim();
                verification = Address.Length <= 50 && Address.Length > 0;
                if (!verification)
                {
                    objClient.Status = 6;
                    return;
                }

            }
            //end validar Address

            //begin validar Phone retorna Status=7
            string Phone = objClient.Phone;
            if (Phone == null)
            {
                objClient.Status = 70;
                return;
            }
            else
            {
                Phone = objClient.Phone.Trim();
                verification = Phone.Length <= 15 && Phone.Length > 6;
                if (!verification)
                {
                    objClient.Status = 7;
                    return;
                }

            }
            //end validar Phone

            //begin verificar duplicidade retorna Status=8
            Client objClientAux = new Client();
            objClientAux.IdClient = objClient.IdClient;
            verification = !objClientDao.find(objClientAux);
            if (!verification)
            {
                objClient.Status = 8;
                return;
            }
            //end validar duplicidade

            //begin verificar duplicidade pps retorna Status=8
            Client objClient1 = new Client();
            objClient1.Pps = objClient.Pps;
            verification = !objClientDao.findClientByPPS(objClient1);
            if (!verification)
            {
                objClient.Status = 9;
                return;
            }
            //end validar duplicidade pps

            //se nao tem erro
            objClient.Status = 99;
            objClientDao.create1(objClient);
            return;
        }

        public void update(Client objClient)
        {
            bool verification = true;
            //begin validar codigo retorna Status=1
            string codigo = objClient.IdClient.ToString();
            long id = 0;
            if (codigo == null)
            {
                objClient.Status = 10;
                return;
            }
            else
            {
                try
                {
                    id = Convert.ToInt64(objClient.IdClient);
                    verification = codigo.Length > 0 && codigo.Length < 999999; ;


                    if (!verification)
                    {
                        objClient.Status = 1;
                        return;
                    }
                }
                catch (Exception e)
                {
                    objClient.Status = 100;
                    return;
                }

            }
            //end validar codigo


            //begin validar Name retorna Status=2
            string Name = objClient.Name;
            if (Name == null)
            {
                objClient.Status = 20;
                return;
            }
            else
            {
                Name = objClient.Name.Trim();
                verification = Name.Length <= 30 && Name.Length > 0;
                if (!verification)
                {
                    objClient.Status = 2;
                    return;
                }

            }
            //end validar Name




            //begin validar endereço retorna Status=6
            string Address = objClient.Address;
            if (Address == null)
            {
                objClient.Status = 60;
                return;
            }
            else
            {
                Address = objClient.Address.Trim();
                verification = Address.Length <= 50 && Address.Length > 0;
                if (!verification)
                {
                    objClient.Status = 6;
                    return;
                }

            }
            //end validar Address

            //begin validar Phone retorna Status=7
            string Phone = objClient.Address;
            if (Phone == null)
            {
                objClient.Status = 70;
                return;
            }
            else
            {
                Phone = objClient.Phone.Trim();
                verification = Phone.Length <= 30 && Phone.Length > 0;
                if (!verification)
                {
                    objClient.Status = 7;
                    return;
                }

            }
            //end validar Phone

            //begin verificar duplicidade pps retorna Status=8
            Client objClient1 = new Client();
            objClient1.Pps = objClient.Pps;
            verification = !objClientDao.findClientByPPS(objClient1);
            if (!verification)
            {
                objClient.Status = 9;
                return;
            }
            //end validar duplicidade pps

            //se nao tem erro
            objClient.Status = 99;
            objClientDao.update(objClient);
            return;
        }

        public void delete(Client objClient)
        {
            bool verification = true;
            //verificando se existe
            Client objClientAux = new Client();
            objClientAux.IdClient = objClient.IdClient;
            verification = objClientDao.find(objClientAux);
            if (!verification)
            {
                objClient.Status = 33;
                return;
            }


            objClient.Status = 99;
            objClientDao.delete(objClient);
            return;
        }

        public bool find(Client objClient)
        {
            return objClientDao.find(objClient);
        }

        public List<Client> findAll()
        {
            return objClientDao.findAll();
        }
        public List<Client> findAllClients(Client objClient)
        {
            return objClientDao.findAllClient(objClient);
        }
    }
}
