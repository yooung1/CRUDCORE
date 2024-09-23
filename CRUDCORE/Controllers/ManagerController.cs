using CRUDCORE.DataBase;
using CRUDCORE.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDCORE.Controllers
{
    public class ManagerController : Controller
    {
        ContatoDados ContatoDados = new ContatoDados();
        public IActionResult Listar()
        {
            var objLista = ContatoDados.Listar();
            return View(objLista);
        }

        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ContatoModel objContato)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var resposta = ContatoDados.Guardar(objContato);
            if(resposta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int IdContato)
        {
            var objContato = ContatoDados.Obter(IdContato);
            return View(objContato);
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel objContato)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var resposta = ContatoDados.Editar(objContato);
            if (resposta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int IdContato)
        {
            var objContato = ContatoDados.Obter(IdContato);
            return View(objContato);
        }

        [HttpPost]
        public IActionResult Eliminar(ContatoModel objContato)
        {
            var resposta = ContatoDados.Eliminar(objContato.IdContato);
            if (resposta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
