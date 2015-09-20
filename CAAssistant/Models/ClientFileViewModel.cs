namespace CAAssistant.Models
{
    public class ClientFileViewModel
    {

        public ClientFileViewModel()
        {
        }

        public ClientFileViewModel(ClientFile clientFile)
        {
            Id = clientFile.Id;
            FileNumber = clientFile.FileNumber;
            ClientName = clientFile.ClientName;
            ClientContactPerson = clientFile.ClientContactPerson;
            AssociateReponsible = clientFile.AssociateReponsible;
            CaSign = clientFile.CaSign;
            DscExpiryDate = clientFile.DscExpiryDate;
            FileStatus = clientFile.FileStatus;
        }

        public string Id { get; set; }

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