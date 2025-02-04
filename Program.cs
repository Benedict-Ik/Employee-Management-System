namespace Employee_Management_System
{
    public class Employee
    {
        // Properties
        public string EmployeeId { get; private set; }
        public string Name { get; private set; }
        public string Department { get; set; }
        public int PerformanceRating { get; set; }

        // Constructor - Initializer
        public Employee(string employeeId, string name)
        {
            EmployeeId = employeeId;
            Name = name;
            Department = "Unassigned";
            PerformanceRating = 0;
        }

        // Methods
        //public void DisplayEmployeeDetails()
        //{
        //    Console.WriteLine($"Employee ID: {EmployeeId}");
        //    Console.WriteLine($"Name: {Name}");
        //    Console.WriteLine($"Department: {Department}");
        //    Console.WriteLine($"Performance Rating: {PerformanceRating}");
        //}

        //public void UpdateDetails(Employee employee)
        public void UpdateDetails(string name)
        {
            //Name = employee.Name;
            Name = name;
            //Console.WriteLine("Name has successfully been updated.");
            Console.WriteLine($"Employee: {EmployeeId} name has been updated.");
        }

        //public void AssignDepartment(Employee employee)
        public void AssignDepartment(string department)
        {
            //Department = employee.Department;
            Department = department;
            //Console.WriteLine($"{employee.Name} has successfully been assigned to {Department}");
            Console.WriteLine($"{Name} has successfully been assigned to {Department}");
        }

        //public void UpdatePerformanceRating(int performanceRating)
        public void AddPerformanceRating(int performanceRating)
        {
            if (performanceRating > 0 && performanceRating < 6)
            {
                PerformanceRating = performanceRating;
                Console.WriteLine($"Performance rating has successfully been updated to {performanceRating}.");
            }
            else
            {
                Console.WriteLine("Performance rating must be between 1 and 5.");
            }
        }
    }

    public class Manager : Employee
    {
        // Additional Properties
        public List<Employee> Team { get; set; }

        // Constructor with inherited properties form the base class
        public Manager(string employeeId, string name) : base(employeeId, name)
        {
            Team = new List<Employee>();
        }

        public void AssignTeamMember(Employee employee)
        {
            Team.Add(employee);
            Console.WriteLine($"{employee.Name} has successfully been added to {Name}'s team.");
        }

        //public void ViewTeamDetails(Employee employee)
        public void ViewTeamDetails()
        {
            int counter = 1;
            Console.WriteLine($"No \tName \t\t\tDepartment");
            foreach (var member in Team)
            {
                Console.WriteLine($"{counter}.\t{member.Name} \t\t{member.Department}");
                counter++;
            }
        }
    }
    public class EmployeeManager
    {
        // Property
        public List<Employee> Employees { get; set; }

        // Constructor
        public EmployeeManager()
        {
            Employees = new List<Employee>();
        }

        // Methods
        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
            Console.WriteLine($"{employee.Name} has successfully been added.");
        }

        public void UpdateEmployee(Employee employee)
        {
            if (Employees.Contains(employee))
            {
                employee.UpdateDetails(employee.Name);
            }
            else
            {
                Console.WriteLine("Employee does not exist in the system.");
            }
        }




        public void DeleteEmployee(Employee employee)
        {
            if (!Employees.Contains(employee))
            {
                Console.WriteLine("Employee does not exist in the system.");
                return;
            }
            else
            {
                Employees.Remove(employee);
                Console.WriteLine($"{employee.Name} has successfully been removed.");
            }
        }

        public void ViewEmployeesByDepartment(Employee employee)
        {
            int counter = 1;
            Console.WriteLine("");
            Console.WriteLine($"No \tName \t\t\tDepartment");
            foreach (var e in Employees)
            {
                Console.WriteLine($"{counter}.\t{e.Name} \t\t{e.Department}");
                counter++;
            }
        }

        public void ViewEmployeesByPerformanceRating(Employee employee)
        {
            int counter = 1;
            Console.WriteLine($"No \tName \t\tPerformance Rating");
            foreach (var e in Employees)
            {
                Console.WriteLine($"{counter}.\t{e.Name} \t\t{e.PerformanceRating}");
                counter++;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Instances            
            // Employees
            Employee employee1 = new Employee("EMP001", "Michael Brown");
            Employee employee2 = new Employee("EMP002", "Sophia Johnson");
            Employee employee3 = new Employee("EMP003", "Liam Miller");
            Employee employee4 = new Employee("EMP004", "Emma Davis");
            Employee employee5 = new Employee("EMP005", "Noah Wilson");
            Employee employee6 = new Employee("EMP006", "Olivia Anderson");
            Employee employee7 = new Employee("EMP007", "William Thomas");
            Employee employee8 = new Employee("EMP008", "Ava Taylor");
            Employee employee9 = new Employee("EMP009", "James Martinez");
            Employee employee10 = new Employee("EMP010", "Isabella Robinson");

            // Testing Employee functionality
            Console.WriteLine($"{employee1.Name} has a rating of {employee1.PerformanceRating}");
            Console.WriteLine($"{employee1.Name}'s department: {employee1.Department}");
            //Console.WriteLine(employee1.EmployeeId);
            //employee1.EmployeeId = 3; // Error: 'Employee.EmployeeId' is read only
            //Console.WriteLine(employee1.EmployeeId);
            //Console.WriteLine(employee1.Name);
            // employee1.Name = "Ben"; // Error: 'Employee.Name' is read only
            //Console.WriteLine(employee1.Name);


            // EmployeeManager
            EmployeeManager employeeManager = new EmployeeManager();
            employeeManager.AddEmployee(employee1);
            employeeManager.AddEmployee(employee2);
            employeeManager.AddEmployee(employee3);
            employeeManager.AddEmployee(employee4);
            employeeManager.AddEmployee(employee5);
            employeeManager.ViewEmployeesByDepartment(employee7);

            Manager manager1 = new Manager("MGR001", "John Doe");
            manager1.AssignTeamMember(employee1);
            manager1.AssignTeamMember(employee2);
            manager1.AssignTeamMember(employee3);
            manager1.ViewTeamDetails();

        }
    }
}
