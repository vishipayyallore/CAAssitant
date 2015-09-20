using System;
using System.Collections.Generic;
using System.Globalization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CAAssistant.Models
{

    public class ClientFile
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.Int32)]
        public int FileNumber { get; set; }

        public string ClientName { get; set; }

        public string ClientContactPerson { get; set; }

        public string AssociateReponsible { get; set; }

        public string CaSign{ get; set; }

        public string DscExpired { get; set; }

        public string FileStatus { get; set; }

        public List<FileStatusModification> FileStatusModifications = new List<FileStatusModification>();

        public void AddFileStatus(FileStatusModification fileStatusModification)
        {
            FileStatus = fileStatusModification.NewStatus;
            fileStatusModification.ModifiedAt = DateTime.Now.ToString(CultureInfo.InvariantCulture);
            FileStatusModifications.Add(fileStatusModification);
        }
    }

}