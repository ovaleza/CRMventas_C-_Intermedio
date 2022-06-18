using CRMventas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;
using CRMventas.Services;

namespace CRMventas.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientRepository clientRepository;
        private readonly IUserRepository userRepository;
        public HomeController(IClientRepository clientRepository, IUserRepository userRepository)
        {
            this.clientRepository = clientRepository;
            this.userRepository = userRepository;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult clients()
        {
            return View();
        }

        [HttpPost]
        public IActionResult clients(Client client)
        {
            if (ModelState.IsValid)
            {
                clientRepository.ClientInsert(client);
                ModelState.Clear();
                return View();
            }
            else
            {
                return View(client);
            }
        }



        public async Task<IActionResult> users()
        {
            //var usuarios = await userRepository.UserList();
            //var usuarios = await userRepository.UserList();
            Modelos modelo = new Modelos();
            modelo.Users = await userRepository.UserList(); 
            modelo.User = new User();
            //modelito.Users = usuarios;
            return View(modelo);
        }


        [HttpPost]
        public IActionResult users(Modelos modelo)
        {
            //userRepository.UserDelete(user.Id);
            //ModelState.Clear();
            //return View();
            User user = modelo.User;

            if (ModelState.IsValid)
            {
                userRepository.UserInsert(user);
                ModelState.Clear();
                return View(modelo);
            }
            else
            {
                //return View(modelo);
                return View(modelo);
            }
        }

        //[HttpPost]
        //public IActionResult users(String Id)
        //{
        //    userRepository.UserDelete(Id);
        //    ModelState.Clear();
        //    return View();
        //}

        public IActionResult tclients()
        {
            userRepository.UserList();
            return View();
        }

        [HttpPost]
        public IActionResult tclients(Tclient tclient)
        {
            if (ModelState.IsValid)
            {
                clientRepository.TclientInsert(tclient);
                ModelState.Clear();
                return View();
            }
            else
            {
                return View(tclient);
            }
        }

        public IActionResult titers()
        {
            clientRepository.titerList();
            return View();
        }

        [HttpPost]
        public IActionResult titers(Titer titer)
        {
            if (ModelState.IsValid)
            {
                clientRepository.TiterInsert(titer);
                ModelState.Clear();
                return View();
            }
            else
            {
                return View(titer);
            }
        }

        public IActionResult ttrans()
        {
            clientRepository.ttranList();
            return View();
        }

        [HttpPost]
        public IActionResult ttrans(Ttran ttran)
        {
            if (ModelState.IsValid)
            {
                clientRepository.TtranInsert(ttran);
                ModelState.Clear();
                return View();
            }
            else
            {
                return View(ttran);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
