using MoPetCo.BusinessLogic.Extensions;
using MoPetCo.Models;
using static System.Net.Mime.MediaTypeNames;


namespace MoPetCo.BusinessLogic
{
    public class Media : Interfaces.IMedia
    {
        private readonly DataAccess.Interfaces.IMedia? media;
        private readonly FileHelper _fileHelper;
        public Media(DataAccess.Interfaces.IMedia? media, FileHelper fileHelper = null)
        {
            this.media = media;
            _fileHelper = fileHelper;
        }

        public async Task<Response<Imagen>> GuardarImagenAsync(Imagen img)
        {
            string nameFile = Path.GetFileNameWithoutExtension(img.DataImagen.FileName); Stream image = img.DataImagen.OpenReadStream();
            string urlimagen = await _fileHelper.UploadFile(image, nameFile);

            if (string.IsNullOrEmpty(urlimagen))
                return new Response<Imagen> { Message = "Error al subir la imagen", IsSuccess = false };

            //agregamos la url que nos devolvio el metodo SubirArchivo
            img.UrlImagen = urlimagen;

            if (string.IsNullOrWhiteSpace(img.Descripcion))
                img.Descripcion = nameFile;

            return await media.GuardarImagenAsync(img);
        }

        public Task<Response<IEnumerable<Imagen>>> ObtenerImagenesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
