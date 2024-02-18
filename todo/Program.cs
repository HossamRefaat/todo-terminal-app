using System.ComponentModel;

public partial class FirstScreen{
    private static void AddTask(){

    }
    private static void DeleteTask(){
        
    }
    private static void MarkTaskAsCompleted(){
        
    }
    private static void ViewYourTaskList(){
        
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