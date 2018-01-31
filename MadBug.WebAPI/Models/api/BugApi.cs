using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MadBug.WebAPI.Models.api
{
    /// <summary>
    /// Dto for create a Bug resource
    /// </summary>
    public class BugApi
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public string StepToReproduce { get; set; }
        public bool IsFixed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        [Required]
        public int Severity { get; set; }
        public UserApi CreatedBy { get; set; }
        public string CreatedById { get; set; }
        public byte[] RowVersion { get; set; }
    }
}