using CRMEDU.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRMEDU.Domain.Commons
{
    public class Basics
    {
        public long Id { get; set; }
        public long SecurityId { get; set; }
        public Security Security { get; set; }

        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        [MaxLength(30)]
        public string Username { get; set; }

        [MaxLength(30)]
        public string FathersName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public ICollection<Comment> GotComments { get; set; }
    }
}