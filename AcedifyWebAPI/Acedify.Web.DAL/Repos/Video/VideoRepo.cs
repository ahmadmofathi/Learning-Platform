using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.DAL
{
    public class VideoRepo : IVideoRepo
    {
        private readonly AppDbContext _context;

        public VideoRepo(AppDbContext context)
        {
            _context = context;
        }

        public void AddVideo(Video video)
        {
            _context.Set<Video>().Add(video);
            _context.SaveChangesAsync();
        }

        public void UpdateVideo(Video video)
        {

        }

        public bool DeleteVideo(Video video)
        {
            
                _context.Set<Video>().Remove(video);
                return true;
        }
        public Video? GetVideoById(string videoId)
        {
            return _context.Set<Video>().FirstOrDefault(c => c.Video_ID == videoId);
        }

        public IEnumerable<Video> GetAllVideos()
        {
            return _context.Set<Video>();
        }
    }
}
