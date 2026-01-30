# LINQExample_3

## Overview

This project demonstrates **advanced LINQ operators** in C#. It covers equality, concatenation, aggregate, generation, set, partitioning, conversion operators, and special clauses like `let` and `into`.

---

## 🎯 Concepts Covered

### 1. **Equality Operator - SequenceEqual**

Compares two sequences for element-by-element equality.

```csharp
var integerList1 = new List<int> { 1, 2, 3, 4, 5, 6 };
var integerList2 = new List<int> { 1, 2, 3, 4, 5, 6 };

bool boolSequenceEqual = integerList1.SequenceEqual(integerList2); // true

// For custom objects, use IEqualityComparer
bool boolSE = employeeList.SequenceEqual(employeeListCompare, new EmployeeComparer());
```

---

### 2. **Concatenation Operator - Concat**

Combines two sequences into one.

```csharp
List<int> integerList1 = new List<int> { 1, 2, 3, 4 };
List<int> integerList2 = new List<int> { 5, 6, 7, 8, 9, 10 };

IEnumerable<int> integerListConcat = integerList1.Concat(integerList2);
```

---

### 3. **Aggregate Operators**

#### Aggregate

Performs a custom accumulation over a sequence.

```csharp
decimal totalAnnualSalary = employeeList.Aggregate<Employee, decimal>(0,
    (totAnnualSalary, e) =>
    {
        var bonus = (e.IsManager) ? 0.04m : 0.02m;
        return (e.AnnualSalary + (e.AnnualSalary * bonus)) + totAnnualSalary;
    });
```

#### Average, Count, Sum, Max

```csharp
decimal average = employeeList.Where(e => e.DepartmentId == 3).Average(e => e.AnnualSalary);
int count = employeeList.Count(e => e.DepartmentId == 3);
decimal sum = employeeList.Sum(e => e.AnnualSalary);
decimal max = employeeList.Max(e => e.AnnualSalary);
```

---

### 4. **Generation Operators**

#### DefaultIfEmpty

Returns a default value if the collection is empty.

```csharp
List<int> intList = new List<int>();
var newList = intList.DefaultIfEmpty(); // Returns single element with default value (0)
```

#### Empty

Creates an empty collection of a specified type.

```csharp
List<Employee> emptyEmployeeList = Enumerable.Empty<Employee>().ToList();
```

#### Range

Generates a sequence of integers within a specified range.

```csharp
var intCollection = Enumerable.Range(25, 20); // 25 to 44
```

#### Repeat

Repeats a value a specified number of times.

```csharp
var strCollection = Enumerable.Repeat<string>("Placeholder", 10);
```

---

### 5. **Set Operators**

| Operator    | Description                                     |
| ----------- | ----------------------------------------------- |
| `Distinct`  | Removes duplicate elements                      |
| `Except`    | Returns elements in first set but not in second |
| `Intersect` | Returns elements common to both sets            |
| `Union`     | Returns all unique elements from both sets      |

```csharp
// Distinct
var results = list.Distinct();

// Except
var results = collection1.Except(collection2);

// Intersect
var results = employeeList.Intersect(employeeList2, new EmployeeComparer());

// Union
var results = employeeList.Union(employeeList2, new EmployeeComparer());
```

---

### 6. **Partitioning Operators**

| Operator    | Description                            |
| ----------- | -------------------------------------- |
| `Skip(n)`   | Skips first n elements                 |
| `SkipWhile` | Skips elements while condition is true |
| `Take(n)`   | Takes first n elements                 |
| `TakeWhile` | Takes elements while condition is true |

```csharp
var results = employeeList.Skip(2);
var results = employeeList.SkipWhile(e => e.AnnualSalary > 50000);
var results = employeeList.Take(2);
var results = employeeList.TakeWhile(e => e.AnnualSalary > 50000);
```

---

### 7. **Conversion Operators**

```csharp
// ToList
List<Employee> results = (from emp in employeeList
                          where emp.AnnualSalary > 50000
                          select emp).ToList();

// ToDictionary
Dictionary<int, Employee> dictionary = (from emp in employeeList
                                         where emp.AnnualSalary > 50000
                                         select emp).ToDictionary<Employee, int>(e => e.Id);

// ToArray
Employee[] results = (from emp in employeeList
                      where emp.AnnualSalary > 50000
                      select emp).ToArray();
```

---

### 8. **Let and Into Clauses**

#### Let Clause

Stores the result of a sub-expression for reuse within the query.

```csharp
var results = from emp in employeeList
              let Initials = emp.FirstName.Substring(0, 1).ToUpper() +
                            emp.LastName.Substring(0, 1).ToUpper()
              let AnnualSalaryPlusBonus = (emp.IsManager)
                  ? emp.AnnualSalary + (emp.AnnualSalary * 0.04m)
                  : emp.AnnualSalary + (emp.AnnualSalary * 0.02m)
              where Initials == "JS" || Initials == "SJ"
              select new { Initials, FullName = emp.FirstName + " " + emp.LastName };
```

#### Into Clause

Stores results of a `group`, `join`, or `select` into a new identifier for further querying.

```csharp
var results = from emp in employeeList
              where emp.AnnualSalary > 50000
              select emp
              into HighEarners
              where HighEarners.IsManager == true
              select HighEarners;
```

---

### 9. **Projection Operators**

#### Select

Standard projection that maintains the structure of nested collections.

```csharp
var results = departmentList.Select(d => d.Employees);
// Returns IEnumerable<IEnumerable<Employee>> - nested structure
```

#### SelectMany

Flattens nested collections into a single sequence.

```csharp
var results = departmentList.SelectMany(d => d.Employees);
// Returns IEnumerable<Employee> - flattened structure
```

---

## 📁 Project Structure

| File               | Description                                               |
| ------------------ | --------------------------------------------------------- |
| `Program.cs`       | Contains all advanced LINQ operator examples              |
| `EmployeeComparer` | Custom comparer for set operations on Employee objects    |
| `Department` class | Includes `Employees` property for nested collection demos |

---

## 🚀 How to Run

```bash
cd LINQExample_3
dotnet run
```

---

## 📚 Key Takeaways

- **Aggregate operators** allow custom calculations across collections
- **Set operators** treat collections like mathematical sets
- **Partitioning operators** are useful for pagination
- **Let clause** improves query readability and performance
- **SelectMany** is essential for flattening hierarchical data
