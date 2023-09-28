
using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.NovaPasta3
{
    public class BancoContext : DbContext
    {
       public BancoContext(DbContextOptions<BancoContext> options) : base(options) 
       { 
       }

        public DbSet<ItemModel> Itens { get; set; }
    }
}
