using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QISMsgVaultWeb.Web
{
    public class VaultUser
    {
        public ObjectId Id { get; set; }
        public string emailAddress { get; set; }
        public bool initialized { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}