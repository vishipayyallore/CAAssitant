using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAAssistant.DataStore;
using CAAssistant.Models;
using Microsoft.AspNet.Identity;
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

        public ActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Details(string id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Edit(string id)
        {
            throw new NotImplementedException();
        }
    }
}