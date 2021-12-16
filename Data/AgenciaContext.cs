using AgenciaViagemUp.Models;
using Microsoft.EntityFrameworkCore;

namespace AgenciaViagemUp.Data
{
    public class AgenciaContext : DbContext {
        public AgenciaContext(DbContextOptions<AgenciaContext> opt) : base(opt) {

        }

        public DbSet<ClienteModel> ClienteModel {get;set;}
        public DbSet<DestinoModel> DestinoModel { get; set; }
        public DbSet<PassagemModel> PassagemModel { get; set; }
    }
}
