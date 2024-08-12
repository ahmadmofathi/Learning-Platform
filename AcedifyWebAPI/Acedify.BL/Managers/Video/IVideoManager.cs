using Acedify.Web.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public interface IVideoManager
    {
        string AddVideo(VideoAddDTO video);

        string UpdateVideo(VideoDTO video);

        bool DeleteVideo(string videoId);

        VideoDTO? GetVideoById(string videoId);

        IEnumerable<VideoDTO> GetAllVideos();
    }
}
