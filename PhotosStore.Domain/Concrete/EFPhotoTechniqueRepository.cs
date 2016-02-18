using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotosStore.Domain.Abstract;
using PhotosStore.Domain.Entities;

namespace PhotosStore.Domain.Concrete
{
   public class EFPhotoTechniqueRepository : IPhotoTechniqueRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<PhotoTechnique> PhotoTechniques
        {
            get { return context.PhotoTechniques; }
        }
    }
}
