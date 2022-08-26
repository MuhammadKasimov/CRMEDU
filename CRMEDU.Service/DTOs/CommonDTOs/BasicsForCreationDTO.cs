using CRMEDU.Domain.Enums;
using System;
using System.Collections.Generic;

namespace CRMEDU.Service.DTOs.CommonDTOs
{
    public class BasicsForCreationDTO
    {
        public SecurityForCreationDTO Security { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FathersName { get; set; }
        public string Username { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual IEnumerable<CommentForCreationDTO> SentComments { get; set; }
    }
}
