

using TaskSharedWpf.Interfaces;

namespace TaskSharedWpf.Models
{
    public class Contact 
    {
       
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public Guid guid { get; set; }= Guid.NewGuid();

    }
}
