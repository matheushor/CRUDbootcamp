using CRUD.Models;
using CRUD.NovaPasta3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Repositorio
{
    public class ItemRepositorio : IItemrRepositorio
    { 
        private readonly BancoContext _bancoContext;

        public ItemRepositorio(BancoContext bancoContext)
        {
        this._bancoContext = bancoContext;
        }

        public ItemModel ListaPorId(int id)
        {
            return _bancoContext.Itens.FirstOrDefault( x => x.Id == id);
        }

        public List<ItemModel> BuscarTodos()
        {
            return _bancoContext.Itens.ToList();
        }

        public ItemModel Adicionar(ItemModel item)
        {
         _bancoContext.Itens.Add(item);
         _bancoContext.SaveChanges();

        return item;

        }

        public ItemModel Atualizar(ItemModel item)
        {
            ItemModel itemDB = ListaPorId(item.Id);

            if (itemDB == null) throw new System.Exception("Houve um erro na atualização!");

            itemDB.Nome = item.Nome;
            itemDB.Codigo = item.Codigo;

            _bancoContext.Itens.Update(itemDB);
            _bancoContext.SaveChanges();

            return itemDB;
        }

        public bool Apagar(int id)
        {
            ItemModel itemDB = ListaPorId(id);

            if (itemDB == null) throw new System.Exception("Houve um erro na remoção do item!");
          
            _bancoContext.Itens.Remove(itemDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
