class Program
{
    public static void displayMenu()
    {
        Console.WriteLine("=== TO-DO List Manager ===");
        Console.WriteLine("1. Add new item");
        Console.WriteLine("2. View all items");
        Console.WriteLine("3. Mark item complete");
        Console.WriteLine("4. Mark item incomplete");
        Console.WriteLine("5. Delete item");
        Console.WriteLine("6. Exit");
    }

    static void Main(string[] args)
    {
        Todo_Service todo_Service = new Todo_Service();
        int choice;

        do
        {
            displayMenu();
            Console.Write("Choose an option (1-6): ");
            string input = Console.ReadLine() ?? "" ;
            Console.WriteLine();

            if (int.TryParse(input, out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter task description: ");
                        string desc = Console.ReadLine() ?? "";
                        Console.WriteLine();
                        todo_Service.addItem(desc);
                        break;

                    case 2:
                        Console.WriteLine(todo_Service + "\n");
                        break;

                    case 3:
                        Console.WriteLine(todo_Service + "\n");
                        int completeIndex = AskForIndex(todo_Service);
                        todo_Service.markItem(completeIndex);
                        break;

                    case 4:
                        Console.WriteLine(todo_Service + "\n");
                        int incompleteIndex = AskForIndex(todo_Service);
                        todo_Service.markItem(incompleteIndex);
                        break;

                    case 5:
                        int deleteIndex = AskForIndex(todo_Service);
                        todo_Service.deleteItem(deleteIndex);
                        break;

                    case 6:
                        Console.WriteLine("Exiting");
                        break;

                    default:
                        Console.WriteLine("❌ Invalid choice. Try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("❌ Please enter a number.");
                choice = -1; // stay in loop
            }

        } while (choice != 6);
    }


    static int AskForIndex(Todo_Service service)
    {
        int index;
        bool valid = false;

        do
        {
            Console.Write("Enter item index: ");
            string input = Console.ReadLine() ?? "";
            Console.WriteLine();

            if (int.TryParse(input, out index) && service.inbounds(index - 1))
            {
                valid = true;
            }
            else
            {
                Console.WriteLine("❌ Invalid input. Please try again.");
            }

        } while (!valid);

        return index - 1;
    }
}