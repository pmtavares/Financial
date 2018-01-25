using Model.Bus;
using Model.Entity;
using Model.Neg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialSystem.Controllers
{
    public class ClientController : Controller
    {

        ClientBus objClientBus;

        public ClientController()
        {
            objClientBus = new ClientBus();
        }
        //Show Clients
        public ActionResult Index()
        {
            List<Client> list = objClientBus.findAll();
            return View(list);
        }


        // GET: Client
        //public ActionResult Index()
       // {
           // return View();
        //}

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            MessageBeginRegister();
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Client objClient)
        {
            MessageBeginRegister();
            objClientBus.create(objClient);
            ErrorMessageRegister(objClient);
            ModelState.Clear();
            return View("Create");
            
        }


        public void ErrorMessageRegister(Client objClient)
        {
            switch (objClient.Status)
            {
                case 1000://campo cpf com letras
                    ViewBag.MessageErro = "Erro PPS, não insira Letras";
                    break;

                case 20://campo nome vazio
                    ViewBag.MessageErro = "Insira Name of Client";
                    break;

                case 2://erro de nome
                    ViewBag.MessageErro = "O nome não pode ter mais de 30 caracteres";
                    break;

                case 50://campo cpf vazio
                    ViewBag.MessageErro = "Insira PPS do Client";
                    break;

                case 60://endereco vazio
                    ViewBag.MessageErro = "Insira endereço do Client";
                    break;

                case 6://erro no endereço
                    ViewBag.MessageErro = "Campo endereço não pode ter mais de 50 caracteres";
                    break;

                case 70://campo telefone vazio
                    ViewBag.MessageErro = "Insira o telefone do Client";
                    break;


                case 8://erro de duplicidade
                    ViewBag.MessageErro = "Client [" + objClient.IdClient + "] já está registrado no sistema";
                    break;

                case 9://erro de duplicidade
                    ViewBag.MessageErro = "Numero de PPS [" + objClient.Pps + "] já está registrado no sistema";
                    break;

                case 99://Cliente Salvo com Sucesso
                    ViewBag.MessageExit = "Client [" + objClient.Name + "] foi inserido no sistema";
                    break;
            }

        }

        public void MessageBeginRegister()
        {
            ViewBag.MessageBegin = "Insira os dados do Client e clique em salvar";
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
