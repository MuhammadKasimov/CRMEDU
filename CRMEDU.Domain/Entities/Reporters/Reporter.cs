using CRMEDU.Domain.Commons;
using CRMEDU.Domain.Entities.Students;
using CRMEDU.Domain.Enums;
using System;

namespace CRMEDU.Domain.Entities.Reporters
{
    public class Reporter : Auditable
    {
        public long StudentId { get; set; }
        public Student Student { get; set; }
        public Muster Muster { get; set; }
        public Guid ReporterCode { get; set; }
    }
}