using System;
using System.Collections.Generic;
using System.Threading;
using CAAssistant.DataStore;
using CAAssistant.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CAAssistant.Tests.Models
{

    [TestClass]
    public class ClientModelTests
    {
        
        [TestMethod]
        public void CreateANewClient()
        {
            Console.WriteLine("Done");
            // Arrange
            var client = new ClientFile {
                ClientName = "Shiva", 
                FileNumber = 125
            };

            var filestatus = new FileStatusModification
            {
                OldStatus = "New",
                NewStatus = "New",
                Description = "Started",
                ModifiedBy = "Ajay"
            };
            client.AddFileStatus(filestatus);

            // Act
            var assitantContext = new CaAssistantContext();
            var clients = assitantContext.ClientFiles;
            clients.InsertOneAsync(client, CancellationToken.None).Wait();

            // Assert
            Console.WriteLine("Done");
        }

        //ObjectId("55fe911df492509964cde7fb")
        [TestMethod]
        public void ModifyExistingClient()
        {
            // Arrange

            // Act
            var assitantContext = new CaAssistantContext();
            var filter = Builders<ClientFile>.Filter.Eq("_id", new ObjectId("55fed439f49250ae44925704"));
            var clientFile = assitantContext.ClientFiles.Find(filter).FirstOrDefaultAsync().Result;
            var filestatus =new FileStatusModification
            {
                OldStatus = "Started",
                NewStatus = "Review",
                Description = "Review",
                ModifiedBy = "Ajay"
            };
            clientFile.AddFileStatus(filestatus);

            var update = Builders<ClientFile>.Update
                .Set("FileStatusModifications", clientFile.FileStatusModifications)
                .Set("FileStatus", filestatus.NewStatus);
            var result = assitantContext.ClientFiles.UpdateOneAsync(filter, update).Result;
        }

    }

}