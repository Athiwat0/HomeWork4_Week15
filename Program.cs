using System;

class Program
{
    public static Tree<string> rating = new Tree<string>();
    public static Stack<string> stackuser = new Stack<string>();
    public static Stack<string> stackpreson = new Stack<string>();

    static void Main(string[] args)
    {
        Console.WriteLine("Input");
        if(rating.GetLength() == 0){
            string Input_Name = InputName();
            rating.AddChild(-1,Input_Name);
            PushTree(Input_Name);
        }
        Console.WriteLine("======================================");
        Console.Write("Input : ");
        string Final_Input = Console.ReadLine();

        Console.Clear();
        Console.WriteLine("Output ");
        Console.WriteLine("======================================");

        Stack<string> stacksearch =  rating.GetStackpreson(Output(Final_Input));

        while(true){
            if(stacksearch.GetLength() == 0){
                break;
            }
            else{
                Console.WriteLine(stacksearch.Pop());
            }
        }
    }

    public static void PushTree(string inputname){
        TreeNode<string> node = null;

        int number = InputNumber();
        if(number != 0){

            stackpreson.Push(inputname);

            string Input_Name_1 = InputName();
            rating.AddChildX(inputname,Input_Name_1);
            PushTree(Input_Name_1);
            stackuser.Push(Input_Name_1);

            if(number >= 1){
                for(int i = 1 ;i < number ; i++){
                    string Input_Name_2 = InputName();
                    rating.AddSiblingX(stackuser.Pop(),Input_Name_2);
                    PushTree(Input_Name_2);
                    stackuser.Push(Input_Name_2);
                }
            }

        }
    }

    public static string InputName(){
        string Input_Name = Console.ReadLine();
        return Input_Name;
    }
    public static int InputNumber(){
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    public static int Output (string Final_Input){
        for(int i = 0; i < rating.GetLength(); i++){
            if(Final_Input == rating.Get(i)){
                return i;
            }
        }
        return 0;
    }

    
}