using System;

string[] names = {
            "Justin", "Ethan", "Victoria", "Ethan", "Ben",
            "Kyra", "Jack", "Ramses", "Clare", "Ramsey",
            "Ali", "Pedro", "Mellisa"
        };

// Array to hold favorite foods
string[] favoriteFoods = {
            "Baja Blast", "Ethan", "Pho", "Hot Wings", "Crab legs",
            "Sushi", "Hot Wings", "Lasagna", "Cheesy Potatoes", "Dim Sum",
            "Indian", "Italian", "Pizza"
        };

// Array to hold hometowns
string[] hometowns = {
            "Westerville", "Ethan", "Blacksburg", "Bolivar", "Birmingham",
            "Hazel Park", "Trenton", "Wyoming", "Lake Orion", "Brooklyn",
            "Dearborn Heights", "Chicago", "Detroit"
        };

do
{
    int student = GetStudent(names);
    string choice = GetChoice(names, student);

    if(choice.Equals("hometown"))
    {
        Console.WriteLine($"{names[student]} is from {hometowns[student]}");
    }
    else if(choice.Equals("favorite food"))
    {
        Console.WriteLine($"{names[student]} likes {favoriteFoods[student]}");
    }
} while(GoAgain());

static int GetStudent(string[] n)
{
    int c;
    bool isNum;

    do
    {
        Console.WriteLine("Please enter a student number.  Alternatively, enter -1 to see a list of all students with their student number, or type part of a student's name to search by name.");
        string userChoice = Console.ReadLine();
        if(int.TryParse(userChoice, out c))
        {
           if (c == -1)
            {
                PrintAllStudents(n);
            }
            else if (c < 0 || c > n.Length - 1)
            {
                Console.WriteLine($"Student numbers are 0 through {n.Length - 1}.");
            }
        }
        else
        {
            c = SearchByName(n, userChoice);
        }

        
    } while (c < 0 || c > n.Length - 1);

    Console.WriteLine(n[c]);

    return c;
}

static string GetChoice(string[] n, int s)
{
    string input;

    do
    {
        Console.WriteLine($"Would you like to see {n[s]}'s hometown or favorite food?");
        input = Console.ReadLine().ToLower();


        if("hometown".Contains(input) && !"favorite food".Contains(input))
        {
            input = "hometown";
        }
        else if("favorite food".Contains(input) && !"hometown".Contains(input))
        {
            input = "favorite food";
        }
        else if(input.Contains("home") || input.Contains("town"))
        {
            input = "hometown";
        }
        else if(input.Contains("favorite") || input.Contains("food"))
        {
            input = "favorite food";
        }
        else if (!input.Equals("hometown") && !input.Equals("favorite food"))
        {
            Console.WriteLine("Please enter either \"hometown\" or \"favorite food\" (without the quotes)");
        }
    } while (!input.Equals("hometown") && !input.Equals("favorite food"));

    return input;
}

static bool GoAgain()
{
    string str;
    Console.WriteLine("Would you like to learn about another student?"
        + " Enter yes or y to continue, enter anything else to exit");

    str = Console.ReadLine().ToLower();
    if (!str.Equals("y") && !str.Equals("yes"))
    {
        return false;
    }
    else
    {
        return true;
    }
}

static void PrintAllStudents(string[] n)
{
    for(int i = 0; i < n.Length; i++)
    {
        Console.WriteLine(String.Format("{0, -12}\t{1, -12}", n[i], i));
    }
}

static int SearchByName(string[] n, string namePart)
{
    int i;
    namePart = namePart.ToLower();
    string[] names = Array.FindAll(n, element => element.Contains(namePart, StringComparison.OrdinalIgnoreCase));

    if (names.Length == 1)
    {
        for (i = 0; i < n.Length; ++i)
        {
            if (n[i].Equals(names[0]))
            {
                return i;
            }
        }
    }
    else if (names.Length > 1)
    {
        int ind = 0;
        Console.WriteLine("Multiple names found: ");
        for (i = 0; i < n.Length; i++)
        {
            for (int j = 0; j < names.Length; j++)
            {
                if (names[j].Equals(n[i]))
                {
                    Console.WriteLine(String.Format("{0, -12}\t{1, -12}", names[j], i));
                    break;
                }
            }

        }
        Console.WriteLine("Please enter a student number.  Alternatively, enter -1 to see a list of all students with their student number");
        return int.Parse(Console.ReadLine());
    }
    Console.WriteLine("Could not find a name based on input.  Here are the students and their student numbers: ");
    return -1;
}

////Old version of the method I don't want to delete
//static int SearchByName(string[] n)
//{
//    int i;
//    Console.WriteLine("Please enter a part of the person's name you would like to find");
//    string namePart = Console.ReadLine().ToLower();
//    string[] names = Array.FindAll(n, element => element.Contains(namePart, StringComparison.OrdinalIgnoreCase));

//    if (names.Length == 1)
//    {
//        for (i = 0; i < n.Length; ++i)
//        {
//            if (n[i].Equals(names[0]))
//            {
//                return i;
//            }
//        }
//    }
//    else if (names.Length > 1)
//    {
//        int ind = 0;
//        Console.WriteLine("Multiple names found: ");
//        for (i = 0; i < n.Length; i++)
//        {
//            for(int j = 0; j < names.Length; j++)
//            {
//                if (names[j].Equals(n[i]))
//                {
//                    Console.WriteLine(String.Format("{0, -12}\t{1, -12}", names[j], i));
//                    break;
//                }
//            }

//        }
//        Console.WriteLine("Please enter a student number.  Alternatively, enter -1 to see a list of all students with their student number");
//        return int.Parse(Console.ReadLine());
//    }
//        Console.WriteLine("Could not find a name based on input.  Here are the students and their student numbers: ");
//        return -1;
//}