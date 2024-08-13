using System.Reflection.Metadata;

internal class Program {
    private static void Main(string[] args) {
        ToDo toDo = new ToDo();
    }
}

public class ToDo {
    private static readonly List<string> oprList = new List<string>() {
        "[1] Add ToDo",
        "[2] See ToDo List",
        "[3] Update ToDo",
        "[4] Delete ToDo",
        "[5] Exit"
    };
    private static readonly List<string> validInpList = new List<string>() {
        "1", "2", "3", "4", "5"
    };
    private List<string> toDo = new List<string>();

    public ToDo() {
        Print("Welcome to ToDo App...", newLineCharAtEnd: true);
        Wait(2);
        ClearConsole(askForKeypress: false);
        StartApp();
    }

    //
    public void StartApp() {
        int? input;
        do {
            input = GetInput();
            ClearConsole(askForKeypress: false);
            switch(input) {
                case 1:
                    Add();
                    break;
                case 2:
                    See();
                    break;
                case 3:
                    Update();
                    break;
                case 4:
                    Delete();
                    break;
                default:
                    FinalGreet();
                    break;
            }
        } while (input != 5);
    }

    public void Add() {
        Print("Enter ToDo : ", newLineCharAtEnd: false);
        string task = Read();
        toDo.Add(task);
        Print("ToDo has been successfully added...", newLineCharAtEnd: true);
        Wait(1);
        ClearConsole(askForKeypress: false);
    }

    public void See() {
        bool isListPrinted = PrintToDoList();
        ClearConsole(askForKeypress: true);
    }

    public void Update() {
        bool isListPrinted = PrintToDoList();
        if (isListPrinted) {
            int input = GetValidToDoId("Enter the id of ToDo to be updated : ");
            if (input != 0) {
                Print($"Existing ToDo : {toDo[input - 1]}", newLineCharAtEnd: true);
                Print($"Enter the updated ToDo : ", newLineCharAtEnd: false);
                string updatedTodo = Read();
                toDo[input - 1] = updatedTodo;
                Print("ToDo has bee successfully updated...", newLineCharAtEnd: true);
            }
        }
        Wait(1);
        ClearConsole(askForKeypress: false);
    }

    public void Delete() {
        bool isListPrinted = PrintToDoList();
        if (isListPrinted) {
            int input = GetValidToDoId("Enter the id of ToDo to be deleted : ");
            if (input != 0) {
                PrintEmptyLine();
                Print($"ToDo to be deleted : {toDo[input - 1]}", newLineCharAtEnd: true);
                Print($"Confirm (press y to confirm delete) : ", newLineCharAtEnd: false);
                string cmd = Read();
                if (cmd == "y") {
                    toDo.RemoveAt(input - 1);
                    PrintEmptyLine();
                    Print("ToDo has bee successfully removed...", newLineCharAtEnd: true);
                } 
            }
        }
        Wait(1);
        ClearConsole(askForKeypress: false);
    }

    public void FinalGreet() {
        Print("Thank you for visiting us...", newLineCharAtEnd: true);
        Print("Have a nice day...", newLineCharAtEnd: true);
        Wait(2);
        ClearConsole(askForKeypress: false);
    }

    public int GetValidToDoId(string instruction) {
        string input;
        while (true) {
            PrintEmptyLine();
            Print(instruction, newLineCharAtEnd: false);
            input = Read();
            bool success = int.TryParse(input, out int id);
            if (success) {
                if (id <= 0 || id > toDo.Count) {
                    input = "0";
                    Print("Id with the provided Id does not exists in ToDo List...", newLineCharAtEnd: true);
                }
                break;
            }
            Print("Id is not proper format, please try again...", newLineCharAtEnd: true);
        }
        return int.Parse(input);
    }

    public bool PrintToDoList() {
        if (toDo.Count == 0) {
            Print("ToDo List is Empty...", newLineCharAtEnd: true);
            return false;
        }
        Print("ToDo List", newLineCharAtEnd: true);
        for (int i = 0; i < toDo.Count; i++) {
            Print($"  [{i + 1}] {toDo[i]}", newLineCharAtEnd: true);
        }
        return true;
    }

    public int GetInput() {
        string input;
        while (true) {
            ShowOptions();
            PrintEmptyLine();
            Print("Enter Choice : ", newLineCharAtEnd: false);
            input = Read();
            if (validInpList.Contains(input)) {
                break;
            }
            WarnInvalidInput();
        };
        return int.Parse(input);
    }

    public void ShowOptions() {
        Print("Choose the operation to be performed", newLineCharAtEnd: true);
        foreach(string operation in oprList) {
            Print(operation, newLineCharAtEnd: true);
        }
    }


    // Basic Task
    public void Wait(int second) {
        Thread.Sleep(second * 1000);
    }

    public string Read() {
        return Console.ReadLine();
    }

    public void PrintEmptyLine() {
        Print("", newLineCharAtEnd: true);
    }

    public void Print(string line, bool newLineCharAtEnd) {
        if (newLineCharAtEnd) {
            Console.WriteLine(line);
        } else {
            Console.Write(line);
        }
    }

    public void ClearConsole(bool askForKeypress) {
        if (askForKeypress) {
            PrintEmptyLine();
            Print("Press any key to continue...", newLineCharAtEnd: true);
            Console.ReadKey();
        }
        Console.Clear();
    }

    public void WarnInvalidInput() {
        PrintEmptyLine();
        Print("Invalid Input, Please try again..", newLineCharAtEnd: true);
        Wait(1);
        ClearConsole(askForKeypress: false);
    }
}