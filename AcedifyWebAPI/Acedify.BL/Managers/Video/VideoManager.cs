using Acedify.Web.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class VideoManager : IVideoManager
    {
        private readonly IVideoRepo _videoRepo;

        public VideoManager(IVideoRepo videoRepo)
        {
            _videoRepo = videoRepo;
        }

        public string AddVideo(VideoAddDTO video)
        {
            Video newVideo = new Video
            {
                Video_ID = Guid.NewGuid().ToString(),
                Video_Title = video.Video_Title,
                Video_Description = video.Video_Description,
                Thumbnail = video.Thumbnail,
                CourseId = video.CourseId,
                Video_Path = video.Video_Path,
                Views_No = video.Views_No,
                TeacherId = video.TeacherId,

            };
            _videoRepo.AddVideo(newVideo);
            return newVideo.Video_ID;
        }

        public string UpdateVideo(VideoDTO video)
        {
            if (video.Video_ID == null)
            {
                return "Video's Id is not found";
            }
            Video videoToUpdate = _videoRepo.GetVideoById(video.Video_ID);
            if (videoToUpdate == null)
            {
                return "Video Not Found";
            }
            videoToUpdate.Video_Title = video.Video_Title;
            videoToUpdate.Video_Description = video.Video_Description;
            videoToUpdate.Thumbnail = video.Thumbnail;
            videoToUpdate.Video_Path = video.Video_Path;
            videoToUpdate.Views_No = video.Views_No;
            videoToUpdate.TeacherId = video.TeacherId;
            videoToUpdate.CourseId = video.CourseId;
            _videoRepo.UpdateVideo(videoToUpdate);
            return "Video is Updated Successfully";
        }

        public bool DeleteVideo(string videoId)
        {
            if (videoId == null)
            {
                return false;
            }
            var video = _videoRepo.GetVideoById( videoId );
            if (video == null)
            {
                return false;
            }
            _videoRepo.DeleteVideo(video);
            return true;
        }

        public VideoDTO? GetVideoById(string videoId)
        {
            Video video = _videoRepo.GetVideoById(videoId);
            if (video == null)
            {
                return null;
            }
            VideoDTO Video = new VideoDTO
            {
                Video_ID = video.Video_ID,
                Video_Title = video.Video_Title,
                Video_Description = video.Video_Description,
                Thumbnail = video.Thumbnail,
                CourseId = video.CourseId,
                Views_No = video.Views_No,
                Video_Path = video.Video_Path,
                TeacherId = video.TeacherId,
            };
            return Video;
        }

        public IEnumerable<VideoDTO> GetAllVideos()
        {
            var videos = _videoRepo.GetAllVideos();
            var allVideos = videos.Select(video => new VideoDTO
            {
                Video_ID = video.Video_ID,
                Video_Title = video.Video_Title,
                Video_Description = video.Video_Description,
                Thumbnail = video.Thumbnail,
                CourseId = video.CourseId,
                TeacherId = video.TeacherId,
                Video_Path = video.Video_Path,
                Views_No = video.Views_No,
            });
            return allVideos;
        }
    }
}
