namespace Employee_Management_System
{
    public class Employee
    {
        // Properties
        public string EmployeeId { get; private set; }
        public string Name { get; private set; }
        public string Department { get; set; }
        public int PerformanceRating { get; set; }
        public bool IsDeleted { get; set; }

        // Constructor - Initializer
        public Employee(string employeeId, string name)
        {
            EmployeeId = employeeId;
            Name = name;
            Department = "Unassigned";
            PerformanceRating = 0;
            IsDeleted = false;
        }

        // Methods
        //public void UpdateDetails(Employee employee)
        public void UpdateDetails(string name)
        {
            Name = name;
            Console.WriteLine($"Employee: {EmployeeId} name has been updated.");
        }

        public void AssignDepartment(string department)
        {
            Department = department;
            Console.WriteLine($"{Name} has successfully been assigned to {Department}");
        }

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
            if (!Team.Contains(employee) && employee.IsDeleted == false)
            {
                Team.Add(employee);
                Console.WriteLine($"{employee.Name} has successfully been added to {Name}'s team.");
            }
            else if (Team.Contains(employee))
            {
                Console.WriteLine($"{employee.Name} already exists in the team.");
            }
            else if (employee.IsDeleted == true)
            {
                Console.WriteLine("Employee has been removed from the system.");
            }
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


        public void UpdateEmployee(string employeeId, string newName)
        {
            // The below line is a LINQ method that basically says,
            // "Find the first employee in the list of employees where the employeeId matches the employeeId passed in the method."
            var employee = Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee != null)
            {
                employee.UpdateDetails(newName);
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        public void DeleteEmployee(string employeeId)
        {
            // The below line is a LINQ method that basically says,
            // "Find the first employee in the list of employees where the employeeId matches the employeeId passed in the method."
            var employee = Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee != null)
            {
                Employees.Remove(employee);
                employee.IsDeleted = true;
                Console.WriteLine($"{employee.Name} has successfully been removed.");
            }
            else
            {
                Console.WriteLine("No employee found.");
            }
        }

        public void ViewEmployeesByDepartment(string department)
        {
            int counter = 1;
            Console.WriteLine("");
            // Below line, retrieves a list of employees that belong to the department passed in the method
            var departmentEmployees = Employees.Where(e => e.Department == department).ToList();
            if (departmentEmployees.Count > 0)
            {
                Console.WriteLine($"No \tName \t\t\tDepartment");
                foreach (var employee in departmentEmployees)
                {
                    Console.WriteLine($"{counter}.\t{employee.Name} \t\t{employee.Department}");
                    counter++;
                }
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        public void ViewEmployeesByPerformanceRating(int performanceRating)
        {
            int counter = 1;
            Console.WriteLine("");
            // Below line, retrieves a list of employees that belong to the department passed in the method
            var departmentEmployees = Employees.Where(e => e.PerformanceRating == performanceRating).ToList();
            Console.WriteLine($"No \tName \t\t\tPerformance Rating");
            foreach (var employee in departmentEmployees)
            {
                Console.WriteLine($"{counter}.\t{employee.Name} \t\t{employee.PerformanceRating}");
                counter++;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /*Instances*/
            // Creating Employees
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

            /*Testing Employee functionality*/
            // Default values for newly created employees
            Console.WriteLine($"{employee1.Name} with {employee1.EmployeeId} has a default rating of {employee1.PerformanceRating}");
            Console.WriteLine($"{employee1.Name} with {employee1.EmployeeId} has a default department of: {employee1.Department}");

            // Testing UpdateDetails() functionality
            Console.WriteLine($"\nModifying {employee1.EmployeeId} name:");
            employee1.UpdateDetails("Noah Cyrus");
            Console.WriteLine($"{employee1.EmployeeId} new name is: {employee1.Name}");

            // Testing AssignDepartment() functionality
            Console.WriteLine($"\nAssigning employees to IT department:");
            employee1.AssignDepartment("IT");
            employee3.AssignDepartment("IT");
            employee5.AssignDepartment("IT");
            employee7.AssignDepartment("IT");
            employee9.AssignDepartment("IT");
            //Console.WriteLine($"{employee1.Name} has been assigned to {employee1.Department}");

            // Testing AddPerformanceRating() functionality
            Console.WriteLine($"\nAssigning performance rating to employees:");
            //Console.WriteLine($"\nAdding performance rating to {employee1.EmployeeId}:");
            employee1.AddPerformanceRating(4);
            Console.WriteLine($"{employee1.Name} now has a performance rating of: {employee1.PerformanceRating}");

            //Console.WriteLine($"\nAdding performance rating to {employee3.EmployeeId}:");
            employee3.AddPerformanceRating(4);
            Console.WriteLine($"{employee3.Name} now has a performance rating of: {employee3.PerformanceRating}");

            //Console.WriteLine($"\nAdding performance rating to {employee5.EmployeeId}:");
            employee5.AddPerformanceRating(4);
            Console.WriteLine($"{employee5.Name} now has a performance rating of: {employee5.PerformanceRating}");

            //Console.WriteLine($"\nAdding performance rating to {employee7.EmployeeId}:");
            employee7.AddPerformanceRating(4);
            Console.WriteLine($"{employee7.Name} now has a performance rating of: {employee7.PerformanceRating}");

            //Console.WriteLine($"\nAdding performance rating to {employee9.EmployeeId}:");
            employee9.AddPerformanceRating(4);
            Console.WriteLine($"{employee9.Name} now has a performance rating of: {employee9.PerformanceRating}");

            Console.WriteLine("");

            /*Testing EmployeeManager functionality*/
            // Adding a new employee manager
            EmployeeManager employeeManager = new EmployeeManager();

            // Adding a new employee to the employee manager
            Console.WriteLine("Adding new employees to EmployeeManager below: ");
            employeeManager.AddEmployee(employee1);
            employeeManager.AddEmployee(employee2);
            employeeManager.AddEmployee(employee3);
            employeeManager.AddEmployee(employee4);
            employeeManager.AddEmployee(employee5);

            // Testing UpdateEmployee() functionality
            Console.WriteLine($"\nUpdating {employee1.EmployeeId} name:");
            employeeManager.UpdateEmployee("EMP001", "Ryan Swims");
            Console.WriteLine($"{employee1.EmployeeId} new name is: {employee1.Name}");

            // Testing DeleteEmployee() functionality
            Console.WriteLine($"\nDeleting {employee1.EmployeeId}:");
            //employeeManager.DeleteEmployee("EMP001", "Michael Brown");
            employeeManager.DeleteEmployee("EMP001");

            // Testing ViewEmployeesByDepartment() functionality
            Console.WriteLine($"\nViewing employees in IT department:");
            employeeManager.ViewEmployeesByDepartment("IT");

            // Testing ViewEmployeesByPerformanceRating() functionality
            Console.WriteLine($"\nViewing employees with performance rating of 4:");
            employeeManager.ViewEmployeesByPerformanceRating(4);

            Console.WriteLine("");

            /*Testing Manager functionality*/
            // Creating a new manager
            Manager manager1 = new Manager("MGR001", "John Doe");

            // Assigning team members to the manager
            Console.WriteLine($"\nAssigning manager {manager1.Name} team members:");
            manager1.AssignTeamMember(employee1);
            manager1.AssignTeamMember(employee2);
            manager1.AssignTeamMember(employee2);
            manager1.AssignTeamMember(employee3);

            // Viewing team details
            Console.WriteLine($"\nViewing {manager1.Name} team members: ");
            manager1.ViewTeamDetails();


            Console.ReadKey();
        }
    }
}