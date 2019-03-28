using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

namespace OutlookAddIn1
{
    //[BsonIgnoreExtraElements]
    public class MongoMail //:MongoEntity
    {
        //public MongoMail() {}
        //[BsonId(IdGenerator = typeof(StringObjectIdGenerator))] 
        //[BsonId]
        public ObjectId Id { get; set; }
        public string Subject { get; set; }
        public string Categories { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime ReceivedTime { get; set; }
        public string CC { get; set; }
        public string Body { get; set; }
        public string SenderEmailAddress { get; set; }
        public string EntryID { get; set; }
        public string To { get; set; }
        //ConversationID
        //ConversationIndex
        //ConversationTopic

        //EntryID
        //Attachments
        //ReceivedByName
        //ReceivedTime
        //Sender ?
        //SenderEmailAddress

    }
}
