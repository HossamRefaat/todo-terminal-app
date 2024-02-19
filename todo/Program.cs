using System.ComponentModel;


public partial class FirstScreen{
    public static string GetFilePath(int x){
        //todo
        if(x == 1) return  @"C:\Users\hossa\Desktop\todo-app\todo\list.txt";
        else return @"C:\Users\hossa\Desktop\todo-app\todo\done.txt";
    }

    public static int TakeInput(){
        int x = 0;
        try{
            x = Convert.ToInt32(Console.ReadLine());
            
        }
        catch(Exception e){
            Console.WriteLine("input must be an integer");
            WelcomeScreen();
        }

        return x;
    }

    public static List<string> CreateList(){
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
        }
        else
        {
            Console.WriteLine("File not found");
        }

        return ls;
    }

    private static void AddTask(){
        Console.WriteLine("Enter the task that you want to do and write 0 to exit");
        string userInput = Console.ReadLine();

        if (userInput.Replace(" ", "") == "0" || userInput.Replace(" ", "") == "")
        {
            if(userInput.Replace(" ", "") == "") Console.WriteLine("you have to write something");
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

    private static void DeleteTask(int op){
        if(op == 1) Console.WriteLine("Enter the number of task that you want to remove");
        string[] lines = File.ReadAllLines(GetFilePath(1));
        for(int i = 0; i < lines.Length; i++){
            Console.WriteLine(i+1 + ": " + lines[i]);
        }

        int x = TakeInput();
        if(lines.Count() == 0){
            Console.WriteLine("Your task list is empty");
        }
        else if(x <= lines.Length){
            if(op != 1){
                using (StreamWriter sw = File.AppendText(GetFilePath(2)))
                {
                    sw.WriteLine(lines[x-1]);
                }
            }
            using (FileStream fs = new FileStream(GetFilePath(1), FileMode.Truncate))
            {
                // Truncate the file by setting its length to 0
                 fs.SetLength(0);
            }
            lines[x-1] = "";
            for(int i = 0; i < lines.Length; i++){
                if(lines[i] != ""){
                    using (StreamWriter sw = File.AppendText(GetFilePath(1)))
                    {
                        sw.WriteLine(lines[i]);
                    }
                }
            }
            if(op == 1) Console.WriteLine($"task {x} deleted successfully.");
            else Console.WriteLine($"task {x} marked as done");
        }
        else {Console.WriteLine("Invalid Number"); DeleteTask(op);}

        WelcomeScreen();
    }

    private static void MarkTaskAsCompleted(){
        Console.WriteLine("Enter the number of task that you done");
        DeleteTask(2);
    }

    private static void ViewYourTaskList(){
        List<string> ls = new List<string>();
        ls = CreateList();
        if(ls.Count == 0){
            Console.WriteLine("Your list is empty");
        }
        else{
            int i = 1;
            foreach(string line in ls){
                Console.WriteLine(i++ + ": " + line);
            }
        }

        WelcomeScreen();
    }
    
    public static void WelcomeScreen(){
        Console.WriteLine("choose by number the operation you want to make");
        Console.WriteLine("1. Add task");
        Console.WriteLine("2. delete task");
        Console.WriteLine("3. mark task as completed");
        Console.WriteLine("4. View your task list");
        Console.WriteLine("5. Colse app");

        int x = TakeInput();
        
        switch(x){
            case 1:
                AddTask();
                break;
            case 2:
                DeleteTask(0);
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
                Console.WriteLine("You Entered a wrong number");
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