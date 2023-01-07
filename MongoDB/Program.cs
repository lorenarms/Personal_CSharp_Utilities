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


            MongoClient dbClient = null;
            List<BsonDocument> dbList = null;

            const int maxRetries = 3;
            const string spacer = "                ";

            int retries = maxRetries;

            while (maxRetries > 0 && dbList == null)
            {
                try
                {
                    // Get username and password
                    WriteLine("Enter the username: ");
                    var userName = ReadLine();
                    WriteLine("Enter the password: ");
                    var passWord = ReadLine();

                    if (userName.ToLower().Equals("cancel") || passWord.ToLower().Equals("cancel"))
                    {
                        Environment.Exit(0);
                    }

                    // Build connection string and connect to Atlas
                    var connectionString = "mongodb+srv://" + userName + ":" + passWord + "@cluster0.cyqsq.mongodb.net/test";
                    dbClient = new MongoClient(connectionString);
                    dbList = dbClient.ListDatabases().ToList();
                }
                catch (Exception e)
                {
                    retries--;
                    Clear();
                    WriteLine("Please try again...");
                    if (retries < 1)
                    {
                        WriteLine(e);
                        Environment.Exit(0);
                        
                    }
                }
            }

            
            Clear();


            // main program loop
            while (true)
            {
                // List databases
                dbList = dbClient.ListDatabases().ToList();
                var dbListAsList = new List<string>();
                foreach (var db in dbList)
                {
                    dbListAsList.Add(GetDatabaseNameFromList(db.ToString()));
                }


                // Build the menu, justify left, set position in window
                // Give instructions to select a database
                var dbMenu = new Menu(dbListAsList, 1, 10);
                dbMenu.ModifyMenuLeftJustified();
                dbMenu.SetCursorPosition(6, 0);
                WriteLine("\nSelect a Database: " + spacer);

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
                WriteLine("DB Selected: " + databaseSelected + spacer);
                ReadKey();
                Clear();


                

                while (true)
                {

                    var database = dbClient.GetDatabase(databaseSelected);
                    var collList = database.ListCollectionNames().ToList();
                    var collectionMenu = new Menu(collList, 1, 10);

                    selection = collectionMenu.RunMenu();
                    WriteLine("\nSelect a Collection: " + spacer);
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
