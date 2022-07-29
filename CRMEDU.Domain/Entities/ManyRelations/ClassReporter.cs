using CRMEDU.Domain.Entities.Courses;
using CRMEDU.Domain.Entities.Reporters;
using System;

namespace CRMEDU.Domain.Entities.ManyRelations
{
    public class ClassReporter
    {
        public long Id { get; set; }

        public Guid ReporterCode { get; set; }
        public long ClassId { get; set; }
        public Class Class { get; set; }

        public long ReporterId { get; set; }
        public Reporter Reporters { get; set; }
    }
}
