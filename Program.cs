namespace A1_TicketingSystem_BJ2023
{
    public class Program
    {
        static void Main(string[] args)
        {
            string file = "ticketingSystemData.txt";

            //  Write header to the ticketingSystemData file

            StreamWriter header = new StreamWriter(file, false);
            header.WriteLine($" Ticket ID, Summary , Status, Priority, Submitter, Assigned, Watching");
            header.Close(); //Always close your stream

            string readCreateChoice;
            do
            {
                Console.WriteLine("1) Read ticket from ticketing system file.");
                Console.WriteLine("2) Create ticket from ticketing system file.");
                Console.WriteLine("Enter any other key to exit.");
                readCreateChoice = Console.ReadLine();

                if (readCreateChoice == "1")
                {
                    //logic to read
                    StreamReader sr = new StreamReader(file);

                    var headerPrint = sr.ReadLine();  //  Reads the header but does not need so doesnt need to store
                    
                    Console.WriteLine(headerPrint);

                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        string[] arr = line.Split(',');


                        Console.WriteLine($"{arr[0]}, {arr[1]}, {arr[2]}, {arr[3]}, {arr[4]}, {arr[5]}, {arr[6]}");
                    }


                    sr.Close();  //  Always close your Stream!

                }
                else if (readCreateChoice == "2")
                {
                    //logic to write
                    StreamWriter sw = new StreamWriter(file, true);

                    Console.WriteLine("Enter the course ticket ID Number.");
                    string ticketID = Console.ReadLine();

                    Console.WriteLine("Enter an issue summary.");
                    string summary = Console.ReadLine();

                    Console.WriteLine("Enter the course ticket status.");
                    string status = Console.ReadLine();

                    Console.WriteLine("Enter the course ticket priority level.");
                    string priority = Console.ReadLine();

                    Console.WriteLine("Enter your name.");
                    string submitter = Console.ReadLine();

                    Console.WriteLine("Enter the technician assigned to the ticket.");
                    string assigned = Console.ReadLine();

                    //  add watchers functionallity
                    string watching = "";
                    Console.WriteLine("Would you like to add watchers (Y/N)? ");
                    string addWatchers = Console.ReadLine().ToUpper();
                    if (addWatchers != "Y")
                    {
                        break;
                    }
                    else
                    {

                        Console.WriteLine("How many watchers would you like to add? ");
                        int numberWatching = Convert.ToInt32(Console.ReadLine());


                        
                        for (int i = 0; i < numberWatching; i++)
                        {
                            Console.WriteLine("Enter a watcher. ");

                            if (i != numberWatching - 1)
                            {
                                watching += Console.ReadLine() + " | ";
                            }
                            else
                            {
                                watching += Console.ReadLine();
                            }
                            
                        }

                    }

                    sw.WriteLine($"{ticketID} , {summary} , {status} , {priority} , {submitter} , {assigned} , {watching}");

                    sw.Close(); //Always close your stream

                }
                else { break; }

            } while (readCreateChoice == "1" || readCreateChoice == "2");
        }
    }
}