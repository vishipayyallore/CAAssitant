using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAAssistant.DataStore;
using CAAssistant.Models;
using Microsoft.AspNet.Identity;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CAAssistant.Controllers
{
    public class ClientFilesController : Controller
    {
        
        private readonly CaAssistantContext _assistantContext = new CaAssistantContext();

        // GET: ClientFiles
        public ActionResult Index()
        {
            var filter = Builders<ClientFile>.Filter.Exists("_id");
            var clientFilesList = _assistantContext.ClientFiles.FindAsync(filter).Result.ToListAsync().Result;
            return View(clientFilesList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClientFileViewModel clientFileView)
        {
            clientFileView.UserName = User.Identity.GetUserName();
            clientFileView.InitialFileStatus = new FileStatusModification
            {
                OldStatus = "New",
                NewStatus = "New",
                Description = "Started",
                ModifiedBy = clientFileView.UserName
            };

            var clientFile = new ClientFile(clientFileView);

            _assistantContext.ClientFiles.InsertOneAsync(clientFile).Wait();

            return RedirectToAction("Index");
        }

        
        public ActionResult Details(string id)
        {
            var clientFile = GetClientFile(id);
            return View(clientFile);
        }

        private ClientFile GetClientFile(string id)
        {
            var filter = Builders<ClientFile>.Filter.Eq("_id", new ObjectId(id));
            var clientFile = _assistantContext.ClientFiles.Find(filter).FirstOrDefaultAsync().Result;
            return clientFile;
        }

        public ActionResult Edit(string id)
        {
            var clientFile = GetClientFile(id);
            var clientFileView = new ClientFileViewModel(clientFile);
            return View(clientFileView);
        }

        [HttpPost]
        public ActionResult Edit(ClientFileViewModel clientFileView)
        {
            var filter = Builders<ClientFile>.Filter.Eq("_id", new ObjectId(clientFileView.Id));
            var clientFile = _assistantContext.ClientFiles.Find(filter).FirstOrDefaultAsync().Result;
            clientFileView.UserName = User.Identity.GetUserName();

            var filestatus = new FileStatusModification
            {
                OldStatus = clientFile.FileStatus,
                NewStatus = clientFileView.FileStatus,
                Description = "Review",
                ModifiedBy = clientFileView.UserName
            };
            clientFile.AddFileStatus(filestatus);

            var update = Builders<ClientFile>.Update
                .Set("FileStatusModifications", clientFile.FileStatusModifications)
                .Set("FileStatus", filestatus.NewStatus);
            var result = _assistantContext.ClientFiles.UpdateOneAsync(filter, update).Result;

            return RedirectToAction("Index");
        }

    }
}