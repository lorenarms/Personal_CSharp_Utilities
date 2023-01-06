using MongoDB.Bson;
using MongoDB.Driver;
using static System.Console;




namespace MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {

            //string connectionString = "mongodb://127.0.0.1:27017";
            //string databaseName = "simple_db";
            //string collectionName = "people";
            

            // TODO: error checking for db existence
            // TODO: loop that returns to very beginning


            // Get username and password
            WriteLine("Enter the username: ");
            var userName = ReadLine();
            WriteLine("Enter the password: ");
            var passWord = ReadLine();


            // Build connection string and connect to Atlas
            var connectionString = "mongodb+srv://" + userName + ":" + passWord + "@cluster0.cyqsq.mongodb.net/test";
            MongoClient dbClient = new MongoClient(connectionString);
            Clear();


            
            while (true)
            {
                // List databases
                var dbList = dbClient.ListDatabases().ToList();
                List<string> dbListAsList = new List<string>();
                foreach (var db in dbList)
                {
                    dbListAsList.Add(GetDatabaseNameFromList(db.ToString()));
                }


                // Build the menu, justify left, set position in window
                // Give instructions to select a database
                var dbMenu = new Menu(dbListAsList, 1, 10);
                dbMenu.ModifyMenuLeftJustified();
                dbMenu.SetCursorPosition(6, 0);
                WriteLine("\nSelect a Database: ");

                // Select databases
                var selection = dbMenu.RunMenu();
                if (selection == -1)
                {
                    Clear();
                    break;
                }


                // database selected, report to user
                var databaseSelected = dbListAsList[selection].Trim();
                SetCursorPosition(7, 0);
                WriteLine("DB Selected: " + databaseSelected);
                ReadKey();
                Clear();

                while (true)
                {

                    // select the database from the server, get the collections in the database
                    var database = dbClient.GetDatabase(databaseSelected);
                    var collList = database.ListCollectionNames().ToList();
                    var collectionMenu = new Menu(collList, 1, 10);

                    selection = collectionMenu.RunMenu();
                    WriteLine("\nSelect a Collection: ");
                    if (selection == -1)
                    {
                        Clear();
                        break;
                    }

                    var collectionSelected = database.GetCollection<BsonDocument>(collList[selection]);
                    var documents = collectionSelected.Find(new BsonDocument()).ToList();


                    // clear the console, list all documents in collection
                    Clear();
                    WriteLine("Documents in collection " + collectionSelected.CollectionNamespace + "\n");
                    foreach (var document in documents)
                    {
                        WriteLine("Document: " + document);
                    }

                    //WriteLine("\n\nFirst Document: ");
                    //WriteLine(documents.ToString());

                } 

                


            } 

            


            



        }
        
        public static string GetDatabaseNameFromList(string dbStringFromList)
        {

            var str = dbStringFromList.Substring(12, dbStringFromList.Length - 12);
            str = str.Substring(0, str.IndexOf("\"", StringComparison.Ordinal));

            return str;

        }

        public static void SetCursorPosition(int row, int column)
        {
            if (row > 0 && row < WindowHeight)
            {
                CursorTop = row;
            }

            if (column > 0 && column < WindowWidth)
            {
                CursorLeft = column;
            }
        }
    }
}
