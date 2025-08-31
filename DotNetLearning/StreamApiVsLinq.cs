using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace DotNetLearning
{
    // Comprehensive Java Stream API vs .NET LINQ comparison
    public static class StreamApiVsLinq
    {
        // Sample data for examples
        private static readonly List<Employee> Employees = new List<Employee>
        {
            new Employee(1, "Alice Johnson", "Engineering", 75000, 28, "Senior"),
            new Employee(2, "Bob Smith", "Engineering", 65000, 25, "Junior"),
            new Employee(3, "Carol Davis", "Marketing", 55000, 30, "Senior"),
            new Employee(4, "David Wilson", "Engineering", 80000, 32, "Senior"),
            new Employee(5, "Eve Brown", "Marketing", 45000, 24, "Junior"),
            new Employee(6, "Frank Miller", "Sales", 60000, 29, "Mid"),
            new Employee(7, "Grace Lee", "Engineering", 70000, 27, "Mid"),
            new Employee(8, "Henry Taylor", "Sales", 52000, 26, "Junior"),
            new Employee(9, "Ivy Chen", "Marketing", 48000, 23, "Junior"),
            new Employee(10, "Jack Anderson", "Engineering", 85000, 35, "Senior")
        };

        private static readonly List<int> Numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20, 25, 30 };
        private static readonly List<string> Words = new List<string> 
        { 
            "apple", "banana", "cherry", "date", "elderberry", "fig", "grape", 
            "honeydew", "kiwi", "lemon", "mango", "nectarine", "orange", "papaya" 
        };

        public static async Task RunAllExamples()
        {
            Console.WriteLine("=== JAVA STREAM API vs .NET LINQ COMPREHENSIVE COMPARISON ===");
            Console.WriteLine("================================================================\n");

            // 1. Basic Operations
            FilteringExample();
            MappingExample();
            SortingExample();
            
            // 2. Intermediate Operations
            DistinctExample();
            LimitTakeExample();
            SkipExample();
            FlatMapExample();
            
            // 3. Terminal Operations
            ForEachExample();
            CollectExample();
            ReduceExample();
            FindExample();
            MatchExample();
            CountExample();
            MinMaxExample();
            
            // 4. Advanced Operations
            GroupingExample();
            PartitioningExample();
            JoiningExample();
            StatisticsExample();
            
            // 5. Complex Queries
            ComplexQueriesExample();
            NestedQueriesExample();
            MultipleDataSourcesExample();
            
            // 6. Performance Considerations
            LazyEvaluationExample();
            ParallelProcessingExample();
            
            // 7. Real-world Scenarios
            await DataProcessingScenarioExample();
            ReportingScenarioExample();
            
            await Task.Delay(1000);
        }

        // 1. FILTERING OPERATIONS
        private static void FilteringExample()
        {
            Console.WriteLine("1. FILTERING OPERATIONS");
            Console.WriteLine("========================");
            
            Console.WriteLine("Find employees with salary > 60000:");
            
            // Java Stream API:
            // employees.stream()
            //     .filter(emp -> emp.getSalary() > 60000)
            //     .collect(Collectors.toList())
            
            // C# LINQ:
            var highSalaryEmployees = Employees
                .Where(emp => emp.Salary > 60000)
                .ToList();
            
            foreach (var emp in highSalaryEmployees)
            {
                Console.WriteLine($"  {emp.Name}: ${emp.Salary:N0}");
            }
            
            Console.WriteLine("\nFind Engineering employees under 30:");
            
            // Java: employees.stream().filter(emp -> "Engineering".equals(emp.getDepartment()) && emp.getAge() < 30)
            // C# LINQ:
            var youngEngineers = Employees
                .Where(emp => emp.Department == "Engineering")
                .Where(emp => emp.Age < 30)
                .ToList();
            
            foreach (var emp in youngEngineers)
            {
                Console.WriteLine($"  {emp.Name}, Age: {emp.Age}");
            }
            
            Console.WriteLine("\nFind even numbers:");
            
            // Java: numbers.stream().filter(n -> n % 2 == 0)
            // C# LINQ:
            var evenNumbers = Numbers.Where(n => n % 2 == 0).ToList();
            Console.WriteLine($"  Even numbers: {string.Join(", ", evenNumbers)}");
            
            Console.WriteLine();
        }

        // 2. MAPPING OPERATIONS
        private static void MappingExample()
        {
            Console.WriteLine("2. MAPPING OPERATIONS");
            Console.WriteLine("=====================");
            
            Console.WriteLine("Get all employee names:");
            
            // Java: employees.stream().map(Employee::getName).collect(Collectors.toList())
            // C# LINQ:
            var employeeNames = Employees.Select(emp => emp.Name).ToList();
            Console.WriteLine($"  Names: {string.Join(", ", employeeNames)}");
            
            Console.WriteLine("\nCalculate annual bonuses (10% of salary):");
            
            // Java: employees.stream().map(emp -> emp.getSalary() * 0.1)
            // C# LINQ:
            var bonuses = Employees.Select(emp => emp.Salary * 0.1m).ToList();
            Console.WriteLine($"  Bonuses: {string.Join(", ", bonuses.Select(b => $"${b:N0}"))}");
            
            Console.WriteLine("\nSquare all numbers:");
            
            // Java: numbers.stream().map(n -> n * n)
            // C# LINQ:
            var squares = Numbers.Select(n => n * n).ToList();
            Console.WriteLine($"  Squares: {string.Join(", ", squares)}");
            
            Console.WriteLine("\nConvert words to uppercase:");
            
            // Java: words.stream().map(String::toUpperCase)
            // C# LINQ:
            var upperWords = Words.Select(w => w.ToUpper()).ToList();
            Console.WriteLine($"  Uppercase: {string.Join(", ", upperWords)}");
            
            Console.WriteLine("\nCreate employee summaries:");
            
            // Java: employees.stream().map(emp -> emp.getName() + " (" + emp.getDepartment() + ")")
            // C# LINQ:
            var summaries = Employees.Select(emp => $"{emp.Name} ({emp.Department})").ToList();
            foreach (var summary in summaries.Take(5))
            {
                Console.WriteLine($"  {summary}");
            }
            
            Console.WriteLine();
        }

        // 3. SORTING OPERATIONS
        private static void SortingExample()
        {
            Console.WriteLine("3. SORTING OPERATIONS");
            Console.WriteLine("=====================");
            
            Console.WriteLine("Sort employees by salary (ascending):");
            
            // Java: employees.stream().sorted(Comparator.comparing(Employee::getSalary))
            // C# LINQ:
            var sortedBySalary = Employees.OrderBy(emp => emp.Salary).ToList();
            foreach (var emp in sortedBySalary.Take(5))
            {
                Console.WriteLine($"  {emp.Name}: ${emp.Salary:N0}");
            }
            
            Console.WriteLine("\nSort employees by salary (descending):");
            
            // Java: employees.stream().sorted(Comparator.comparing(Employee::getSalary).reversed())
            // C# LINQ:
            var sortedBySalaryDesc = Employees.OrderByDescending(emp => emp.Salary).ToList();
            foreach (var emp in sortedBySalaryDesc.Take(5))
            {
                Console.WriteLine($"  {emp.Name}: ${emp.Salary:N0}");
            }
            
            Console.WriteLine("\nSort by multiple criteria (Department, then Salary desc):");
            
            // Java: employees.stream().sorted(Comparator.comparing(Employee::getDepartment)
            //                                         .thenComparing(Employee::getSalary).reversed())
            // C# LINQ:
            var multiSort = Employees
                .OrderBy(emp => emp.Department)
                .ThenByDescending(emp => emp.Salary)
                .ToList();
            
            foreach (var emp in multiSort)
            {
                Console.WriteLine($"  {emp.Department} - {emp.Name}: ${emp.Salary:N0}");
            }
            
            Console.WriteLine();
        }

        // 4. DISTINCT OPERATIONS
        private static void DistinctExample()
        {
            Console.WriteLine("4. DISTINCT OPERATIONS");
            Console.WriteLine("======================");
            
            Console.WriteLine("Get unique departments:");
            
            // Java: employees.stream().map(Employee::getDepartment).distinct()
            // C# LINQ:
            var departments = Employees.Select(emp => emp.Department).Distinct().ToList();
            Console.WriteLine($"  Departments: {string.Join(", ", departments)}");
            
            Console.WriteLine("\nGet unique experience levels:");
            
            // Java: employees.stream().map(Employee::getLevel).distinct()
            // C# LINQ:
            var levels = Employees.Select(emp => emp.Level).Distinct().ToList();
            Console.WriteLine($"  Levels: {string.Join(", ", levels)}");
            
            // Distinct with custom comparison
            Console.WriteLine("\nGet employees with unique salary ranges (rounded to nearest 10k):");
            
            // Java: employees.stream().collect(Collectors.toMap(emp -> emp.getSalary() / 10000 * 10000, 
            //                                                  Function.identity(), (e1, e2) -> e1))
            // C# LINQ:
            var uniqueSalaryRanges = Employees
                .GroupBy(emp => emp.Salary / 10000 * 10000)
                .Select(g => g.First())
                .ToList();
            
            foreach (var emp in uniqueSalaryRanges)
            {
                Console.WriteLine($"  {emp.Name}: ${emp.Salary:N0} (range: ${emp.Salary / 10000 * 10000:N0})");
            }
            
            Console.WriteLine();
        }

        // 5. LIMIT/TAKE AND SKIP OPERATIONS
        private static void LimitTakeExample()
        {
            Console.WriteLine("5. LIMIT/TAKE OPERATIONS");
            Console.WriteLine("========================");
            
            Console.WriteLine("Get first 3 employees:");
            
            // Java: employees.stream().limit(3)
            // C# LINQ:
            var firstThree = Employees.Take(3).ToList();
            foreach (var emp in firstThree)
            {
                Console.WriteLine($"  {emp.Name}");
            }
            
            Console.WriteLine("\nGet top 3 highest paid employees:");
            
            // Java: employees.stream().sorted(Comparator.comparing(Employee::getSalary).reversed()).limit(3)
            // C# LINQ:
            var topPaid = Employees
                .OrderByDescending(emp => emp.Salary)
                .Take(3)
                .ToList();
            
            foreach (var emp in topPaid)
            {
                Console.WriteLine($"  {emp.Name}: ${emp.Salary:N0}");
            }
            
            Console.WriteLine("\nGet first 5 words longer than 5 characters:");
            
            // Java: words.stream().filter(w -> w.length() > 5).limit(5)
            // C# LINQ:
            var longWords = Words
                .Where(w => w.Length > 5)
                .Take(5)
                .ToList();
            
            Console.WriteLine($"  Long words: {string.Join(", ", longWords)}");
            
            Console.WriteLine();
        }

        private static void SkipExample()
        {
            Console.WriteLine("6. SKIP OPERATIONS");
            Console.WriteLine("==================");
            
            Console.WriteLine("Skip first 3 employees:");
            
            // Java: employees.stream().skip(3)
            // C# LINQ:
            var afterSkip = Employees.Skip(3).Take(5).ToList();
            foreach (var emp in afterSkip)
            {
                Console.WriteLine($"  {emp.Name}");
            }
            
            Console.WriteLine("\nPagination: Skip 5, Take 3 (page 2):");
            
            // Java: employees.stream().skip(5).limit(3)
            // C# LINQ:
            var page2 = Employees.Skip(5).Take(3).ToList();
            foreach (var emp in page2)
            {
                Console.WriteLine($"  {emp.Name}");
            }
            
            Console.WriteLine("\nSkip while condition is true:");
            
            // Java: numbers.stream().dropWhile(n -> n < 5)
            // C# LINQ:
            var skipWhile = Numbers.SkipWhile(n => n < 5).ToList();
            Console.WriteLine($"  Numbers after skipping < 5: {string.Join(", ", skipWhile)}");
            
            Console.WriteLine("\nTake while condition is true:");
            
            // Java: numbers.stream().takeWhile(n -> n < 5)
            // C# LINQ:
            var takeWhile = Numbers.TakeWhile(n => n < 5).ToList();
            Console.WriteLine($"  Numbers while < 5: {string.Join(", ", takeWhile)}");
            
            Console.WriteLine();
        }

        // 6. FLATMAP OPERATIONS
        private static void FlatMapExample()
        {
            Console.WriteLine("7. FLATMAP OPERATIONS");
            Console.WriteLine("=====================");
            
            // Sample data with collections
            var teams = new List<Team>
            {
                new Team("Alpha", new List<string> { "Alice", "Bob", "Carol" }),
                new Team("Beta", new List<string> { "David", "Eve" }),
                new Team("Gamma", new List<string> { "Frank", "Grace", "Henry", "Ivy" })
            };
            
            Console.WriteLine("Get all team members (flatten teams):");
            
            // Java: teams.stream().flatMap(team -> team.getMembers().stream())
            // C# LINQ:
            var allMembers = teams.SelectMany(team => team.Members).ToList();
            Console.WriteLine($"  All members: {string.Join(", ", allMembers)}");
            
            Console.WriteLine("\nGet all characters from words:");
            
            // Java: words.stream().flatMap(word -> word.chars().mapToObj(c -> (char) c))
            // C# LINQ:
            var allChars = Words.Take(3).SelectMany(word => word.ToCharArray()).ToList();
            var allChars1 = Words.Take(3).Select(word => word.ToCharArray()).ToList();
            Console.WriteLine($"  First 3 words characters: {string.Join(", ", allChars)}");
            
            Console.WriteLine("\nGet departments and their employee names:");
            
            // Java: employees.stream().collect(Collectors.groupingBy(Employee::getDepartment))
            //                        .entrySet().stream()
            //                        .flatMap(entry -> entry.getValue().stream().map(Employee::getName))
            // C# LINQ:
            var deptEmployees = Employees
                .GroupBy(emp => emp.Department)
                .SelectMany(g => g.Select(emp => $"{g.Key}: {emp.Name}"))
                .ToList();
            
            foreach (var item in deptEmployees)
            {
                Console.WriteLine($"  {item}");
            }
            
            Console.WriteLine();
        }

        // 7. TERMINAL OPERATIONS - FOREACH
        private static void ForEachExample()
        {
            Console.WriteLine("8. FOREACH OPERATIONS");
            Console.WriteLine("=====================");
            
            Console.WriteLine("Print employee info with formatting:");
            
            // Java: employees.stream().forEach(emp -> System.out.println(emp.getName() + ": " + emp.getSalary()))
            // C# LINQ:
            Console.WriteLine("  Using LINQ ForEach:");
            Employees.Take(5).ToList().ForEach(emp => 
                Console.WriteLine($"    {emp.Name}: ${emp.Salary:N0} ({emp.Department})"));
            
            Console.WriteLine("\n  Using standard foreach:");
            foreach (var emp in Employees.Take(5))
            {
                Console.WriteLine($"    {emp.Name}: ${emp.Salary:N0} ({emp.Department})");
            }
            
            Console.WriteLine("\nConditional processing:");
            
            // Java: employees.stream().forEach(emp -> {
            //     if (emp.getSalary() > 70000) {
            //         System.out.println("High earner: " + emp.getName());
            //     }
            // })
            // C# LINQ:
            Employees.ForEach(emp => 
            {
                if (emp.Salary > 70000)
                {
                    Console.WriteLine($"  High earner: {emp.Name}");
                }
            });
            
            Console.WriteLine();
        }

        // 8. COLLECT OPERATIONS
        private static void CollectExample()
        {
            Console.WriteLine("9. COLLECT OPERATIONS");
            Console.WriteLine("=====================");
            
            Console.WriteLine("Collect to different collection types:");
            
            // Java: employees.stream().map(Employee::getName).collect(Collectors.toList())
            // C# LINQ:
            var namesList = Employees.Select(emp => emp.Name).ToList();
            Console.WriteLine($"  To List: {namesList.Count} names");
            
            // Java: employees.stream().map(Employee::getName).collect(Collectors.toSet())
            // C# LINQ:
            var namesSet = Employees.Select(emp => emp.Name).ToHashSet();
            Console.WriteLine($"  To HashSet: {namesSet.Count} unique names");
            
            // Java: employees.stream().collect(Collectors.toMap(Employee::getId, Employee::getName))
            // C# LINQ:
            var nameMap = Employees.ToDictionary(emp => emp.Id, emp => emp.Name);
            Console.WriteLine($"  To Dictionary: {nameMap.Count} id->name mappings");
            
            Console.WriteLine("\nCollect with custom logic:");
            
            // Java: employees.stream().collect(Collectors.partitioningBy(emp -> emp.getSalary() > 60000))
            // C# LINQ:
            var salaryPartition = Employees.ToLookup(emp => emp.Salary > 60000);
            Console.WriteLine($"  High salary: {salaryPartition[true].Count()}, Low salary: {salaryPartition[false].Count()}");
            
            Console.WriteLine();
        }

        // 9. REDUCE OPERATIONS
        private static void ReduceExample()
        {
            Console.WriteLine("10. REDUCE OPERATIONS");
            Console.WriteLine("=====================");
            
            Console.WriteLine("Sum all salaries:");
            
            // Java: employees.stream().map(Employee::getSalary).reduce(0, Integer::sum)
            // C# LINQ:
            var totalSalary = Employees.Select(emp => emp.Salary).Aggregate((sum, salary) => sum + salary);
            // Or simpler: var totalSalary = Employees.Sum(emp => emp.Salary);
            Console.WriteLine($"  Total salary: ${totalSalary:N0}");
            
            Console.WriteLine("\nFind maximum and minimum salary:");
            
            // Java: employees.stream().map(Employee::getSalary).reduce(Math::max)
            // C# LINQ:
            var maxSalary = Employees.Select(emp => emp.Salary).Aggregate((max, salary) => Math.Max(max, salary));
            // Or simpler: var maxSalary = Employees.Max(emp => emp.Salary);
            Console.WriteLine($"  Max salary: ${maxSalary:N0}");
            
            var minSalary = Employees.Min(emp => emp.Salary);
            Console.WriteLine($"  Min salary: ${minSalary:N0}");
            
            Console.WriteLine("\nConcatenate all employee names:");
            
            // Java: employees.stream().map(Employee::getName).reduce((n1, n2) -> n1 + ", " + n2)
            // C# LINQ:
            var allNames = Employees
                .Select(emp => emp.Name)
                .Aggregate((names, name) => names + ", " + name);
            Console.WriteLine($"  All names: {allNames}");
            
            Console.WriteLine("\nProduct of first 5 numbers:");
            
            // Java: numbers.stream().limit(5).reduce(1, (a, b) -> a * b)
            // C# LINQ:
            var product = Numbers.Take(5).Aggregate(1, (prod, num) => prod * num);
            Console.WriteLine($"  Product of first 5: {product}");
            
            Console.WriteLine();
        }

        // 10. FIND OPERATIONS
        private static void FindExample()
        {
            Console.WriteLine("11. FIND OPERATIONS");
            Console.WriteLine("===================");
            
            Console.WriteLine("Find first employee in Engineering:");
            
            // Java: employees.stream().filter(emp -> "Engineering".equals(emp.getDepartment())).findFirst()
            // C# LINQ:
            var firstEngineer = Employees.Where(emp => emp.Department == "Engineering").FirstOrDefault();
            Console.WriteLine($"  First engineer: {firstEngineer?.Name ?? "None"}");
            
            Console.WriteLine("\nFind any employee with salary > 75000:");
            
            // Java: employees.stream().filter(emp -> emp.getSalary() > 75000).findAny()
            // C# LINQ: (Note: C# doesn't have FindAny, but First() serves similar purpose)
            var highEarner = Employees.Where(emp => emp.Salary > 75000).FirstOrDefault();
            Console.WriteLine($"  High earner: {firstEngineer?.Name ?? "None"}");
            
            Console.WriteLine("\nFind last employee (alphabetically):");
            
            // Java: employees.stream().max(Comparator.comparing(Employee::getName))
            // C# LINQ:
            var lastAlphabetically = Employees.OrderBy(emp => emp.Name).LastOrDefault();
            Console.WriteLine($"  Last alphabetically: {lastAlphabetically?.Name ?? "None"}");
            
            Console.WriteLine("\nFind employee with specific criteria:");
            
            // C# LINQ: Single vs First vs FirstOrDefault
            var specificEmployee = Employees.SingleOrDefault(emp => emp.Id == 5);
            Console.WriteLine($"  Employee with ID 5: {specificEmployee?.Name ?? "None"}");
            
            Console.WriteLine();
        }

        // 11. MATCH OPERATIONS
        private static void MatchExample()
        {
            Console.WriteLine("12. MATCH OPERATIONS");
            Console.WriteLine("====================");
            
            Console.WriteLine("Check if any employee earns > 80000:");
            
            // Java: employees.stream().anyMatch(emp -> emp.getSalary() > 80000)
            // C# LINQ:
            var anyHighEarner = Employees.Any(emp => emp.Salary > 80000);
            Console.WriteLine($"  Any high earner: {anyHighEarner}");
            
            Console.WriteLine("\nCheck if all employees are over 18:");
            
            // Java: employees.stream().allMatch(emp -> emp.getAge() > 18)
            // C# LINQ:
            var allAdults = Employees.All(emp => emp.Age > 18);
            Console.WriteLine($"  All adults: {allAdults}");
            
            Console.WriteLine("\nCheck if no employee is over 40:");
            
            // Java: employees.stream().noneMatch(emp -> emp.getAge() > 40)
            // C# LINQ: (C# doesn't have NoneMatch, use !Any())
            var noneOver40 = !Employees.Any(emp => emp.Age > 40);
            Console.WriteLine($"  None over 40: {noneOver40}");
            
            Console.WriteLine("\nCheck department-specific conditions:");
            
            var allEngineersWellPaid = Employees
                .Where(emp => emp.Department == "Engineering")
                .All(emp => emp.Salary > 60000);
            Console.WriteLine($"  All engineers earn > 60k: {allEngineersWellPaid}");
            
            Console.WriteLine();
        }

        // 12. COUNT, MIN, MAX OPERATIONS
        private static void CountExample()
        {
            Console.WriteLine("13. COUNT OPERATIONS");
            Console.WriteLine("====================");
            
            Console.WriteLine("Count employees by department:");
            
            // Java: employees.stream().collect(Collectors.groupingBy(Employee::getDepartment, Collectors.counting()))
            // C# LINQ:
            var countByDept = Employees
                .GroupBy(emp => emp.Department)
                .ToDictionary(g => g.Key, g => g.Count());
            
            foreach (var dept in countByDept)
            {
                Console.WriteLine($"  {dept.Key}: {dept.Value} employees");
            }
            
            Console.WriteLine("\nCount employees with high salary:");
            
            // Java: employees.stream().filter(emp -> emp.getSalary() > 65000).count()
            // C# LINQ:
            var highSalaryCount = Employees.Count(emp => emp.Salary > 65000);
            Console.WriteLine($"  High salary employees: {highSalaryCount}");
            
            Console.WriteLine();
        }

        private static void MinMaxExample()
        {
            Console.WriteLine("14. MIN/MAX OPERATIONS");
            Console.WriteLine("======================");
            
            Console.WriteLine("Statistics by department:");
            
            // Java: employees.stream().collect(Collectors.groupingBy(Employee::getDepartment,
            //           Collectors.summarizingInt(Employee::getSalary)))
            // C# LINQ:
            var deptStats = Employees
                .GroupBy(emp => emp.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    Count = g.Count(),
                    MinSalary = g.Min(emp => emp.Salary),
                    MaxSalary = g.Max(emp => emp.Salary),
                    AvgSalary = g.Average(emp => emp.Salary),
                    TotalSalary = g.Sum(emp => emp.Salary)
                })
                .ToList();
            
            foreach (var stat in deptStats)
            {
                Console.WriteLine($"  {stat.Department}:");
                Console.WriteLine($"    Count: {stat.Count}");
                Console.WriteLine($"    Salary Range: ${stat.MinSalary:N0} - ${stat.MaxSalary:N0}");
                Console.WriteLine($"    Average: ${stat.AvgSalary:N0}");
                Console.WriteLine($"    Total: ${stat.TotalSalary:N0}");
            }
            
            Console.WriteLine();
        }

        // 13. GROUPING OPERATIONS
        private static void GroupingExample()
        {
            Console.WriteLine("15. GROUPING OPERATIONS");
            Console.WriteLine("=======================");
            
            Console.WriteLine("Group employees by department:");
            
            // Java: employees.stream().collect(Collectors.groupingBy(Employee::getDepartment))
            // C# LINQ:
            var byDepartment = Employees.GroupBy(emp => emp.Department);
            
            foreach (var group in byDepartment)
            {
                Console.WriteLine($"  {group.Key}: {string.Join(", ", group.Select(emp => emp.Name))}");
            }
            
            Console.WriteLine("\nGroup by salary ranges:");
            
            // Java: employees.stream().collect(Collectors.groupingBy(emp -> emp.getSalary() / 10000))
            // C# LINQ:
            var bySalaryRange = Employees
                .GroupBy(emp => emp.Salary / 10000 * 10000)
                .OrderBy(g => g.Key)
                .ToList();
            
            foreach (var group in bySalaryRange)
            {
                Console.WriteLine($"  ${group.Key:N0}+: {string.Join(", ", group.Select(emp => emp.Name))}");
            }
            
            Console.WriteLine("\nMulti-level grouping (Department -> Level):");
            
            // Java: employees.stream().collect(Collectors.groupingBy(Employee::getDepartment,
            //           Collectors.groupingBy(Employee::getLevel)))
            // C# LINQ:
            var multiLevel = Employees
                .GroupBy(emp => emp.Department)
                .ToDictionary(
                    deptGroup => deptGroup.Key,
                    deptGroup => deptGroup.GroupBy(emp => emp.Level).ToDictionary(
                        levelGroup => levelGroup.Key,
                        levelGroup => levelGroup.ToList()
                    )
                );
            
            foreach (var dept in multiLevel)
            {
                Console.WriteLine($"  {dept.Key}:");
                foreach (var level in dept.Value)
                {
                    Console.WriteLine($"    {level.Key}: {string.Join(", ", level.Value.Select(emp => emp.Name))}");
                }
            }
            
            Console.WriteLine();
        }

        // 14. PARTITIONING OPERATIONS
        private static void PartitioningExample()
        {
            Console.WriteLine("16. PARTITIONING OPERATIONS");
            Console.WriteLine("============================");
            
            Console.WriteLine("Partition employees by salary > 60000:");
            
            // Java: employees.stream().collect(Collectors.partitioningBy(emp -> emp.getSalary() > 60000))
            // C# LINQ:
            var salaryPartition = Employees.ToLookup(emp => emp.Salary > 60000);
            
            Console.WriteLine($"  High salary ({salaryPartition[true].Count()}):");
            foreach (var emp in salaryPartition[true])
            {
                Console.WriteLine($"    {emp.Name}: ${emp.Salary:N0}");
            }
            
            Console.WriteLine($"\n  Regular salary ({salaryPartition[false].Count()}):");
            foreach (var emp in salaryPartition[false])
            {
                Console.WriteLine($"    {emp.Name}: ${emp.Salary:N0}");
            }
            
            Console.WriteLine("\nPartition numbers by even/odd:");
            
            // Java: numbers.stream().collect(Collectors.partitioningBy(n -> n % 2 == 0))
            // C# LINQ:
            var numberPartition = Numbers.ToLookup(n => n % 2 == 0);
            Console.WriteLine($"  Even: {string.Join(", ", numberPartition[true])}");
            Console.WriteLine($"  Odd: {string.Join(", ", numberPartition[false])}");
            
            Console.WriteLine();
        }

        // 15. JOINING OPERATIONS
        private static void JoiningExample()
        {
            Console.WriteLine("17. JOINING OPERATIONS");
            Console.WriteLine("======================");
            
            Console.WriteLine("Join employee names with commas:");
            
            // Java: employees.stream().map(Employee::getName).collect(Collectors.joining(", "))
            // C# LINQ:
            var joinedNames = string.Join(", ", Employees.Select(emp => emp.Name));
            Console.WriteLine($"  Names: {joinedNames}");
            
            Console.WriteLine("\nJoin with prefix and suffix:");
            
            // Java: employees.stream().map(Employee::getName).collect(Collectors.joining(", ", "[", "]"))
            // C# LINQ:
            var formattedNames = "[" + string.Join(", ", Employees.Select(emp => emp.Name)) + "]";
            Console.WriteLine($"  Formatted: {formattedNames}");
            
            Console.WriteLine("\nJoin department names uniquely:");
            
            var uniqueDepts = string.Join(" | ", Employees.Select(emp => emp.Department).Distinct());
            Console.WriteLine($"  Departments: {uniqueDepts}");
            
            Console.WriteLine();
        }

        // 16. COMPLEX QUERIES
        private static void ComplexQueriesExample()
        {
            Console.WriteLine("18. COMPLEX QUERIES");
            Console.WriteLine("===================");
            
            Console.WriteLine("Find highest paid employee in each department:");
            
            // Java: employees.stream().collect(Collectors.groupingBy(Employee::getDepartment,
            //           Collectors.maxBy(Comparator.comparing(Employee::getSalary))))
            // C# LINQ:
            var topByDept = Employees
                .GroupBy(emp => emp.Department)
                .Select(g => g.OrderByDescending(emp => emp.Salary).First())
                .ToList();
            
            foreach (var emp in topByDept)
            {
                Console.WriteLine($"  {emp.Department}: {emp.Name} (${emp.Salary:N0})");
            }
            
            Console.WriteLine("\nFind employees with above-average salary in their department:");
            
            // C# LINQ: More complex than Java streams for this case
            var deptAverages = Employees
                .GroupBy(emp => emp.Department)
                .ToDictionary(g => g.Key, g => g.Average(emp => emp.Salary));
            
            var aboveAverage = Employees
                .Where(emp => emp.Salary > deptAverages[emp.Department])
                .OrderBy(emp => emp.Department)
                .ThenByDescending(emp => emp.Salary)
                .ToList();
            
            foreach (var emp in aboveAverage)
            {
                Console.WriteLine($"  {emp.Name} ({emp.Department}): ${emp.Salary:N0} vs avg ${deptAverages[emp.Department]:N0}");
            }
            
            Console.WriteLine("\nTop 2 employees by salary in each department:");
            
            var top2ByDept = Employees
                .GroupBy(emp => emp.Department)
                .SelectMany(g => g.OrderByDescending(emp => emp.Salary).Take(2))
                .OrderBy(emp => emp.Department)
                .ThenByDescending(emp => emp.Salary)
                .ToList();
            
            foreach (var emp in top2ByDept)
            {
                Console.WriteLine($"  {emp.Department}: {emp.Name} (${emp.Salary:N0})");
            }
            
            Console.WriteLine();
        }

        // 17. NESTED QUERIES
        private static void NestedQueriesExample()
        {
            Console.WriteLine("19. NESTED QUERIES");
            Console.WriteLine("==================");
            
            Console.WriteLine("Find employees in departments with more than 2 people:");
            
            // Java: Complex nested stream operations
            // C# LINQ:
            var largeDepts = Employees
                .GroupBy(emp => emp.Department)
                .Where(g => g.Count() > 2)
                .SelectMany(g => g)
                .OrderBy(emp => emp.Department)
                .ThenBy(emp => emp.Name)
                .ToList();
            
            foreach (var emp in largeDepts)
            {
                Console.WriteLine($"  {emp.Name} ({emp.Department})");
            }
            
            Console.WriteLine("\nFind departments where average salary > overall average:");
            
            var overallAverage = Employees.Average(emp => emp.Salary);
            var highPayingDepts = Employees
                .GroupBy(emp => emp.Department)
                .Where(g => g.Average(emp => emp.Salary) > overallAverage)
                .Select(g => new
                {
                    Department = g.Key,
                    AverageSalary = g.Average(emp => emp.Salary),
                    EmployeeCount = g.Count()
                })
                .ToList();
            
            Console.WriteLine($"  Overall average: ${overallAverage:N0}");
            foreach (var dept in highPayingDepts)
            {
                Console.WriteLine($"  {dept.Department}: ${dept.AverageSalary:N0} avg ({dept.EmployeeCount} employees)");
            }
            
            Console.WriteLine();
        }

        // 18. MULTIPLE DATA SOURCES
        private static void MultipleDataSourcesExample()
        {
            Console.WriteLine("20. MULTIPLE DATA SOURCES");
            Console.WriteLine("=========================");
            
            // Additional data source
            var departments = new List<Department>
            {
                new Department("Engineering", "Technology", "John Smith"),
                new Department("Marketing", "Business", "Jane Doe"),
                new Department("Sales", "Business", "Bob Johnson")
            };
            
            Console.WriteLine("Join employees with department info:");
            
            // Java: employees.stream().flatMap(emp -> departments.stream()
            //           .filter(dept -> dept.getName().equals(emp.getDepartment()))
            //           .map(dept -> new EmployeeDeptInfo(emp, dept)))
            // C# LINQ:
            var empDeptInfo = Employees
                .Join(departments,
                      emp => emp.Department,
                      dept => dept.Name,
                      (emp, dept) => new
                      {
                          Employee = emp.Name,
                          Department = dept.Name,
                          Division = dept.Division,
                          Manager = dept.Manager,
                          Salary = emp.Salary
                      })
                .OrderBy(x => x.Division)
                .ThenBy(x => x.Department)
                .ToList();
            
            foreach (var info in empDeptInfo)
            {
                Console.WriteLine($"  {info.Employee} | {info.Department} ({info.Division}) | Manager: {info.Manager}");
            }
            
            Console.WriteLine("\nGroup by division with statistics:");
            
            var divisionStats = empDeptInfo
                .GroupBy(x => x.Division)
                .Select(g => new
                {
                    Division = g.Key,
                    EmployeeCount = g.Count(),
                    AverageSalary = g.Average(x => x.Salary),
                    Departments = g.Select(x => x.Department).Distinct().Count()
                })
                .ToList();
            
            foreach (var stat in divisionStats)
            {
                Console.WriteLine($"  {stat.Division}: {stat.EmployeeCount} employees, {stat.Departments} departments, ${stat.AverageSalary:N0} avg salary");
            }
            
            Console.WriteLine();
        }

        // 19. LAZY EVALUATION
        private static void LazyEvaluationExample()
        {
            Console.WriteLine("21. LAZY EVALUATION");
            Console.WriteLine("===================");
            
            Console.WriteLine("Demonstrating lazy evaluation:");
            
            // Java: Stream operations are lazy until terminal operation
            // C# LINQ: Same behavior - lazy evaluation
            
            Console.WriteLine("  Creating query (no execution yet)...");
            var lazyQuery = Employees
                .Where(emp => { Console.WriteLine($"    Filtering: {emp.Name}"); return emp.Salary > 60000; })
                .Select(emp => { Console.WriteLine($"    Mapping: {emp.Name}"); return emp.Name.ToUpper(); });
            
            Console.WriteLine("  Query created, no output above because it's lazy");
            
            Console.WriteLine("\n  Now executing with Take(2):");
            var result = lazyQuery.Take(2).ToList();
            
            Console.WriteLine($"  Result: {string.Join(", ", result)}");
            Console.WriteLine("  Notice: Only processed employees until 2 results were found");
            
            Console.WriteLine();
        }

        // 20. PARALLEL PROCESSING
        private static void ParallelProcessingExample()
        {
            Console.WriteLine("22. PARALLEL PROCESSING");
            Console.WriteLine("=======================");
            
            Console.WriteLine("Sequential vs Parallel processing:");
            
            // Create larger dataset for demonstration
            var largeNumberSet = Enumerable.Range(1, 1000000).ToList();
            
            // Sequential processing
            // Java: numbers.stream().map(n -> expensiveOperation(n))
            // C# LINQ:
            var sw = System.Diagnostics.Stopwatch.StartNew();
            double sequentialResult = largeNumberSet
                .Take(10000)
                .Where(n => n % 2 == 0)
                .Select(n => n * n)
                .Select(n => (double)n)
                .Sum();
            sw.Stop();
            Console.WriteLine($"  Sequential: {sequentialResult} (took {sw.ElapsedMilliseconds}ms)");
            
            // Parallel processing
            // Java: numbers.parallelStream().map(n -> expensiveOperation(n))
            // C# LINQ:
            sw.Restart();
            double parallelResult = largeNumberSet
                .Take(10000)
                .AsParallel() // This makes it parallel
                .Where(n => n % 2 == 0)
                .Select(n => n * n)
                .Select(n => (double)n)
                .Sum();
            sw.Stop();
            Console.WriteLine($"  Parallel: {parallelResult} (took {sw.ElapsedMilliseconds}ms)");
            
            Console.WriteLine("\nParallel processing with employee data:");
            
            // Parallel grouping and aggregation
            var parallelStats = Employees
                .AsParallel()
                .GroupBy(emp => emp.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    AvgSalary = g.Average(emp => emp.Salary),
                    Count = g.Count()
                })
                .OrderBy(x => x.Department)
                .ToList();
            
            foreach (var stat in parallelStats)
            {
                Console.WriteLine($"  {stat.Department}: {stat.Count} employees, ${stat.AvgSalary:N0} average");
            }
            
            Console.WriteLine();
        }

        // 21. REAL-WORLD SCENARIO: DATA PROCESSING
        private static async Task DataProcessingScenarioExample()
        {
            Console.WriteLine("23. REAL-WORLD SCENARIO: DATA PROCESSING");
            Console.WriteLine("========================================");
            
            Console.WriteLine("Processing employee data for payroll report:");
            
            // Simulate reading from file/database
            await Task.Delay(100); // Simulate async I/O
            
            // Complex processing pipeline
            var payrollData = Employees
                .Where(emp => emp.Department != "Intern") // Filter out interns
                .Select(emp => new // Transform to payroll record
                {
                    emp.Id,
                    emp.Name,
                    emp.Department,
                    emp.Salary,
                    Bonus = CalculateBonus(emp),
                    Tax = CalculateTax(emp.Salary),
                    NetPay = emp.Salary + CalculateBonus(emp) - CalculateTax(emp.Salary)
                })
                .OrderBy(x => x.Department)
                .ThenByDescending(x => x.NetPay)
                .ToList();
            
            // Generate summary report
            var departmentSummary = payrollData
                .GroupBy(x => x.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    EmployeeCount = g.Count(),
                    TotalSalary = g.Sum(x => x.Salary),
                    TotalBonus = g.Sum(x => x.Bonus),
                    TotalTax = g.Sum(x => x.Tax),
                    TotalNetPay = g.Sum(x => x.NetPay),
                    AvgNetPay = g.Average(x => x.NetPay)
                })
                .OrderByDescending(x => x.TotalNetPay)
                .ToList();
            
            Console.WriteLine("  Department Summary:");
            foreach (var summary in departmentSummary)
            {
                Console.WriteLine($"    {summary.Department}:");
                Console.WriteLine($"      Employees: {summary.EmployeeCount}");
                Console.WriteLine($"      Total Compensation: ${summary.TotalNetPay:N0}");
                Console.WriteLine($"      Average Net Pay: ${summary.AvgNetPay:N0}");
            }
            
            // Find top performers
            var topPerformers = payrollData
                .Where(x => x.Bonus > 5000) // High bonus indicates good performance
                .OrderByDescending(x => x.Bonus)
                .Take(3)
                .ToList();
            
            Console.WriteLine("\n  Top Performers (by bonus):");
            foreach (var performer in topPerformers)
            {
                Console.WriteLine($"    {performer.Name} ({performer.Department}): ${performer.Bonus:N0} bonus");
            }
            
            Console.WriteLine();
        }

        // Helper methods for payroll calculation
        private static decimal CalculateBonus(Employee emp)
        {
            return emp.Level switch
            {
                "Senior" => emp.Salary * 0.15m,
                "Mid" => emp.Salary * 0.10m,
                "Junior" => emp.Salary * 0.05m,
                _ => 0
            };
        }
        
        private static decimal CalculateTax(decimal salary)
        {
            return salary * 0.25m; // Simplified tax calculation
        }

        // 22. REPORTING SCENARIO
        private static void ReportingScenarioExample()
        {
            Console.WriteLine("24. REAL-WORLD SCENARIO: REPORTING");
            Console.WriteLine("==================================");
            
            Console.WriteLine("Generating comprehensive employee report:");
            
            // Multi-dimensional analysis
            var report = new
            {
                TotalEmployees = Employees.Count(),
                TotalPayroll = Employees.Sum(emp => emp.Salary),
                AverageSalary = Employees.Average(emp => emp.Salary),
                
                DepartmentBreakdown = Employees
                    .GroupBy(emp => emp.Department)
                    .Select(g => new
                    {
                        Department = g.Key,
                        Count = g.Count(),
                        AvgSalary = g.Average(emp => emp.Salary),
                        AvgAge = g.Average(emp => emp.Age),
                        SeniorCount = g.Count(emp => emp.Level == "Senior")
                    })
                    .OrderBy(x => x.Department)
                    .ToList(),
                
                AgeGroups = Employees
                    .GroupBy(emp => emp.Age / 10 * 10) // Group by decade
                    .Select(g => new
                    {
                        AgeRange = $"{g.Key}-{g.Key + 9}",
                        Count = g.Count(),
                        AvgSalary = g.Average(emp => emp.Salary)
                    })
                    .OrderBy(x => x.AgeRange)
                    .ToList(),
                
                LevelDistribution = Employees
                    .GroupBy(emp => emp.Level)
                    .ToDictionary(g => g.Key, g => g.Count()),
                
                SalaryBrackets = Employees
                    .GroupBy(emp => emp.Salary / 10000 * 10000)
                    .Select(g => new
                    {
                        Range = $"${g.Key:N0} - ${g.Key + 9999:N0}",
                        Count = g.Count()
                    })
                    .OrderBy(x => x.Range)
                    .ToList()
            };
            
            // Print report
            Console.WriteLine($"  Total Employees: {report.TotalEmployees}");
            Console.WriteLine($"  Total Payroll: ${report.TotalPayroll:N0}");
            Console.WriteLine($"  Average Salary: ${report.AverageSalary:N0}");
            
            Console.WriteLine("\n  Department Breakdown:");
            foreach (var dept in report.DepartmentBreakdown)
            {
                Console.WriteLine($"    {dept.Department}: {dept.Count} emp, ${dept.AvgSalary:N0} avg, {dept.SeniorCount} senior");
            }
            
            Console.WriteLine("\n  Age Distribution:");
            foreach (var age in report.AgeGroups)
            {
                Console.WriteLine($"    {age.AgeRange}: {age.Count} employees, ${age.AvgSalary:N0} avg salary");
            }
            
            Console.WriteLine("\n  Experience Level:");
            foreach (var level in report.LevelDistribution)
            {
                Console.WriteLine($"    {level.Key}: {level.Value} employees");
            }
            
            Console.WriteLine();
        }

        // 23. STATISTICS OPERATIONS
        private static void StatisticsExample()
        {
            Console.WriteLine("25. STATISTICS OPERATIONS");
            Console.WriteLine("=========================");
            
            Console.WriteLine("Comprehensive salary statistics:");
            
            // Java: employees.stream().mapToInt(Employee::getSalary).summaryStatistics()
            // C# LINQ: Manual calculation or use of aggregation methods
            var salaries = Employees.Select(emp => emp.Salary).ToList();
            
            var stats = new
            {
                Count = salaries.Count,
                Sum = salaries.Sum(),
                Average = salaries.Average(),
                Min = salaries.Min(),
                Max = salaries.Max(),
                Median = salaries.OrderBy(s => s).Skip(salaries.Count / 2).First(),
                StandardDeviation = CalculateStandardDeviation(salaries)
            };
            
            Console.WriteLine($"  Count: {stats.Count}");
            Console.WriteLine($"  Sum: ${stats.Sum:N0}");
            Console.WriteLine($"  Average: ${stats.Average:N0}");
            Console.WriteLine($"  Min: ${stats.Min:N0}");
            Console.WriteLine($"  Max: ${stats.Max:N0}");
            Console.WriteLine($"  Median: ${stats.Median:N0}");
            Console.WriteLine($"  Std Dev: ${stats.StandardDeviation:N0}");
            
            Console.WriteLine("\nPercentile calculations:");
            var sortedSalaries = salaries.OrderBy(s => s).ToList();
            var percentiles = new[] { 25, 50, 75, 90, 95 }
                .Select(p => new
                {
                    Percentile = p,
                    Value = sortedSalaries[(int)(p / 100.0 * sortedSalaries.Count)]
                })
                .ToList();
            
            foreach (var p in percentiles)
            {
                Console.WriteLine($"  {p.Percentile}th percentile: ${p.Value:N0}");
            }
            
            Console.WriteLine();
        }
        
        private static double CalculateStandardDeviation(List<decimal> values)
        {
            var avg = values.Average();
            var sumOfSquares = values.Sum(v => Math.Pow((double)(v - avg), 2));
            return Math.Sqrt(sumOfSquares / values.Count);
        }
    }

    // Supporting classes for examples
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public string Level { get; set; }

        public Employee(int id, string name, string department, decimal salary, int age, string level)
        {
            Id = id;
            Name = name;
            Department = department;
            Salary = salary;
            Age = age;
            Level = level;
        }
    }

    public class Team
    {
        public string Name { get; set; }
        public List<string> Members { get; set; }

        public Team(string name, List<string> members)
        {
            Name = name;
            Members = members;
        }
    }

    public class Department
    {
        public string Name { get; set; }
        public string Division { get; set; }
        public string Manager { get; set; }

        public Department(string name, string division, string manager)
        {
            Name = name;
            Division = division;
            Manager = manager;
        }
    }
}
