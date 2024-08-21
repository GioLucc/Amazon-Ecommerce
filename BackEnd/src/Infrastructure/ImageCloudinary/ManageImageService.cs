namespace Ecommerce.Infrastrucure.ImageClodunary;

using System.Net;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Ecommerce.Application.Contracts.Infrastructure;
using Ecommerce.Application.Models.ImageManagement;
using Microsoft.Extensions.Options;

public class ManageImageService : IManageImageService
{
    public CloudinarySettings _cloudinarySettigs { get;}
    public ManageImageService(IOptions<CloudinarySettings> cloudinarySettigs)
    {
        _cloudinarySettigs = cloudinarySettigs.Value;
    }   

    public async Task<ImageResponse> UploadImage(ImageData imageData)
    {
        var account = new Account(
            _cloudinarySettigs.CloudName,
            _cloudinarySettigs.ApiKey,
            _cloudinarySettigs.ApiSecret
        );

        var cloudinary = new Cloudinary(account);
        var uploadImage = new ImageUploadParams()
        {
            File = new FileDescription(imageData.Name, imageData.ImageStream)
        };

        var uploadResult = await cloudinary.UploadAsync(uploadImage);

        if(uploadResult.StatusCode == HttpStatusCode.OK)
        {
            return new ImageResponse
            {
                PublicId = uploadResult.PublicId,
                Url = uploadResult.Url.ToString()
            };
        }

        throw new Exception("No se pudo guardar la imagen");
    }
}