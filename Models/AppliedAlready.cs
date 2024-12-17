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

        [BsonElement("Rank")]
        public string? Rank { get; set; } = null;

        [BsonElement("Description")]
        public string? Description { get; set; }
    }
}
