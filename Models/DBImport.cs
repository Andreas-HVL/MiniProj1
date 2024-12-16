using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MiniProj.Functionality;

namespace MiniProj.Models
{
    public static class DBImport
    {
        private static readonly MongoClient client = new MongoClient("mongodb+srv://hijaker:r0pCX7VMLNuQ9e0w@cluster0.phpb6.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0");
        private static readonly IMongoDatabase database = client.GetDatabase("LIA");
        private static readonly IMongoCollection<BsonDocument> CompaniesCollection = database.GetCollection<BsonDocument>("CompaniesRobin");
        private static readonly IMongoCollection<BsonDocument> AppliedCollection = database.GetCollection<BsonDocument>("LIA-Applications");

        public static BlankCompany[]? blankCompanies { get; private set; }
        public static Company[]? Companies { get; private set;}
        public static AppliedAlready[]? AppliedAlreadies { get; private set;}


        public static void LoadCompanies()
        {
            try
            {
                // Fetch blank companies (TagX is null)
                var blankDocs = CompaniesCollection
                    .Find(Builders<BsonDocument>.Filter.Eq("X", BsonNull.Value))
                    .ToList();

                // Deserialize directly using BsonSerializer
                blankCompanies = blankDocs
                    .Select(doc => BsonSerializer.Deserialize<BlankCompany>(doc))
                    .ToArray();

                // Fetch regular companies (TagX is not null)
                var regularDocs = CompaniesCollection
                    .Find(Builders<BsonDocument>.Filter.Ne("X", BsonNull.Value))
                    .ToList();

                // Deserialize directly using BsonSerializer
                Companies = regularDocs
                    .Select(doc => BsonSerializer.Deserialize<Company>(doc))
                    .ToArray();

                Console.WriteLine("Companies and BlankCompanies loaded successfully.");
            }
            catch (Exception ex)
            {
                // Log the error and throw a fatal exception to terminate the program
                Console.WriteLine("Critical Error: Failed to load Companies from the database.");
                Console.WriteLine($"Details: {ex.Message}");
                throw new InvalidOperationException("Unable to initialize the Company list. The program will now terminate.", ex);
            }
        }



        public static AppliedAlready[] LoadApplications()
        {
            try
            {
                // Retrieve all documents from the AppliedCollection
                var bsonDocs = AppliedCollection
                    .Find(FilterDefinition<BsonDocument>.Empty)
                    .ToList();

                // Deserialize directly using BsonSerializer
                AppliedAlreadies = bsonDocs
                    .Select(doc => BsonSerializer.Deserialize<AppliedAlready>(doc))
                    .ToArray();

                Console.WriteLine("AppliedAlreadies loaded successfully.");
                return AppliedAlreadies;
            }
            catch (Exception ex)
            {
                // Log the error and throw a fatal exception to terminate the program
                Console.WriteLine("Critical Error: Failed to load AppliedAlreadies from the database.");
                Console.WriteLine($"Details: {ex.Message}");
                throw new InvalidOperationException("Unable to initialize the AppliedAlready list. The program will now terminate.", ex);
            }
        }

        public static void PrintSomething()
        {
            Console.WriteLine(blankCompanies[1].Id);
            
        }
    }
}
