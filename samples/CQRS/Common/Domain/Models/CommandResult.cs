using System;

namespace Domain.Models
{
    public class CommandResult
    {
        public Guid[] EventId { get; set; }

        public string CommandName { get; set; }
    }
}
