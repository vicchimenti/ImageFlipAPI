using System.Threading.Tasks;
using ImageFlipAPI.Handler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ImageFlipAPI.Controllers
{
    [Route("api/image")]
    public class ImagesController : Controller
    {
        private readonly IImageHandler _imageHandler;

        public ImagesController(IImageHandler imageHandler)
        {
            _imageHandler = imageHandler;
        }
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}