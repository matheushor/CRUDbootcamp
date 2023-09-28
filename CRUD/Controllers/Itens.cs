using CRUD.Models;
using CRUD.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class Itens : Controller
    {
        private readonly IItemrRepositorio _itemrRepositorio;

        public Itens(IItemrRepositorio itemrRepositorio)
        {
            _itemrRepositorio = itemrRepositorio;
        }
        public IActionResult Index()
        {
            List<ItemModel> itens = _itemrRepositorio.BuscarTodos();
            return View(itens);
        }

        public IActionResult Novo()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
           ItemModel item =  _itemrRepositorio.ListaPorId(id);
            return View(item);
        }

        public IActionResult Remover(int id)
        {
            ItemModel item = _itemrRepositorio.ListaPorId(id);
            return View(item);
        }

        public IActionResult Apagar(int id) 

        {
            _itemrRepositorio.Apagar(id);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Novo(ItemModel item) 
        {
            _itemrRepositorio.Adicionar(item);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Editar(ItemModel item)
        {
            _itemrRepositorio.Atualizar(item);
            return RedirectToAction("Index");
        }
    }
}
