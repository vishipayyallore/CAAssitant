using System;

namespace CAAssistant.Models
{
    public class FileStatusModification
    {
        public string OldStatus { get; set; }

        public string NewStatus { get; set; }

        public string Description { get; set; }

        public string ModifiedBy { get; set; }

        public string ModifiedAt { get; set; }
    }

}