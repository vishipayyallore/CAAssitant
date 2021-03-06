﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNet.Identity.MongoDB;
using CAAssistant.Models;
using MongoDB.Driver;

namespace CAAssistant
{
    public class ApplicationIdentityContext : IDisposable
	{
		public static ApplicationIdentityContext Create()
		{
			// todo add settings where appropriate to switch server & database in your own application
			var client = new MongoClient("mongodb://localhost:27017");
			var database = client.GetDatabase("psmandco");
			var users = database.GetCollection<ApplicationUser>("users");
			var roles = database.GetCollection<IdentityRole>("roles");
			return new ApplicationIdentityContext(users, roles);
		}

		private ApplicationIdentityContext(IMongoCollection<ApplicationUser> users, IMongoCollection<IdentityRole> roles)
		{
			Users = users;
			Roles = roles;
		}

		public IMongoCollection<IdentityRole> Roles { get; set; }

		public IMongoCollection<ApplicationUser> Users { get; set; }

		public Task<List<IdentityRole>> AllRolesAsync()
		{
			return Roles.Find(r => true).ToListAsync();
		}

        // Dispose() calls Dispose(true)
		public void Dispose()
		{
            Dispose(true);
            GC.SuppressFinalize(this);
		}

        // NOTE: Leave out the finalizer altogether if this class doesn't 
        // own unmanaged resources itself, but leave the other methods
        // exactly as they are. 
        ~ApplicationIdentityContext()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
            }
            // free native resources if there are any.
        }

	}

}