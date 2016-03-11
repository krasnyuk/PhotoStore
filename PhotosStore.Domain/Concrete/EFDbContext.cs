using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotosStore.Domain.Entities;
using System.Data.Entity;

namespace PhotosStore.Domain.Concrete
{
    //класс контекста EF 
    public class EFDbContext : DbContext
    {
        public DbSet<PhotoTechnique> PhotoTechniques { get; set; }

    }
}
