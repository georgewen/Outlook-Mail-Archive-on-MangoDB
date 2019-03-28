using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MongoDB.Driver.Builders;

namespace MsgVaultWeb
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MsgVaultService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MsgVaultService.svc or MsgVaultService.svc.cs at the Solution Explorer and start debugging.
    public class MsgVaultService : IMsgVaultService
    {
        public List<MongoMail> GetAllEmails()
        {
            MongoServer mongo = MongoServer.Create();
            mongo.Connect();
            var db = mongo.GetDatabase("MessageVault");
            var emails = db.GetCollection("eMails");
            var MyQuery = Query<MongoMail>.Exists(g => g.EntryID);
            List<MongoMail> result = emails.FindAs<MongoMail>(MyQuery).OrderByDescending(g => g.ReceivedTime).Take(50).ToList();

            return result;
        }


        public List<MongoMail> GetEmailsPage(int pageIndex, int pageSize)
        {
            MongoServer mongo = MongoServer.Create();
            mongo.Connect();
            var db = mongo.GetDatabase("MessageVault");

            var sortBy = SortBy<MongoMail>.Descending(u => u.ReceivedTime);
            var collection = db.GetCollection<MongoMail>("eMails");
            var cursor = collection.FindAll();
            cursor.SetSortOrder(sortBy);

            cursor.Skip = pageIndex * pageSize;
            cursor.Limit = pageSize;
            return cursor.ToList();
        }


        public void UploadEmail(MongoMail msg)
        {
            //throw new NotImplementedException();
            MongoServer mongo = MongoServer.Create();
            mongo.Connect();
            var db = mongo.GetDatabase("MessageVault");
            var collection = db.GetCollection<MongoMail>("eMails");
            var MyQuery = Query<MongoMail>.EQ(g => g.EntryID, msg.EntryID);
            long counter = collection.FindAs<MongoMail>(MyQuery).Count();
            if (counter == 0)
                collection.Insert(msg);

        }

        public void CreateUser(VaultUser user)
        {
            MongoServer mongo = MongoServer.Create();
            mongo.Connect();
            var db = mongo.GetDatabase("MessageVault");
            var collection = db.GetCollection<VaultUser>("VaultUsers");
            var MyQuery = Query<VaultUser>.EQ(g => g.emailAddress, user.emailAddress);
            long counter = collection.FindAs<VaultUser>(MyQuery).Count();
            if (counter == 0)
                collection.Insert(user);
        }

        public VaultUser GetUserByEmail(string emailaddr)
        {
            //throw new NotImplementedException();
            MongoServer mongo = MongoServer.Create();
            mongo.Connect();
            var db = mongo.GetDatabase("MessageVault");
            var collection = db.GetCollection<VaultUser>("VaultUsers");
            var MyQuery = Query<VaultUser>.EQ(g => g.emailAddress, emailaddr);
            VaultUser usr = collection.FindOneAs<VaultUser>(MyQuery);
            return usr;
        }

        public void UpdateUser(VaultUser user)
        {
            //throw new NotImplementedException();
            MongoServer mongo = MongoServer.Create();
            mongo.Connect();
            var db = mongo.GetDatabase("MessageVault");
            var collection = db.GetCollection<MongoMail>("VaultUsers");
            collection.Save(user);
        }
    }
}
