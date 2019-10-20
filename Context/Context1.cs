using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class Context1 : DbContext
    {
        public Context1(){

        }

        public Context1(DbContextOptions<Context1> options):base(options){

        }

        public virtual DbSet<UsuarioModel> tbl_usuario { get; set; }

        //Conexão com o banco.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            if (!optionsBuilder.IsConfigured){
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; DataBase=my_api; Integrated Security=true");         
            }
        }
    }
}