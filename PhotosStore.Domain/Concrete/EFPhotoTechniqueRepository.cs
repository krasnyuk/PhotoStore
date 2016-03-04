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
        EFDbContext _context = new EFDbContext();

        public IEnumerable<PhotoTechnique> PhotoTechniques
        {
            get { return _context.PhotoTechniques; }
        }

       public void SavePhotoTechnique(PhotoTechnique photoTechnique)
       {
            if (photoTechnique.PhotoTechniqueId == 0)
                _context.PhotoTechniques.Add(photoTechnique);
            else
            {
                PhotoTechnique dbEntry = _context.PhotoTechniques.Find(photoTechnique.PhotoTechniqueId);
                if (dbEntry != null)
                {
                    dbEntry.Name = photoTechnique.Name;
                    dbEntry.Description = photoTechnique.Description;
                    dbEntry.Price = photoTechnique.Price;
                    dbEntry.Category = photoTechnique.Category;
                    dbEntry.ImageData = photoTechnique.ImageData;
                    dbEntry.ImageMimeType = photoTechnique.ImageMimeType;
                }
            }
            _context.SaveChanges();
        }

       public PhotoTechnique DeletePhotoTechnique(int photoTechniqueId)
       {
            PhotoTechnique dbEntry = _context.PhotoTechniques.Find(photoTechniqueId);
            if (dbEntry != null)
            {
                _context.PhotoTechniques.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
