using Acedify.Web.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acedify.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IVideoManager _videoManager;
        public VideosController(IVideoManager videoManager)
        {
            _videoManager = videoManager;
        }

        [HttpGet]
        public ActionResult GetAllVideos()
        {
            return Ok(_videoManager.GetAllVideos());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetVideo(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_videoManager.GetVideoById(id));
        }

        [HttpPost]
        public ActionResult AddVideo(VideoAddDTO video)
        {
            if (video == null)
            {
                return BadRequest("Video is Null");
            }
            return Ok(_videoManager.AddVideo(video));
        }
        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateVideo(string id, VideoDTO video)
        {
            if (id == null)
            {
                return BadRequest("Id is null");
            }
            return Ok(_videoManager.UpdateVideo(video));
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteVideo(string id)
        {
            if (id == null)
            {
                return BadRequest("Id is not found");
            }
            return Ok(_videoManager.DeleteVideo(id));
        }
    }
}
