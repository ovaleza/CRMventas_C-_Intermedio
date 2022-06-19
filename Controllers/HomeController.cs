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
        private readonly ITranRepository tranRepository;
        public HomeController(IClientRepository clientRepository, IUserRepository userRepository, ITranRepository tranRepository)
        {
            this.clientRepository   = clientRepository;
            this.userRepository     = userRepository;
            this.tranRepository     = tranRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult reports()
        {
            return View();
        }
        public async Task<IActionResult> iteractions()      // PARA INSERTAR LA TABLA DE TODOS LOS REGISTROS EN LA VISTA
        {
            Iteraction modelo = new Iteraction();
            modelo.Iteractions = await tranRepository.IterList();
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> iteractions(Iteraction modelo)
        {
            if (ModelState.IsValid)
            {
                tranRepository.IterInsert(modelo);
                ModelState.Clear();
                modelo = new Iteraction();
            }
            modelo.Iteractions = await tranRepository.IterList();
            return View(modelo);
        }

        public async Task<IActionResult> transactions()      // PARA INSERTAR LA TABLA DE TODOS LOS REGISTROS EN LA VISTA
        {
            Transaction modelo = new Transaction();
            modelo.Transactions = await tranRepository.TranList();
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> transactions(Transaction modelo)
        {
            if (ModelState.IsValid)
            {
                tranRepository.TranInsert(modelo);
                ModelState.Clear();
                modelo = new Transaction();
            }
            modelo.Transactions = await tranRepository.TranList();
            return View(modelo);
        }

        public async Task<IActionResult> clients()      // PARA INSERTAR LA TABLA DE TODOS LOS REGISTROS EN LA VISTA
        {
            Client modelo = new Client();
            modelo.Clients = await clientRepository.ClientList();
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> clients(Client modelo)
        {
            if (ModelState.IsValid)
            {
                clientRepository.ClientInsert(modelo);
                ModelState.Clear();
                modelo = new Client();
            }
            modelo.Clients= await clientRepository.ClientList();
            return View(modelo);
        }

        public async Task<IActionResult> users()      // PARA INSERTAR LA TABLA DE TODOS LOS REGISTROS EN LA VISTA
        {
            User modelo = new User();
            modelo.Users = await userRepository.UserList(); 
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> users(User modelo)
        {
            if (ModelState.IsValid)
            {
                userRepository.UserInsert(modelo);
                ModelState.Clear();
                modelo = new User();
            }
            modelo.Users = await userRepository.UserList();
            return View(modelo);
        }

        public async Task<IActionResult> tclients() 
        {
            Tclient modelo = new Tclient();
            modelo.Tclients = await clientRepository.TclientList();
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> tclients(Tclient modelo)
        {
            if (ModelState.IsValid)
            {
                clientRepository.TclientInsert(modelo);
                ModelState.Clear();
                modelo = new Tclient();
            }
            modelo.Tclients = await clientRepository.TclientList();
            return View(modelo);

        }

        public async Task<IActionResult> titers()
        {
            Titer modelo = new Titer();
            modelo.Titers = await clientRepository.TiterList();
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> titers(Titer modelo)
        {
            if (ModelState.IsValid)
            {
                clientRepository.TiterInsert(modelo);
                ModelState.Clear();
                modelo = new Titer();
            }
            modelo.Titers = await clientRepository.TiterList();
            return View(modelo);
        }

        public async Task<IActionResult> ttrans()
        {
            Ttran modelo = new Ttran();
            modelo.Ttrans = await clientRepository.TtranList();
            return View(modelo);
        }

        [HttpPost]
        public async Task<IActionResult> ttrans(Ttran modelo)
        {
            if (ModelState.IsValid)
            {
                clientRepository.TtranInsert(modelo);
                ModelState.Clear();
                modelo = new Ttran();
            }
            modelo.Ttrans = await clientRepository.TtranList();
            return View(modelo);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
