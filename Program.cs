string pathToFileClients = "C:\\Users\\tleder\\Desktop\\LambooInvestmentFund\\KlijentiLamboo.txt";
string pathToFileEmployees = "C:\\Users\\tleder\\Desktop\\LambooInvestmentFund\\ZaposleniLamboo.txt";
List<Client> clientInformation = LoadInfo(pathToFileClients);
List<Employee> employeeInformation = LoadInformation(pathToFileEmployees);

bool shouldTheProgramBeRunning = true;
while (shouldTheProgramBeRunning)
{
    Console.WriteLine("\nInsert an option...\n" +
        "1. Output of all information\n" +
        "2. Input a new Client\n" +
        "3. Input a new Employee\n" +
        "4. Delete a Client\n" +
        "5. Delete an Employee\n" +
        "6. Save a Client\n" +
        "7. Save an employee\n" +
        "8. End Programme\n");

    int input = Convert.ToInt32(Console.ReadLine());
    switch (input)
    {
        case 1:
            Console.WriteLine("Clients: \n");
            OutputClients(clientInformation);
            Console.WriteLine("\nEmployees: \n");
            OutputEmployees(employeeInformation);
            break;
        case 2:
            clientInformation.Add(InsertClient());
            break;
        case 3:
            employeeInformation.Add(InsertEmployee());
            break;
        case 4:
            DeleteItem(clientInformation);
            break;
        case 5:
            DeleteEmployee(employeeInformation);
            break;
        case 6:
            SaveClients(pathToFileClients, clientInformation);
            break;
        case 7:
            SaveEmployee(pathToFileEmployees, employeeInformation);
            break;
        case 8:
            shouldTheProgramBeRunning = false;
            break;
        default:
            Console.WriteLine("Wrong Input");
            break;
    }
}
void DeleteItem(List<Client> companyInformation)
{

    Console.WriteLine("Insert an Item you wish to delete");
    string deletedName = Console.ReadLine();

    foreach (Client title in companyInformation)
    {
        if (title.name == deletedName)
        {
            Console.WriteLine("{0} found. We're deleting the element", title.ToString());

            companyInformation.Remove(title);
            return;
        }
    }

}
void DeleteEmployee(List<Employee> employeeInformation)
{

    Console.WriteLine("Insert an Item you wish to delete");
    string deletedName = Console.ReadLine();
    foreach (Employee title in employeeInformation)
    {
        if (title.name == deletedName)
        {
            Console.WriteLine("{0} found. We're deleting the element", title.ToString());

            employeeInformation.Remove(title);
            return;
        }
    }

}
void SaveClients(string pathToFile, List<Client> information)
{
    List<string> linijeZaUpis = new List<string>();
    foreach (Client handle in information)
    {
        string linija = String.Format("{0};{1};{2}", handle.name, handle.function, handle.investment);

        linijeZaUpis.Add(linija);
    }

    File.WriteAllLines(pathToFile, linijeZaUpis);
}
void SaveEmployee(string pathToFile, List<Employee> information)
{
    List<string> linijeZaUpis = new List<string>();
    foreach (Employee handle in information)
    {
        string linija = String.Format("{0};{1};{2}", handle.name, handle.function, handle.paycheck);
        linijeZaUpis.Add(linija);
    }

    File.WriteAllLines(pathToFile, linijeZaUpis);
}

void OutputClients(List<Client> humans)
{
    foreach (Client clients in humans)
    {
        Console.WriteLine("{0} ",clients.ToString());
    }
}
void OutputEmployees(List<Employee> people)
{
    foreach (Employee employees in people)
    {
        Console.WriteLine("{0} ", employees.ToString());
    }
}

Client InsertClient()
{
    Console.WriteLine("Insert a name");
    string name = Console.ReadLine();

    Console.WriteLine("Insert the person's function");
    string function = Console.ReadLine();

    Console.WriteLine("Insert the person's investment.");
    string investment = Console.ReadLine();

    return new Client(name, function, investment);

}
Employee InsertEmployee()
{
    Console.WriteLine("Insert a name");
    string name = Console.ReadLine();

    Console.WriteLine("Insert the person's function");
    string function = Console.ReadLine();

    Console.WriteLine("Insert the person's paycheck");
    string paycheck = Console.ReadLine();

    return new Employee(name, function, paycheck);
}

List<Client> LoadInfo(string putanja)
{
    List<Client> Lamboo = new List<Client>();

    
    foreach (string linija in File.ReadAllLines(putanja))
    {
   
        string[] Parts = linija.Split(";");

        Lamboo.Add(new Client(Parts[0], Parts[1], Parts[2]));
    }

    return Lamboo;
}
List<Employee> LoadInformation(string putanja)
{
    List<Employee> Lamboo = new List<Employee>();

    foreach (string linija in File.ReadAllLines(putanja))
    {
        string[] Parts = linija.Split(";");
        Lamboo.Add(new Employee(Parts[0], Parts[1], Parts[2]));
    }

    return Lamboo;
}


public class Client
{
    public string name;
    public string function;
    public string investment;

    public Client(string Name, string Function, string Investment)
    {
        this.name = Name;
        this.function = Function;
        this.investment = Investment;
    }

    public string ToString()
    {
        return String.Format("Name and Surname: {0}, function: {1}, investment: {2}", name, function, investment);
    }
}

public class Employee
{
    public string name;
    public string function;
    public string paycheck;


    public Employee(string Name, string Function, string Paycheck)
    {
        this.name = Name;
        this.function = Function;
        this.paycheck = Paycheck;
    }
    public string ToString()
    {
        return String.Format("Name and surname{0}, function {1}, investment{2}", name, function, paycheck);
    }
}
