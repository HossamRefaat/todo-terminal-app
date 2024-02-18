using System.ComponentModel;


public partial class FirstScreen{
    public static string GetFilePath(int x){
        //todo
        if(x == 1) return  @"C:\Users\hossa\Desktop\todo-app\todo\list.txt";
        else return "";
    }
    private static void AddTask(){
        Console.WriteLine("Enter the task that you want to do and write 0 to exit");
        string userInput = Console.ReadLine();

        if (userInput.Replace(" ", "") == "0" || userInput.Replace(" ", "") == "")
        {
            WelcomeScreen();
        }
        else
        {
            try
            {
                using (StreamWriter sw = File.AppendText(GetFilePath(1)))
                {
                    sw.WriteLine(userInput);
                }

                Console.WriteLine("Task added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while writing to the file: " + ex.Message);
            }

            AddTask();
        }
    }

    private static void DeleteTask(){
        
    }
    private static void MarkTaskAsCompleted(){
        
    }
    private static void ViewYourTaskList(){
        List<string> ls = new List<string>();
        
        if (File.Exists(GetFilePath(1)))
        {
            // Open the file with a StreamReader
            using (StreamReader reader = new StreamReader(GetFilePath(1)))
            {
                // Read the file line by line until the end
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    ls.Add(line);
                }
            }
            int i = 1;
            foreach(string line in ls){
                Console.WriteLine(i++ + ". " + line);
            }
            Console.WriteLine("=========================================");
            WelcomeScreen();
        }
        else
        {
            Console.WriteLine("File not found");
        }
    }
    
    public static void WelcomeScreen(){
        Console.WriteLine("choose by number the operation you want to make");
        Console.WriteLine("1. Add task");
        Console.WriteLine("2. delete task");
        Console.WriteLine("3. mark task as completed");
        Console.WriteLine("4. View your task list");
        Console.WriteLine("5. Colse app");

        int x = Convert.ToInt32(Console.ReadLine());
        switch(x){
            case 1:
                AddTask();
                break;
            case 2:
                DeleteTask();
                break;
            case 3:
                MarkTaskAsCompleted();
                break;
            case 4:
                ViewYourTaskList();
                break;
            case 5:
                return;
            default:
                Console.WriteLine("You Enter a wrong number");
                Console.WriteLine("=========================================");
                WelcomeScreen();
                break;
        }
    }
}

class Program{
    public static void Main(){
        FirstScreen.WelcomeScreen();
    }
}