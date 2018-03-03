using System;

namespace Domain.Commands
{
    public class CancelRegistration
    {
        public Guid ConferenceId { get; set; }

        public Guid RegistrationId { get; set; }

        public string Reason { get; set; }
    }
    
}
