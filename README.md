# LINQ Basics to Advanced

A comprehensive collection of C# projects demonstrating **Language Integrated Query (LINQ)** from fundamentals to advanced concepts.

---

## 📖 What is LINQ?

**LINQ (Language Integrated Query)** is a powerful feature in C# that provides a unified syntax for querying data from different sources like collections, databases, XML, and more. It brings query capabilities directly into the C# language.

### Why Use LINQ?

| Benefit          | Description                                                    |
| ---------------- | -------------------------------------------------------------- |
| **Readability**  | SQL-like syntax makes queries intuitive and easy to understand |
| **Type Safety**  | Compile-time checking catches errors before runtime            |
| **IntelliSense** | Full IDE support for auto-completion and documentation         |
| **Consistency**  | Same syntax works across arrays, lists, databases, XML, etc.   |
| **Productivity** | Write less code to accomplish complex data operations          |

### LINQ Syntax Styles

LINQ supports two syntax styles:

**1. Query Syntax** (SQL-like):

```csharp
var results = from emp in employees
              where emp.Salary > 50000
              orderby emp.Name
              select emp;
```

**2. Method Syntax** (Lambda expressions):

```csharp
var results = employees
    .Where(emp => emp.Salary > 50000)
    .OrderBy(emp => emp.Name);
```

---

## 🎯 When to Use LINQ

| Scenario            | LINQ Use Case                              |
| ------------------- | ------------------------------------------ |
| Filtering data      | `Where`, `OfType`                          |
| Sorting data        | `OrderBy`, `ThenBy`                        |
| Grouping data       | `GroupBy`, `ToLookup`                      |
| Joining collections | `Join`, `GroupJoin`                        |
| Transforming data   | `Select`, `SelectMany`                     |
| Aggregating values  | `Sum`, `Average`, `Count`, `Max`, `Min`    |
| Pagination          | `Skip`, `Take`                             |
| Removing duplicates | `Distinct`, `Union`, `Intersect`, `Except` |

---

## ⚡ LINQ Execution Types

### Deferred Execution

Query is **not executed** when defined. It executes when results are enumerated (e.g., in a `foreach` loop).

```csharp
var query = employees.Where(e => e.Salary > 50000); // Query defined, NOT executed
employees.Add(newEmployee); // New employee added
foreach (var emp in query) { } // Query executes HERE - includes new employee
```

### Immediate Execution

Query executes **immediately** when called using operators like `ToList()`, `ToArray()`, `Count()`, `First()`.

```csharp
var results = employees.Where(e => e.Salary > 50000).ToList(); // Executes NOW
employees.Add(newEmployee); // NOT included in results
```

---

## 📚 Best Practices

### ✅ Do's

1. **Use deferred execution** when data might change before enumeration
2. **Use `.ToList()` or `.ToArray()`** when you need to enumerate multiple times
3. **Chain operators** for better readability
4. **Use `let` clause** to avoid recalculating expressions
5. **Use `SelectMany`** to flatten nested collections
6. **Implement `IEqualityComparer<T>`** for custom object comparisons

### ❌ Don'ts

1. **Don't enumerate multiple times** without caching (performance issue)
2. **Don't forget** that `SingleOrDefault` throws exception if multiple matches exist
3. **Don't mix** deferred and immediate execution without understanding the impact
4. **Avoid complex queries** in a single statement - break them up for readability

---

## 🗂️ Projects in This Repository

### 1. ThePretendCompanyApplication

A **multi-project solution** demonstrating real-world LINQ usage with proper code organization.

| Project                          | Description                                                               |
| -------------------------------- | ------------------------------------------------------------------------- |
| **ThePretendCompanyApplication** | Main console application that joins employee and department data          |
| **TCPData**                      | Data layer containing `Employee` and `Department` models with sample data |
| **TCPExtentions**                | Custom extension methods including a generic `Filter<T>` method           |

**Key Concepts:**

- Multi-project architecture
- Custom LINQ-like extension methods using `Func<T, bool>`
- Join operator for combining Employee and Department data
- Aggregate operators (`Average`, `Max`, `Min`)

```csharp
// Custom Filter extension method (LINQ-like behavior)
public static List<T> Filter<T>(this List<T> records, Func<T, bool> func)
{
    List<T> filteredList = new List<T>();
    foreach (T record in records)
    {
        if (func(record))
            filteredList.Add(record);
    }
    return filteredList;
}
```

---

### 2. LINQExample_1

**Focus:** Foundational LINQ Operators

| Concept    | Operators             |
| ---------- | --------------------- |
| Projection | `Select`              |
| Filtering  | `Where`               |
| Joining    | `Join`, `GroupJoin`   |
| Execution  | Deferred vs Immediate |

**Key Learning:**

- Method Syntax vs Query Syntax
- Understanding when queries actually execute
- One-to-one (`Join`) vs one-to-many (`GroupJoin`) relationships

