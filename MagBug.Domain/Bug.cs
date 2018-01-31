using System;
using System.ComponentModel.DataAnnotations;

namespace MagBug.Domain
{
    public class Bug
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string StepToReproduce { get; set; }
        public bool IsFixed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public Severity Severity { get; set; }
        public User CreatedBy { get; set; }
        public string CreatedById { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
