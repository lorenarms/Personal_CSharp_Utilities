using MongoDB.Bson;
using MongoDB.Driver;
using static System.Console;



namespace MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            // string connectionString = "mongodb://127.0.0.1:27017";
            string connectionString = "";
            string databaseName = "simple_db";
            string collectionName = "people";

            MongoClient dbClient = new MongoClient(connectionString);

            var dbList = dbClient.ListDatabases().ToList();

            //WriteLine("The list of databases on this server is: ");
            //foreach (var db in dbList)
            //{
            //    WriteLine(db);
            //}

            var database = dbClient.GetDatabase("db");
            var collection = database.GetCollection<BsonDocument>("col");

            // var documents = collection.Find(new BsonDocument()).FirstOrDefault();
            var documents = collection.Find(new BsonDocument()).ToList();

            foreach (var document in documents)
            {
                WriteLine(document.ToString());
            }

            //WriteLine("\n\nFirst Document: ");
            //WriteLine(documents.ToString());
            

        }
    }
}
