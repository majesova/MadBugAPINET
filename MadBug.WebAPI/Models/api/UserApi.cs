using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MadBug.WebAPI.Models.api
{
    public class UserApi
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}