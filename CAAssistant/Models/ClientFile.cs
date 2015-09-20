using System;
using System.Collections.Generic;
using System.Globalization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CAAssistant.Models
{

    public class ClientFile
    {

        public ClientFile()
        {
        }

        //TODO: User Auto Mapper
        public ClientFile(ClientFileViewModel clientFileView)
        {
            FileNumber = clientFileView.FileNumber;
            ClientName = clientFileView.ClientName;
            ClientContactPerson = clientFileView.ClientContactPerson;
            AssociateReponsible = clientFileView.AssociateReponsible;
            CaSign = clientFileView.CaSign;
            DscExpiryDate = clientFileView.DscExpiryDate;
            FileStatus = clientFileView.FileStatus;
            FileStatusModifications.Add(clientFileView.InitialFileStatus);
        }

        #region Properties
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.Int32)]
        public int FileNumber { get; set; }

        public string ClientName { get; set; }

        public string ClientContactPerson { get; set; }

        public string AssociateReponsible { get; set; }

        public string CaSign{ get; set; }

        public string DscExpiryDate { get; set; }

        public string FileStatus { get; set; }

        public List<FileStatusModification> FileStatusModifications = new List<FileStatusModification>();
        #endregion

        #region Methods.
        public void AddFileStatus(FileStatusModification fileStatusModification)
        {
            FileStatus = fileStatusModification.NewStatus;
            fileStatusModification.ModifiedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            FileStatusModifications.Add(fileStatusModification);
        }
        #endregion

    }

}