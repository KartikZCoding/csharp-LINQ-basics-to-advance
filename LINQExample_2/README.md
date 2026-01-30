# LINQExample_2

## Overview

This project demonstrates **intermediate LINQ operators** in C#. It covers sorting, grouping, quantifier operators, filter operators, and element operators.

---

## 🎯 Concepts Covered

### 1. **Sorting Operators**

LINQ provides multiple operators for ordering data: `OrderBy`, `OrderByDescending`, `ThenBy`, and `ThenByDescending`.

**Method Syntax:**

```csharp
var results = employeeList.Join(departmentList,
    e => e.DepartmentId, d => d.Id,
    (emp, dept) => new { ... })
    .OrderBy(o => o.DepartmentId)
    .ThenBy(o => o.AnnualSalary);
```

**Query Syntax:**

```csharp
var results = from emp in employeeList
              join dept in departmentList
              on emp.DepartmentId equals dept.Id
              orderby dept.Id, emp.AnnualSalary
              select new { ... };
```

---

### 2. **Grouping Operators**

#### GroupBy

Groups elements based on a key and returns an `IGrouping<TKey, TElement>`.

```csharp
// Method Syntax
var groupResult = employeeList.GroupBy(e => e.DepartmentId);

// Query Syntax
var groupResult = from emp in employeeList
                  orderby emp.DepartmentId
                  group emp by emp.DepartmentId;
```

#### ToLookup

Similar to `GroupBy` but creates an **immutable lookup table** with immediate execution.

```csharp
var groupResult = employeeList.OrderBy(e => e.DepartmentId)
                              .ToLookup(e => e.DepartmentId);
```

> **Note:** `GroupBy` uses deferred execution, while `ToLookup` executes immediately.

---

### 3. **Quantifier Operators**

#### All

Returns `true` if **all elements** satisfy the condition.

```csharp
bool isTrueAll = employeeList.All(e => e.AnnualSalary > 60000);
```

#### Any

Returns `true` if **at least one element** satisfies the condition.

```csharp
bool isTrueAny = employeeList.Any(e => e.AnnualSalary > 60000);
```

#### Contains

Checks if a collection contains a specific element. Requires implementing `IEqualityComparer<T>` for custom objects.

```csharp
bool containsEmployee = employeeList.Contains(searchEmployee, new EmployeeComparer());
```

---

### 4. **OfType Filter Operator**

Filters elements from a **non-generic collection** (like `ArrayList`) based on type.

```csharp
ArrayList mixedCollection = Data.GetHeterogeneousDataCollection();

// Get only strings
var stringResult = from s in mixedCollection.OfType<string>() select s;

// Get only integers
var intResult = from i in mixedCollection.OfType<int>() select i;

// Get only Employee objects
var employeeResults = from e in mixedCollection.OfType<Employee>() select e;
```

---

### 5. **Element Operators**

#### ElementAt / ElementAtOrDefault

Returns the element at a specified index.

```csharp
var emp = employeeList.ElementAtOrDefault(6); // Returns null if index doesn't exist
```

#### First / FirstOrDefault

Returns the first element matching the condition.

```csharp
int result = integerList.FirstOrDefault(i => i % 2 == 0);
```

#### Last / LastOrDefault

Returns the last element matching the condition.

```csharp
int result = integerList.LastOrDefault(i => i % 2 == 0);
```

#### Single / SingleOrDefault

Returns the **only element** matching the condition. Throws an exception if more than one match exists.

```csharp
var emp = employeeList.SingleOrDefault(e => e.Id == 11);
```

---

## 📁 Project Structure

| File                     | Description                                                                      |
| ------------------------ | -------------------------------------------------------------------------------- |
| `Program.cs`             | Contains examples of sorting, grouping, quantifier, and element operators        |
| `EmployeeComparer` class | Custom comparer implementing `IEqualityComparer<Employee>` for Contains operator |
| `Data` class             | Static class providing sample data including heterogeneous ArrayList             |

---

## 🚀 How to Run

```bash
cd LINQExample_2
dotnet run
```

---

## 📚 Key Takeaways

| Operator                    | Use Case                                                     |
| --------------------------- | ------------------------------------------------------------ |
| `OrderBy` / `ThenBy`        | Sorting data by single or multiple keys                      |
| `GroupBy`                   | Grouping data with deferred execution                        |
| `ToLookup`                  | Grouping data with immediate execution                       |
| `All` / `Any`               | Checking conditions across collection                        |
| `Contains`                  | Checking if element exists (use custom comparer for objects) |
| `OfType<T>`                 | Filtering mixed-type collections                             |
| `First` / `Last` / `Single` | Retrieving specific elements                                 |
| `ElementAt`                 | Accessing by index                                           |
