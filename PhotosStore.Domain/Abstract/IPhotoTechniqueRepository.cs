using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotosStore.Domain.Entities;

namespace PhotosStore.Domain.Abstract
{
<<<<<<< HEAD
    // интерфейс репозитория техники
=======
>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
    public interface IPhotoTechniqueRepository
    {
        IEnumerable<PhotoTechnique> PhotoTechniques { get; }

        void SavePhotoTechnique(PhotoTechnique photoTechnique);

        PhotoTechnique DeletePhotoTechnique(int photoTechniqueId);

    }
}
