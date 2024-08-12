using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public interface IVideoRepo
    {
        void AddVideo(Video video);

        void UpdateVideo(Video video);

        bool DeleteVideo(Video video);

        Video? GetVideoById(string videoId);

        IEnumerable<Video> GetAllVideos();
    }
}
