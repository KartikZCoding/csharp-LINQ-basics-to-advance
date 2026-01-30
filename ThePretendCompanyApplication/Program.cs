using TCPData;
using TCPExtentions;

namespace ThePretendCompanyApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employeeList = Data.GetEmployees();

            //var filteredEmployees = employeeList.Filter(emp => emp.AnnualSalary > 50000);

            //foreach (var employee in filteredEmployees)
            //{

            //    Console.WriteLine($"First Name: {employee.FirstName}");
            //    Console.WriteLine($"Last Name: {employee.LastName}");
            //    Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
            //    Console.WriteLine($"Manager: {(employee.IsManager ? "Yes" : "No")}");
            //    Console.WriteLine();
            //}

            List<Department> departmentsList = Data.GetDepartments();

            //var filteredDepartments = departmentsList.Where(dpt => dpt.Id > 1 );

            //foreach (var department in filteredDepartments) {

            //    Console.WriteLine($"Id: {department.Id}");
            //    Console.WriteLine($"Short Name: {department.ShortName}");
            //    Console.WriteLine($"Long Name: {department.LongName}");
            //    Console.WriteLine();
            //}

            var resultList = from emp in employeeList
                             join dept in departmentsList
                             on emp.DepartmentId equals dept.Id
                             select new
                             {
                                 FirstName = emp.FirstName,
                                 LastName = emp.LastName,
                                 AnnualSalary = emp.AnnualSalary,
                                 Manager = (emp.IsManager ? "Yes" : "No"),
                                 Department = dept.LongName
                             };

            foreach (var result in resultList)
            {
                Console.WriteLine($"First Name: {result.FirstName}");
                Console.WriteLine($"Last Name: {result.LastName}");
                Console.WriteLine($"Annual Salary: {result.AnnualSalary}");
                Console.WriteLine($"Manager: {result.Manager}");
                Console.WriteLine($"Department: {result.Department}");
                Console.WriteLine();
            }

            var averageAnnualSalary = resultList.Average(a => a.AnnualSalary);
            var highestAnnualSalary = resultList.Max(a => a.AnnualSalary);
            var lowestAnnualSalary = resultList.Min(a => a.AnnualSalary);

            Console.WriteLine($"Average Annual Salary: {averageAnnualSalary}");
            Console.WriteLine($"Highest Annual Salary: {highestAnnualSalary}");
            Console.WriteLine($"Lowest Annual Salary: {lowestAnnualSalary}");

            Console.ReadKey();

        }
    }
}
