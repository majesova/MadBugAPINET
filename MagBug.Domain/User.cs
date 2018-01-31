using System;

namespace MagBug.Domain
{
    public class User
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
