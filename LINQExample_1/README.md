# LINQExample_1

## Overview

This project demonstrates the **foundational LINQ operators** and concepts in C#. It covers the basics of querying data using both **Method Syntax** and **Query Syntax**.

---

## 🎯 Concepts Covered

### 1. **Select and Where Operators**

The `Select` operator is used for **projection** (transforming data), while `Where` is used for **filtering** data based on a condition.

**Method Syntax:**
```csharp
var results = employeeList.Select(e => new
{
    FullName = e.FirstName + " " + e.LastName,
    AnnualSalary = e.AnnualSalary
}).Where(e => e.AnnualSalary > 50000);
```

**Query Syntax:**
```csharp
var results = from emp in employeeList
              where emp.AnnualSalary >= 50000
              select new
              {
                  FullName = emp.FirstName + " " + emp.LastName,
                  AnnualSalary = emp.AnnualSalary
              };
```

---

### 2. **Deferred Execution**

LINQ queries are **not executed immediately** when defined. They are executed **when the results are enumerated** (e.g., in a `foreach` loop). This allows for adding elements to the collection after the query is defined.

```csharp
var results = from emp in employeeList.GetHighSalariedEmplyees()
              select new { ... };

employeeList.Add(new Employee { ... }); // Added AFTER query definition

foreach (var result in results) // Query executes HERE
{
    Console.WriteLine($"{result.FullName,-20} : {result.AnnualSalary,10}");
}
```

> **Key Point:** The newly added employee will be included in the results because of deferred execution.

---

### 3. **Immediate Execution**

Using methods like `.ToList()`, `.ToArray()`, or `.Count()` forces the query to execute **immediately** and cache the results.

```csharp
var results = (from emp in employeeList.GetHighSalariedEmplyees()
              select new { ... }).ToList();

employeeList.Add(new Employee { ... }); // Added AFTER immediate execution

// The new employee will NOT be in results
```

---

### 4. **Join Operator**

The `Join` operator combines two collections based on a **matching key**.

**Method Syntax:**
```csharp
var results = departmentList.Join(employeeList,
    department => department.Id,
    employee => employee.DepartmentId,
    (department, employee) => new
    {
        FullName = employee.FirstName + " " + employee.LastName,
        DepartmentName = department.LongName
    });
```

**Query Syntax:**
```csharp
var results = from emp in employeeList
              join dept in departmentList
              on emp.DepartmentId equals dept.Id
              select new
              {
                  FullName = emp.FirstName + " " + emp.LastName,
                  DepartmentName = dept.LongName
              };
```

---

### 5. **GroupJoin Operator**

The `GroupJoin` operator is similar to `Join`, but it groups the matching elements from the second collection into a **collection of results** (one-to-many relationship).

**Method Syntax:**
```csharp
var results = departmentList.GroupJoin(employeeList,
    dept => dept.Id,
    emp => emp.DepartmentId,
    (dept, employeeGroup) => new
    {
        Employees = employeeGroup,
        DepartmentName = dept.LongName
    });
```

**Query Syntax:**
```csharp
var results = from dept in departmentList
              join emp in employeeList
              on dept.Id equals emp.DepartmentId
              into employeeGroup
              select new
              {
                  Employees = employeeGroup,
                  DepartmentName = dept.LongName
              };
```

---

## 📁 Project Structure

| File | Description |
|------|-------------|
| `Program.cs` | Contains all LINQ examples with Employee and Department data |
| `Employee` class | Represents employee data (Id, FirstName, LastName, AnnualSalary, IsManager, DepartmentId) |
| `Department` class | Represents department data (Id, ShortName, LongName) |
| `Data` class | Static class providing sample employee and department data |
| `EnumerableCollectionExtentionMethods` | Extension method demonstrating yield return for deferred execution |

---

## 🚀 How to Run

```bash
cd LINQExample_1
dotnet run
```

---

## 📚 Key Takeaways

- Use **Query Syntax** for complex queries with multiple joins and conditions
- Use **Method Syntax** for simple, chainable operations
- Understand the difference between **Deferred** and **Immediate** execution
- `Join` is for one-to-one relationships; `GroupJoin` is for one-to-many relationships
