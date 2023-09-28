using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Repositorio
{
    public interface IItemrRepositorio
    {
        ItemModel ListaPorId(int id);
        List<ItemModel> BuscarTodos();
        ItemModel Adicionar(ItemModel item);
        ItemModel Atualizar(ItemModel item);
        bool Apagar(int id);
    }
}