📁 [View LINQExample_1 README](https://github.com/KartikZCoding/csharp-LINQ-basics-to-advance/blob/59f55e018d5803209a85c1774581da3cd80d63b5/LINQExample_1/README.md)

---

### 3. LINQExample_2

**Focus:** Intermediate LINQ Operators

| Concept     | Operators                                                       |
| ----------- | --------------------------------------------------------------- |
| Sorting     | `OrderBy`, `OrderByDescending`, `ThenBy`, `ThenByDescending`    |
| Grouping    | `GroupBy`, `ToLookup`                                           |
| Quantifiers | `All`, `Any`, `Contains`                                        |
| Filtering   | `OfType`                                                        |
| Elements    | `ElementAt`, `First`, `Last`, `Single` (and OrDefault variants) |

**Key Learning:**

- Custom `IEqualityComparer<T>` for object comparisons
- Filtering heterogeneous collections with `OfType<T>`
- Difference between `GroupBy` (deferred) and `ToLookup` (immediate)

📁 [View LINQExample_2 README](https://github.com/KartikZCoding/csharp-LINQ-basics-to-advance/blob/59f55e018d5803209a85c1774581da3cd80d63b5/LINQExample_2/README.md)

---

### 4. LINQExample_3

**Focus:** Advanced LINQ Operators

| Concept        | Operators                                     |
| -------------- | --------------------------------------------- |
| Equality       | `SequenceEqual`                               |
| Concatenation  | `Concat`                                      |
| Aggregation    | `Aggregate`, `Average`, `Count`, `Sum`, `Max` |
| Generation     | `DefaultIfEmpty`, `Empty`, `Range`, `Repeat`  |
| Set Operations | `Distinct`, `Except`, `Intersect`, `Union`    |
| Partitioning   | `Skip`, `SkipWhile`, `Take`, `TakeWhile`      |
| Conversion     | `ToList`, `ToDictionary`, `ToArray`           |
| Query Clauses  | `let`, `into`                                 |
| Projection     | `Select`, `SelectMany`                        |

**Key Learning:**

- Custom aggregate calculations
- Mathematical set operations on collections
- Flattening nested collections with `SelectMany`
- Using `let` for query variable reuse

📁 [View LINQExample_3 README](https://github.com/KartikZCoding/csharp-LINQ-basics-to-advance/blob/59f55e018d5803209a85c1774581da3cd80d63b5/LINQExample_3/README.md)

---

## 📊 LINQ Operators Quick Reference

### Filtering

| Operator    | Description                           |
| ----------- | ------------------------------------- |
| `Where`     | Filters elements based on a predicate |
| `OfType<T>` | Filters elements by type              |

### Projection

| Operator     | Description                 |
| ------------ | --------------------------- |
| `Select`     | Transforms each element     |
| `SelectMany` | Flattens nested collections |

### Sorting

| Operator            | Description               |
| ------------------- | ------------------------- |
| `OrderBy`           | Sorts ascending           |
| `OrderByDescending` | Sorts descending          |
| `ThenBy`            | Secondary ascending sort  |
| `ThenByDescending`  | Secondary descending sort |
| `Reverse`           | Reverses the order        |

### Grouping

| Operator   | Description               |
| ---------- | ------------------------- |
| `GroupBy`  | Groups by key (deferred)  |
| `ToLookup` | Groups by key (immediate) |

### Joining

| Operator    | Description                   |
| ----------- | ----------------------------- |
| `Join`      | Inner join (one-to-one)       |
| `GroupJoin` | Left outer join (one-to-many) |

### Set Operations

| Operator    | Description                      |
| ----------- | -------------------------------- |
| `Distinct`  | Removes duplicates               |
| `Union`     | Combines unique elements         |
| `Intersect` | Common elements                  |
| `Except`    | Elements in first but not second |

### Aggregation

| Operator      | Description             |
| ------------- | ----------------------- |
| `Count`       | Number of elements      |
| `Sum`         | Sum of values           |
| `Average`     | Average value           |
| `Min` / `Max` | Minimum / Maximum value |
| `Aggregate`   | Custom accumulation     |

### Element Access

| Operator                           | Description                       |
| ---------------------------------- | --------------------------------- |
| `First` / `FirstOrDefault`         | First element                     |
| `Last` / `LastOrDefault`           | Last element                      |
| `Single` / `SingleOrDefault`       | Only element (throws if multiple) |
| `ElementAt` / `ElementAtOrDefault` | Element at index                  |

### Quantifiers

| Operator   | Description                 |
| ---------- | --------------------------- |
| `Any`      | At least one matches        |
| `All`      | All elements match          |
| `Contains` | Collection contains element |

### Partitioning

| Operator    | Description               |
| ----------- | ------------------------- |
| `Skip`      | Skip n elements           |
| `Take`      | Take n elements           |
| `SkipWhile` | Skip while condition true |
| `TakeWhile` | Take while condition true |

### Generation

| Operator         | Description                   |
| ---------------- | ----------------------------- |
| `Range`          | Generate sequence of integers |
| `Repeat`         | Repeat value n times          |
| `Empty`          | Create empty sequence         |
| `DefaultIfEmpty` | Default if empty              |

### Conversion

| Operator       | Description           |
| -------------- | --------------------- |
| `ToList`       | Convert to List       |
| `ToArray`      | Convert to Array      |
| `ToDictionary` | Convert to Dictionary |
| `AsEnumerable` | Cast to IEnumerable   |

---

## 🚀 Getting Started

### Prerequisites

- .NET SDK 6.0 or later
- Visual Studio 2022 / VS Code / Rider

### Running the Projects

```bash
# Clone the repository
git clone <repository-url>

# Navigate to the directory
cd "LINQ Basics to Adv"

# Run ThePretendCompanyApplication
cd ThePretendCompanyApplication
dotnet run

# Run individual examples
cd ../LINQExample_1 && dotnet run
cd ../LINQExample_2 && dotnet run
cd ../LINQExample_3 && dotnet run
```

---

## 📝 Learning Path

1. **Start with ThePretendCompanyApplication** - Understand project structure and basic LINQ usage
2. **Move to LINQExample_1** - Master fundamentals: Select, Where, Join, and execution types
3. **Continue with LINQExample_2** - Learn sorting, grouping, and element operators
4. **Finish with LINQExample_3** - Explore advanced operators and optimization techniques

---

## 🤝 Contributing

Feel free to fork this repository and submit pull requests for improvements or additional examples.

---

## 📄 License

This project is for educational purposes.
