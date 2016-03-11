using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotosStore.Domain.Entities;
using System.Data.Entity;

namespace PhotosStore.Domain.Concrete
{
<<<<<<< HEAD
    //класс контекста EF 
=======
>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
    public class EFDbContext : DbContext
    {
        public DbSet<PhotoTechnique> PhotoTechniques { get; set; }

    }
}
