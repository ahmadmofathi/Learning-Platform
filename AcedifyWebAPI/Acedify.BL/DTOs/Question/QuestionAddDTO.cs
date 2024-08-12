﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acedify.Web.BL
{
    public class QuestionAddDTO
    {
        public string? Question_Title { get; set; }
        public string? Question_Description { get; set; }
        public string? Thumbnail { get; set; }
        public int QuestionScore { get; set; }
        public string[]? Choices { get; set; }
        public string? CourseId { get; set; }
        public string? Quiz_ID { get; set; }
    }
}
