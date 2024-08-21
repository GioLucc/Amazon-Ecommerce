namespace Ecommerce.Application.Contracts.Infrastructure;
using Ecommerce.Application.Models.ImageManagement;

public interface IManageImageService
{
    Task<ImageResponse> UploadImage(ImageData imageStream);
}