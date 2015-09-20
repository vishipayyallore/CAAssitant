using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAAssistant.DataStore;
using CAAssistant.Models;
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
            throw new NotImplementedException();
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