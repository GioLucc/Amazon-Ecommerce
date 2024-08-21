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
    // Class that represents the account information for upload
    public CloudinarySettings _cloudinarySettigs { get;}

    //get the settings from the cloudinary key on settings.json
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

        // After validating the account we will specify the image data to upload
        var cloudinary = new Cloudinary(account);
        var uploadImage = new ImageUploadParams()
        {
            File = new FileDescription(imageData.Name, imageData.ImageStream)
        };

        var uploadResult = await cloudinary.UploadAsync(uploadImage);

        // If everything was correct we return the instance of the class with the image data on cloudinary
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