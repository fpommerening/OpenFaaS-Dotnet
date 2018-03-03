using System;

namespace Domain.Commands
{
    public class NewRegistration
    {
        public Guid ConferenceId { get; set; }

        public string Name { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public string Company { get; set; }
    }
}
