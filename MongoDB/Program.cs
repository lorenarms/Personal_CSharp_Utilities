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
            string databaseName = "simple_db";
            string collectionName = "people";
            
            //Get username and password
            WriteLine("Enter the username: ");
            var userName = ReadLine();

            WriteLine("Enter the password: ");
            var passWord = ReadLine();
            //Build connection string and connect to Atlas
            var connectionString = "mongodb+srv://" + userName + ":" + passWord + "@cluster0.cyqsq.mongodb.net/test";
            MongoClient dbClient = new MongoClient(connectionString);
            Clear();
            
            //List databases
            var dbList = dbClient.ListDatabases().ToList();
            List<string> dbs = new List<string>();
            foreach (var db in dbList)
            {
                //WriteLine("Database Name: " + db);
                dbs.Add(db.ToString());
            }

            var menu = new Menu(dbs, 1, 1);
            menu.ModifyMenuLeftJustified();
            menu.CenterMenuToConsole();
            menu.SetCursorPosition(6, 1);
            WriteLine("\nSelect a Database: ");
            var selection = menu.RunMenu();

            if (selection == -1)
            {
                Environment.Exit(0);
            }

            //Select databases
            

            var databaseSelected = dbs[selection];
            
            var database = dbClient.GetDatabase(databaseSelected);

            //WriteLine("The list of databases on this server is: ");
            //foreach (var db in dbList)
            //{
            //    WriteLine(db);
            //}

            Clear();
            var collList = database.ListCollectionNames().ToList();
            foreach (var coll in collList)
            {
                WriteLine("Collection Name: " + coll);
            }

            WriteLine("\nSelect a Collection: ");
            var collection = database.GetCollection<BsonDocument>(ReadLine());

            Clear();
            //var collection = database.GetCollection<BsonDocument>("col");

            //var documents = collection.Find(new BsonDocument()).FirstOrDefault();
            var documents = collection.Find(new BsonDocument()).ToList();


            foreach (var document in documents)
            {
                WriteLine("Document: " + document);
            }

                //WriteLine("\n\nFirst Document: ");
                //WriteLine(documents.ToString());



        }
    }
}
