using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace LINQExample_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartments();

            //Sorting operators OrderBy, OrderByDescending, ThenBy, ThenByDescending
            //Method syntax
            /*var results = employeeList.Join(departmentList,
                e => e.DepartmentId, d => d.Id,
                (emp, dept) => new
                {
                    Id = emp.Id,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    AnnualSalary = emp.AnnualSalary,
                    DepartmentId = emp.DepartmentId,
                    DepartmentName = dept.LongName
                }).OrderBy(o => o.DepartmentId).ThenBy(o => o.AnnualSalary);*/

            //Query syntax
            /*var results = from emp in employeeList
                          join dept in departmentList
                          on emp.DepartmentId equals dept.Id
                          orderby dept.Id, emp.AnnualSalary 
                          select new
                          {
                              Id = emp.Id,
                              FirstName = emp.FirstName,
                              LastName = emp.LastName,
                              AnnualSalary = emp.AnnualSalary,
                              DepartmentId = emp.DepartmentId,
                              DepartmentName = dept.LongName
                          };
            
             foreach (var item in results)
                Console.WriteLine($"Id: {item.Id, -5} First Name: {item.FirstName,-10} Last Name: {item.LastName,-10} Annual Salary: {item.AnnualSalary,10}\tDepartment Name: {item.DepartmentName}");*/


            //Grouping Operators GroupBy, ToLookup
            //query syntax
            /*var groupResult = from emp in employeeList
                              orderby emp.DepartmentId
                              group emp by emp.DepartmentId;*/
            //var groupResult = employeeList.GroupBy(e => e.DepartmentId);

            /*var groupResult = employeeList.OrderBy(e => e.DepartmentId).ToLookup(e =>e.DepartmentId);


            foreach (var empGroup in groupResult)
            {
                Console.WriteLine($"Department Id: {empGroup.Key}");

                foreach (var emp in empGroup)
                {
                    Console.WriteLine($"\tEmployee FullName: {emp.FirstName} {emp.LastName}");
                }
            }*/


            //All, Any, Contains Quantifier operators
            /* var annualSalaryCompare = 60000;
            bool isTrueAll = employeeList.All(e => e.AnnualSalary >  annualSalaryCompare);
            if(isTrueAll)
            {
                Console.WriteLine($"All employee annaul salaries are above {annualSalaryCompare}");
            }else
            {
                Console.WriteLine($"Not all employee annual salaries are above {annualSalaryCompare}");
            }

            bool isTrueAny = employeeList.Any(e => e.AnnualSalary > annualSalaryCompare);
            if (isTrueAny)
            {
                Console.WriteLine($"At least one employee has an annual salary above {annualSalaryCompare}");
            }
            else
            {
                Console.WriteLine($"No employee have an annual salary above {annualSalaryCompare}");
            }*/

            //contains operator
            /*var searchEmployee = new Employee
            {
                Id = 3,
                FirstName = "Douglas",
                LastName = "Roberts",
                AnnualSalary = 40000.2m,
                IsManager = false,
                DepartmentId = 2
            };

            bool containsEmployee = employeeList.Contains(searchEmployee, new EmployeeComparer());
            if (containsEmployee)
            {
                Console.WriteLine($"An employee record for {searchEmployee.FirstName} {searchEmployee.LastName} was found.");
            }
            else
            {
                Console.WriteLine($"An employee record for {searchEmployee.FirstName} {searchEmployee.LastName} was not found.");
            }*/


            //OfType filter Operator
            ArrayList mixedCollection = Data.GetHeterogeneousDataCollection();

            //var stringResult = from s in mixedCollection.OfType<string>()
            //                   select s;

            //var intResult = from i in mixedCollection.OfType<int>()
            //                select i;

            //foreach (var item in intResult)
            //    Console.WriteLine(item);

            //var employeeResults = from e in mixedCollection.OfType<Employee>()
            //                      select e;

            /*var departmentResults = from d in mixedCollection.OfType<Department>()
                                    select d;
            foreach (var dept in departmentResults)
                Console.WriteLine($"{dept.Id,-5}{dept.ShortName,-10}{dept.LongName,-10}");*/


            // ElementAt, ElementAtOrDefault operators
            //var emp = employeeList.ElementAtOrDefault(6);
            //if (emp != null)
            //    Console.WriteLine($"{emp.Id,-5}{emp.FirstName,-10}{emp.LastName,-10}");
            //else
            //    Console.WriteLine($"This employee record does not exist within the collection");


            //First, FirstOrDefault, Last, LastOrDefault operators
            //List<int> integerList = new List<int> { 3, 13, 23, 17, 23, 89 };
            List<int> integerList = new List<int> { 3, 14, 23, 17, 28, 89 };
            //int result = integerList.FirstOrDefault(i => i % 2 == 0);
            /*int result = integerList.LastOrDefault(i => i % 2 == 0);

            if (result != 0)
                Console.WriteLine(result);
            else
                Console.WriteLine("There are no event number in collection");*/

            //Single, SingleOrDefault operators
            var emp = employeeList.SingleOrDefault(e => e.Id == 11);
            if (emp != null)
                Console.WriteLine($"{emp.Id,-5}{emp.FirstName,-10}{emp.LastName,-10}");
            else
                Console.WriteLine("This employee does not exist within the collection");



        }
    }

    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee? x, Employee? y)
        {
            if (x.Id == y.Id && x.FirstName.ToLower() == y.FirstName.ToLower() && x.LastName.ToLower() == y.LastName.ToLower())
            {
                return true;
            }
            return false;
        }

        public int GetHashCode([DisallowNull] Employee obj)
        {
            return obj.Id.GetHashCode();
        }
    }

    public static class Data
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Jones",
                    AnnualSalary = 60000.3m,
                    IsManager = true,
                    DepartmentId = 1
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Sarah",
                    LastName = "Jameson",
                    AnnualSalary = 80000.1m,
                    IsManager = true,
                    DepartmentId = 3
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Douglas",
                    LastName = "Roberts",
                    AnnualSalary = 40000.2m,
                    IsManager = false,
                    DepartmentId = 2
                },
                new Employee
                {
                    Id = 4,
                    FirstName = "Jane",
                    LastName = "Stevens",
                    AnnualSalary = 30000.2m,
                    IsManager = false,
                    DepartmentId = 3
                }
            };
            return employees;
        }

        public static List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>
            {
                new Department
                {
                    Id = 1,
                    ShortName = "HR",
                    LongName = "Human Resources"
                },
                new Department
                {
                    Id = 2,
                    ShortName = "FN",
                    LongName = "Finance"
                },
                new Department
                {
                    Id = 3,
                    ShortName = "TE",
                    LongName = "Technology"
                }
            };
            return departments;
        }

        public static ArrayList GetHeterogeneousDataCollection()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(100);
            arrayList.Add("Bob Jones");
            arrayList.Add(2000);
            arrayList.Add(3000);
            arrayList.Add("Bill Henderson");
            arrayList.Add(new Employee { Id = 6, FirstName = "Jennifer", LastName = "Dale", AnnualSalary = 90000, IsManager = true, DepartmentId = 1 });
            arrayList.Add(new Employee { Id = 7, FirstName = "Dane", LastName = "Hughes", AnnualSalary = 60000, IsManager = false, DepartmentId = 2 });
            arrayList.Add(new Department { Id = 4, ShortName = "MKT", LongName = "Marketing" });
            arrayList.Add(new Department { Id = 5, ShortName = "R&D", LongName = "Research & Development" });
            arrayList.Add(new Department { Id = 6, ShortName = "PRD", LongName = "Production" });

            return arrayList;
        }
    }
    public class Department
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
    }
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public bool IsManager { get; set; }
        public int DepartmentId { get; set; }
    }
}
