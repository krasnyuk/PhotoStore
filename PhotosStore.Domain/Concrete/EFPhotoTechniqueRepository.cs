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

       public void SavePhotoTechnique(PhotoTechnique photoTechnique)
       {
            if (photoTechnique.PhotoTechniqueId == 0)
                context.PhotoTechniques.Add(photoTechnique);
            else
            {
                PhotoTechnique dbEntry = context.PhotoTechniques.Find(photoTechnique.PhotoTechniqueId);
                if (dbEntry != null)
                {
                    dbEntry.Name = photoTechnique.Name;
                    dbEntry.Description = photoTechnique.Description;
                    dbEntry.Price = photoTechnique.Price;
                    dbEntry.Category = photoTechnique.Category;
                }
            }
            context.SaveChanges();
        }
    }
}
