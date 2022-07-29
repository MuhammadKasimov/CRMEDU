using System;

namespace CRMEDU.Service.DTOs.CoursesDTOs
{
    public class CourseForCreationDTO
    {
        public string Title { get; set; }

        public TimeSpan Duration { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
