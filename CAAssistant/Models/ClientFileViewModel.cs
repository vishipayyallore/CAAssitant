namespace CAAssistant.Models
{
    public class ClientFileViewModel
    {

        public int FileNumber { get; set; }

        public string ClientName { get; set; }

        public string ClientContactPerson { get; set; }

        public string AssociateReponsible { get; set; }

        public string CaSign { get; set; }

        public string DscExpiryDate { get; set; }

        public string FileStatus { get; set; }

        public string UserName { get; set; }

        public FileStatusModification InitialFileStatus { get; set; }
    }

}