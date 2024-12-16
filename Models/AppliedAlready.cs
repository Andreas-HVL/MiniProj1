using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniProj.Functionality;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MiniProj.Models
{
    public class AppliedAlready
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Org Number")]
        public string CompanyNo { get; set; }

        [BsonElement("X")]
        public string? TagX { get; set; } = null;

        [BsonElement("Descriptor")]
        public string? Descriptor { get; set; } = null;
    }
}
