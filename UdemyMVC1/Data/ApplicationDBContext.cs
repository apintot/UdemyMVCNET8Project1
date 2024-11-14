using Microsoft.EntityFrameworkCore;
using UdemyMVC1.Models;

namespace UdemyMVC1.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        //Agregar modelos 1 modelo = 1 tabla de la db
        public DbSet<Contact> Contact { get; set; }
    }
}
