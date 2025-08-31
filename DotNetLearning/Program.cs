using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Java equivalent: package declaration would be here
// C# uses namespaces, but in modern .NET we can use top-level programs

namespace DotNetLearning
{
    class Program
    {
        // Java equivalent: public static void main(String[] args)
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== .NET Learning Project ===");
            Console.WriteLine("Comparing .NET concepts with Java\n");

            // 1. Basic Data Types and Variables
            await BasicDataTypesExample();
            
            // 2. String Operations
            await StringOperationsExample();
            
            // 3. Collections
            await CollectionsExample();
            
            // 4. Object-Oriented Programming
            await OOPExample();
            
            // 5. Exception Handling
            await ExceptionHandlingExample();
            
            // 6. LINQ (Java Streams equivalent)
            await LinqExample();
            
            // 7. Async/Await (Java CompletableFuture equivalent)
            await AsyncAwaitExample();
            
            // 8. Properties vs Getters/Setters
            await PropertiesExample();
            
            // 9. Delegates and Events (Java Functional Interfaces + Observer)
            await DelegatesAndEventsExample();
            
            // 10. Extension Methods
            await ExtensionMethodsExample();
            
            // 11. Advanced Concepts
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("ADVANCED .NET CONCEPTS");
            Console.WriteLine(new string('=', 50));
            
            AdvancedConcepts.GenericsExample();
            AdvancedConcepts.InterfacesExample();
            AdvancedConcepts.AbstractClassExample();
            await AdvancedConcepts.FileIOExample();
            AdvancedConcepts.JsonExample();
            AdvancedConcepts.NullableTypesExample();
            AdvancedConcepts.PatternMatchingExample();
            AdvancedConcepts.RecordsExample();
            
            // 12. Modern C# Features
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("MODERN C# FEATURES");
            Console.WriteLine(new string('=', 50));
            
            ModernFeatures.InitOnlyPropertiesExample();
            ModernFeatures.RangeAndIndexExample();
            ModernFeatures.SwitchExpressionsExample();
            await ModernFeatures.UsingDeclarationsExample();
            ModernFeatures.NullCoalescingAssignmentExample();
            ModernFeatures.TargetTypedNewExample();
            ModernFeatures.LocalFunctionsExample();
            ModernFeatures.RawStringLiteralsExample();
            ModernFeatures.CollectionExpressionsExample();
            ModernFeatures.RequiredMembersExample();

            // 13. Java Stream API vs .NET LINQ - In-Depth Comparison
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("JAVA STREAM API vs .NET LINQ - COMPREHENSIVE COMPARISON");
            Console.WriteLine(new string('=', 60));
            
            await StreamApiVsLinq.RunAllExamples();

            // 14. Missing Concepts - Critical .NET Features for Java Developers
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("MISSING CONCEPTS - CRITICAL .NET FEATURES FOR JAVA DEVS");
            Console.WriteLine(new string('=', 60));
            
            await MissingConcepts.RunAllExamples();

            Console.WriteLine("\n=== Learning Complete! ===");
            Console.ReadKey();
        }

        // 1. Basic Data Types and Variables
        static async Task BasicDataTypesExample()
        {
            Console.WriteLine("1. BASIC DATA TYPES AND VARIABLES");
            Console.WriteLine("=====================================");
            
            // Java: int number = 10;
            int number = 10;
            Console.WriteLine($"int: {number}");
            
            // Java: double decimal = 10.5;
            double decimalValue = 10.5;
            Console.WriteLine($"double: {decimalValue}");
            
            // Java: String text = "Hello";
            string text = "Hello";
            Console.WriteLine($"string: {text}");
            
            // Java: boolean flag = true;
            bool flag = true;
            Console.WriteLine($"bool: {flag}");
            
            // C# specific: var keyword (type inference)
            // Java equivalent: var (Java 10+) or explicit type
            var autoInferred = "This is automatically inferred as string";
            Console.WriteLine($"var (auto-inferred): {autoInferred}");
            
            // C# specific: nullable types
            // Java equivalent: Optional<Integer> or Integer (wrapper class)
            int? nullableInt = null;
            Console.WriteLine($"nullable int: {nullableInt ?? -1}");
            
            await Task.Delay(1000);
            Console.WriteLine();
        }

        // 2. String Operations
        static async Task StringOperationsExample()
        {
            Console.WriteLine("2. STRING OPERATIONS");
            Console.WriteLine("====================");
            
            // Java: String.format() or + concatenation
            string firstName = "John";
            string lastName = "Doe";
            
            // String interpolation (C# specific)
            string fullName = $"{firstName} {lastName}";
            Console.WriteLine($"String interpolation: {fullName}");
            
            // Java equivalent: String.format("Hello %s", name)
            string formatted = string.Format("Hello {0}", fullName);
            Console.WriteLine($"String.Format: {formatted}");
            
            // String methods (similar to Java)
            Console.WriteLine($"Length: {fullName.Length}"); // Java: .length()
            Console.WriteLine($"Upper: {fullName.ToUpper()}"); // Java: .toUpperCase()
            Console.WriteLine($"Contains 'John': {fullName.Contains("John")}"); // Java: .contains()
            
            await Task.Delay(1000);
            Console.WriteLine();
        }

        // 3. Collections
        static async Task CollectionsExample()
        {
            Console.WriteLine("3. COLLECTIONS");
            Console.WriteLine("==============");
            
            // Java: List<String> list = new ArrayList<>();
            List<string> list = new List<string> { "Apple", "Banana", "Cherry" };
            Console.WriteLine("List<string>:");
            foreach (var item in list) // Java: for (String item : list)
            {
                Console.WriteLine($"  - {item}");
            }
            
            // Java: Map<String, Integer> map = new HashMap<>();
            Dictionary<string, int> dictionary = new Dictionary<string, int>
            {
                {"Apple", 1},
                {"Banana", 2},
                {"Cherry", 3}
            };
            
            Console.WriteLine("\nDictionary<string, int>:");
            foreach (var kvp in dictionary) // Java: for (Map.Entry<String, Integer> entry : map.entrySet())
            {
                Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
            }
            
            // Java: int[] array = new int[]{1, 2, 3};
            int[] array = { 1, 2, 3, 4, 5 };
            Console.WriteLine($"\nArray length: {array.Length}"); // Java: array.length
            
            await Task.Delay(1000);
            Console.WriteLine();
        }

        // 4. Object-Oriented Programming will be in separate classes
        static async Task OOPExample()
        {
            Console.WriteLine("4. OBJECT-ORIENTED PROGRAMMING");
            Console.WriteLine("==============================");
            
            // Creating objects (similar to Java)
            var person = new Person("Alice", 25);
            Console.WriteLine(person.GetInfo());
            
            // Inheritance
            var student = new Student("Bob", 20, "Computer Science");
            Console.WriteLine(student.GetInfo());
            
            // Polymorphism
            Person polymorphicStudent = new Student("Charlie", 22, "Mathematics");
            Console.WriteLine(polymorphicStudent.GetInfo());
            
            await Task.Delay(1000);
            Console.WriteLine();
        }

        // 5. Exception Handling
        static async Task ExceptionHandlingExample()
        {
            Console.WriteLine("5. EXCEPTION HANDLING");
            Console.WriteLine("=====================");
            
            try
            {
                // Java: same try-catch syntax
                int result = DivideNumbers(10, 0);
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException ex) // Java: catch (ArithmeticException ex)
            {
                Console.WriteLine($"Caught exception: {ex.Message}");
            }
            catch (Exception ex) // Java: catch (Exception ex)
            {
                Console.WriteLine($"General exception: {ex.Message}");
            }
            finally // Java: same finally block
            {
                Console.WriteLine("Finally block executed");
            }
            
            await Task.Delay(1000);
            Console.WriteLine();
        }

        static int DivideNumbers(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero!");
            return a / b;
        }

        // 6. LINQ (Language Integrated Query) - Java Streams equivalent
        static async Task LinqExample()
        {
            Console.WriteLine("6. LINQ (Language Integrated Query)");
            Console.WriteLine("===================================");
            
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            
            // Java: numbers.stream().filter(x -> x % 2 == 0).collect(Collectors.toList())
            var evenNumbers = numbers.Where(x => x % 2 == 0).ToList();
            Console.WriteLine($"Even numbers: {string.Join(", ", evenNumbers)}");
            
            // Java: numbers.stream().map(x -> x * x).collect(Collectors.toList())
            var squares = numbers.Select(x => x * x).ToList();
            Console.WriteLine($"Squares: {string.Join(", ", squares)}");
            
            // Java: numbers.stream().filter(x -> x > 5).mapToInt(x -> x).sum()
            var sumOfLargeNumbers = numbers.Where(x => x > 5).Sum();
            Console.WriteLine($"Sum of numbers > 5: {sumOfLargeNumbers}");
            
            // Method chaining (Java streams style)
            var result = numbers
                .Where(x => x % 2 == 0)
                .Select(x => x * x)
                .OrderByDescending(x => x)
                .Take(3)
                .ToList();
            Console.WriteLine($"Top 3 largest even squares: {string.Join(", ", result)}");
            
            await Task.Delay(1000);
            Console.WriteLine();
        }

        // 7. Async/Await (Java CompletableFuture equivalent)
        static async Task AsyncAwaitExample()
        {
            Console.WriteLine("7. ASYNC/AWAIT");
            Console.WriteLine("==============");
            
            Console.WriteLine("Starting async operation...");
            
            // Java equivalent: CompletableFuture.supplyAsync(() -> { ... })
            var result = await SimulateAsyncOperation("Processing data");
            Console.WriteLine($"Async result: {result}");
            
            // Multiple async operations
            var task1 = SimulateAsyncOperation("Task 1");
            var task2 = SimulateAsyncOperation("Task 2");
            var task3 = SimulateAsyncOperation("Task 3");
            
            // Java equivalent: CompletableFuture.allOf(task1, task2, task3)
            var results = await Task.WhenAll(task1, task2, task3);
            Console.WriteLine($"All tasks completed: {string.Join(", ", results)}");
            
            Console.WriteLine();
        }

        static async Task<string> SimulateAsyncOperation(string operation)
        {
            // Java equivalent: Thread.sleep() in CompletableFuture
            await Task.Delay(500);
            return $"{operation} completed";
        }

        // 8. Properties vs Java Getters/Setters
        static async Task PropertiesExample()
        {
            Console.WriteLine("8. PROPERTIES (vs Java Getters/Setters)");
            Console.WriteLine("=======================================");
            
            var product = new Product();
            
            // C# properties look like field access but are actually method calls
            product.Name = "Laptop"; // Java: product.setName("Laptop")
            product.Price = 999.99m; // Java: product.setPrice(999.99)
            
            Console.WriteLine($"Product: {product.Name}, Price: {product.Price:C}");
            // Java: System.out.println("Product: " + product.getName() + ", Price: " + product.getPrice())
            
            // Auto-calculated property
            Console.WriteLine($"Discounted Price: {product.DiscountedPrice:C}");
            
            await Task.Delay(1000);
            Console.WriteLine();
        }

        // 9. Delegates and Events
        static async Task DelegatesAndEventsExample()
        {
            Console.WriteLine("9. DELEGATES AND EVENTS");
            Console.WriteLine("=======================");
            
            var publisher = new EventPublisher();
            
            // Java equivalent: publisher.addObserver(observer) or functional interface
            publisher.SomethingHappened += (message) => Console.WriteLine($"Handler 1: {message}");
            publisher.SomethingHappened += (message) => Console.WriteLine($"Handler 2: {message}");
            
            publisher.TriggerEvent("Hello from .NET events!");
            
            // Delegates as function pointers
            // Java equivalent: Function<Integer, Integer> or lambda expressions
            Func<int, int> square = x => x * x;
            Console.WriteLine($"Square of 5: {square(5)}");
            
            Action<string> printMessage = msg => Console.WriteLine($"Action: {msg}");
            printMessage("This is an Action delegate");
            
            await Task.Delay(1000);
            Console.WriteLine();
        }

        // 10. Extension Methods
        static async Task ExtensionMethodsExample()
        {
            Console.WriteLine("10. EXTENSION METHODS");
            Console.WriteLine("====================");
            
            string text = "hello world";
            
            // Using extension method (looks like a regular method but extends existing types)
            // Java equivalent: utility classes with static methods
            Console.WriteLine($"Original: {text}");
            Console.WriteLine($"Title Case: {text.ToTitleCase()}");
            Console.WriteLine($"Word Count: {text.WordCount()}");
            
            // Extension methods on numbers
            int number = 42;
            Console.WriteLine($"Is {number} even? {number.IsEven()}");
            Console.WriteLine($"Square of {number}: {number.Square()}");
            
            await Task.Delay(1000);
            Console.WriteLine();
        }
    }
}

// Class definitions for OOP examples
// Java equivalent: public class Person { ... }
public class Person
{
    // Java equivalent: private String name; private int age;
    private string _name;
    private int _age;
    
    // Constructor - similar to Java
    public Person(string name, int age)
    {
        _name = name;
        _age = age;
    }
    
    // Properties (C# way) vs Java getters/setters
    public string Name { get; set; } = string.Empty;

    public int Age { get; set; }
    
    // Virtual method for polymorphism (Java: can be overridden by default)
    public virtual string GetInfo()
    {
        return $"Person: {Name}, Age: {Age}";
    }
}

// Inheritance - Java: extends
public class Student : Person
{
    public string Major { get; set; } // Auto-property (C# shorthand)
    
    // Java: super(name, age)
    public Student(string name, int age, string major) : base(name, age)
    {
        Major = major;
    }
    
    // Override method - Java: @Override
    public override string GetInfo()
    {
        return $"Student: {Name}, Age: {Age}, Major: {Major}";
    }
}

// Product class for Properties example
public class Product
{
    // Auto-implemented properties (C# specific)
    // Java equivalent: private fields with getters/setters
    public string Name { get; set; } = string.Empty; // Initialize to avoid warning
    public decimal Price { get; set; }
    
    // Calculated property (read-only)
    // Java equivalent: getter method with calculation
    public decimal DiscountedPrice => Price * 0.9m; // 10% discount
}

// Event Publisher for Delegates and Events example
public class EventPublisher
{
    // Java equivalent: Observer pattern or functional interfaces
    public event Action<string>? SomethingHappened; // Make nullable to avoid warning
    
    public void TriggerEvent(string message)
    {
        SomethingHappened?.Invoke(message); // Null-conditional operator
    }
}

// Extension Methods (C# specific feature)
// Java equivalent: utility classes with static methods
public static class StringExtensions
{
    // Java equivalent: public static String toTitleCase(String str) in utility class
    public static string ToTitleCase(this string? input)
    {
        if (string.IsNullOrEmpty(input))
            return input;
            
        var words = input.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > 0)
            {
                words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
            }
        }
        return string.Join(" ", words);
    }
    
    public static int WordCount(this string input)
    {
        return string.IsNullOrEmpty(input) ? 0 : input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    }
}

public static class IntegerExtensions
{
    public static bool IsEven(this int number)
    {
        return number % 2 == 0;
    }
    
    public static int Square(this int number)
    {
        return number * number;
    }
}

// Advanced .NET Concepts - static class
public static class AdvancedConcepts
{
    public static void GenericsExample()
    {
        Console.WriteLine("Generics Example:");
        
        // Java: public class Box<T> { ... }
        var intBox = new Box<int>(123);
        Console.WriteLine($"Int box contains: {intBox.GetItem()}");
        
        var strBox = new Box<string>("Hello Generics");
        Console.WriteLine($"String box contains: {strBox.GetItem()}");
        
        // Java: Arrays.asList(1, 2, 3).forEach(System.out::println);
        Console.WriteLine("List of numbers: ");
        new List<int> { 1, 2, 3 }.ForEach(Console.WriteLine);
    }
    
    public static void InterfacesExample()
    {
        Console.WriteLine("\nInterfaces Example:");
        
        // Java: List<String> list = new ArrayList<>();
        IList<string> list = new List<string> { "Apple", "Banana", "Cherry" };
        Console.WriteLine("IList<string>:");
        foreach (var item in list) // Java: for (String item : list)
        {
            Console.WriteLine($"  - {item}");
        }
        
        // Java: Map<String, Integer> map = new HashMap<>();
        IDictionary<string, int> dictionary = new Dictionary<string, int>
        {
            {"Apple", 1},
            {"Banana", 2},
            {"Cherry", 3}
        };
        
        Console.WriteLine("\nIDictionary<string, int>:");
        foreach (var kvp in dictionary) // Java: for (Map.Entry<String, Integer> entry : map.entrySet())
        {
            Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
        }
    }
    
    public static void AbstractClassExample()
    {
        Console.WriteLine("\nAbstract Class Example:");
        
        // Cannot instantiate abstract class directly
        // Java: Shape shape = new Shape(); // Error: Shape is abstract
        
        Shape circle = new Circle(5);
        Console.WriteLine($"Circle area: {circle.CalculateArea()}");
        
        Shape rectangle = new Rectangle(4, 6);
        Console.WriteLine($"Rectangle area: {rectangle.CalculateArea()}");
    }
    
    public static async Task FileIOExample()
    {
        Console.WriteLine("\nFile I/O Example:");
        
        string filePath = "example.txt";
        
        // Java: Files.writeString(Paths.get(filePath), "Hello, World!");
        await System.IO.File.WriteAllTextAsync(filePath, "Hello, World!");
        Console.WriteLine($"File written: {filePath}");
        
        // Java: String content = Files.readString(Paths.get(filePath));
        string content = await System.IO.File.ReadAllTextAsync(filePath);
        Console.WriteLine($"File content: {content}");
    }
    
    public static void JsonExample()
    {
        Console.WriteLine("\nJSON Example:");
        
        var person = new Person("Alice", 30);
        // Java: String json = new Gson().toJson(person);
        string json = System.Text.Json.JsonSerializer.Serialize(person);
        Console.WriteLine($"Serialized JSON: {json}");
        
        // Java: Person p = new Gson().fromJson(json, Person.class);
        var deserializedPerson = System.Text.Json.JsonSerializer.Deserialize<Person>(json);
        Console.WriteLine($"Deserialized Person: {deserializedPerson?.GetInfo()}");
    }
    
    public static void NullableTypesExample()
    {
        Console.WriteLine("\nNullable Types Example:");
        
        int? nullableInt = null;
        // Java: Optional<Integer> optionalInt = Optional.ofNullable(nullableInt);
        Console.WriteLine($"Nullable int: {nullableInt}");
        
        // Java: Integer value = optionalInt.orElse(-1);
        int value = nullableInt ?? -1;
        Console.WriteLine($"Value or default: {value}");
        
        // Example with actual value
        int? anotherNullable = 42;
        Console.WriteLine($"Another nullable: {anotherNullable}");
        Console.WriteLine($"Has value: {anotherNullable.HasValue}");
        Console.WriteLine($"Value: {anotherNullable.Value}");
    }
    
    public static void PatternMatchingExample()
    {
        Console.WriteLine("\nPattern Matching Example:");
        
        object obj = "Hello, Pattern Matching!";
        
        // Java: if (obj instanceof String) { String str = (String) obj; }
        if (obj is string str)
        {
            Console.WriteLine($"String length: {str.Length}");
        }
        
        // Java: switch (shape.getType()) { case "circle": ... }
        Shape shape = new Circle(10);
        switch (shape)
        {
            case Circle c:
                Console.WriteLine($"Circle radius: {c.Radius}");
                break;
            case Rectangle r:
                Console.WriteLine($"Rectangle width: {r.Width}");
                break;
            default:
                Console.WriteLine("Unknown shape");
                break;
        }
    }
    
    public static void RecordsExample()
    {
        Console.WriteLine("\nRecords Example:");
        
        // Java: record Person(String name, int age) {}
        var record = new { Name = "Alice", Age = 30 };
        Console.WriteLine($"Record: {record}");
        
        // Java: Person p1 = new Person("Alice", 30);
        // Java: Person p2 = new Person("Alice", 30);
        var p1 = new { Name = "Alice", Age = 30 };
        var p2 = new { Name = "Alice", Age = 30 };
        Console.WriteLine($"Records equal: {p1.Equals(p2)}");
    }
}

// Generic class example
public class Box<T>
{
    private T item;
    
    public Box(T item)
    {
        this.item = item;
    }
    
    public T GetItem()
    {
        return item;
    }
}

// Abstract class and derived classes for abstract class example
public abstract class Shape
{
    public abstract double CalculateArea();
}

public class Circle : Shape
{
    public double Radius { get; set; }
    
    public Circle(double radius)
    {
        Radius = radius;
    }
    
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }
    
    public override double CalculateArea()
    {
        return Width * Height;
    }
}

// Java Stream API vs .NET LINQ comprehensive comparison
public static class StreamApiVsLinq
{
    public static async Task RunAllExamples()
    {
        Console.WriteLine("Java Stream API vs .NET LINQ - Comprehensive Comparison:");
        
        // 1. Filtering
        Console.WriteLine("\n1. Filtering:");
        var numbers = Enumerable.Range(1, 10).ToList();
        Console.WriteLine($"Numbers: {string.Join(", ", numbers)}");
        
        // Java: List<Integer> evenNumbers = numbers.stream().filter(n -> n % 2 == 0).collect(Collectors.toList());
        var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
        Console.WriteLine($"Even numbers: {string.Join(", ", evenNumbers)}");
        
        // 2. Mapping
        Console.WriteLine("\n2. Mapping:");
        // Java: List<String> numberStrings = numbers.stream().map(Object::toString).collect(Collectors.toList());
        var numberStrings = numbers.Select(n => n.ToString()).ToList();
        Console.WriteLine($"Number strings: {string.Join(", ", numberStrings)}");
        
        // 3. Reducing
        Console.WriteLine("\n3. Reducing:");
        // Java: int sum = numbers.stream().reduce(0, Integer::sum);
        var sum = numbers.Sum();
        Console.WriteLine($"Sum: {sum}");
        
        // 4. Collecting
        Console.WriteLine("\n4. Collecting:");
        // Java: Set<Integer> numberSet = new HashSet<>(numbers);
        var numberSet = new HashSet<int>(numbers);
        Console.WriteLine($"Number set: {string.Join(", ", numberSet)}");
        
        // 5. Sorting
        Console.WriteLine("\n5. Sorting:");
        var unsortedNumbers = new List<int> { 5, 2, 8, 1, 9 };
        Console.WriteLine($"Unsorted: {string.Join(", ", unsortedNumbers)}");
        
        // Java: List<Integer> sortedNumbers = unsortedNumbers.stream().sorted().collect(Collectors.toList());
        var sortedNumbers = unsortedNumbers.OrderBy(n => n).ToList();
        Console.WriteLine($"Sorted: {string.Join(", ", sortedNumbers)}");
        
        // 6. Java 8+ Features: Streams vs LINQ
        Console.WriteLine("\n6. Java 8+ Features: Streams vs LINQ");
        
        // Java: numbers.stream().parallel().forEach(n -> System.out.println(n));
        Console.WriteLine("Parallel foreach (Java Streams):");
        // numbers.AsParallel().ForAll(n => Console.WriteLine(n)); // Uncomment for PLINQ parallelism
        
        // Java: Optional<Integer> max = numbers.stream().reduce(Integer::max);
        var max = numbers.Max();
        Console.WriteLine($"Max number: {max}");
        
        // Java: Double average = numbers.stream().mapToInt(Integer::intValue).average().orElse(0);
        var average = numbers.Average();
        Console.WriteLine($"Average: {average}");
        
        // Java: boolean anyMatch = numbers.stream().anyMatch(n -> n > 8);
        bool anyMatch = numbers.Any(n => n > 8);
        Console.WriteLine($"Any number > 8: {anyMatch}");
        
        // Java: boolean allMatch = numbers.stream().allMatch(n -> n > 0);
        bool allMatch = numbers.All(n => n > 0);
        Console.WriteLine($"All numbers > 0: {allMatch}");
        
        // Java: boolean noneMatch = numbers.stream().noneMatch(n -> n < 0);
        bool noneMatch = numbers.All(n => n >= 0);
        Console.WriteLine($"No negative numbers: {noneMatch}");
        
        // Java: List<Integer> firstThree = numbers.stream().limit(3).collect(Collectors.toList());
        var firstThree = numbers.Take(3).ToList();
        Console.WriteLine($"First three numbers: {string.Join(", ", firstThree)}");
        
        // Java: List<Integer> skippedFirstTwo = numbers.stream().skip(2).collect(Collectors.toList());
        var skippedFirstTwo = numbers.Skip(2).ToList();
        Console.WriteLine($"Skipped first two: {string.Join(", ", skippedFirstTwo)}");
        
        // Java: IntSummaryStatistics stats = numbers.stream().mapToInt(Integer::intValue).summaryStatistics();
        var stats = new
        {
            Count = numbers.Count,
            Min = numbers.Min(),
            Max = numbers.Max(),
            Sum = numbers.Sum(),
            Average = numbers.Average()
        };
        Console.WriteLine($"Statistics - Count: {stats.Count}, Min: {stats.Min}, Max: {stats.Max}, Sum: {stats.Sum}, Average: {stats.Average}");
        
        await Task.Delay(1000);
        Console.WriteLine();
    }
}

// Missing Concepts - Critical .NET Features for Java Developers
public static class MissingConcepts
{
    public static async Task RunAllExamples()
    {
        Console.WriteLine("Missing Concepts - Critical .NET Features for Java Developers:");
        
        // 1. Value Types vs Reference Types
        Console.WriteLine("\n1. Value Types vs Reference Types:");
        int valueType = 42;
        Console.WriteLine($"Value type: {valueType}, Size: {sizeof(int)} bytes");
        
        object referenceType = 42;
        Console.WriteLine($"Reference type: {referenceType}, Size: {IntPtr.Size} bytes");
        
        // 2. String Immutability
        Console.WriteLine("\n2. String Immutability:");
        string immutableString = "Hello";
        Console.WriteLine($"Original string: {immutableString}");
        
        immutableString += ", World!";
        Console.WriteLine($"Modified string: {immutableString}");
        
        // 3. Object Initializers
        Console.WriteLine("\n3. Object Initializers:");
        var personObj = new Person("Alice", 30);
        Console.WriteLine($"Person: {personObj.Name}, Age: {personObj.Age}");
        
        // 4. Collection Initializers
        Console.WriteLine("\n4. Collection Initializers:");
        var fruits = new List<string> { "Apple", "Banana", "Cherry" };
        Console.WriteLine($"Fruits: {string.Join(", ", fruits)}");
        
        // 5. LINQ - Language Integrated Query
        Console.WriteLine("\n5. LINQ - Language Integrated Query:");
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
        Console.WriteLine($"Even numbers: {string.Join(", ", evenNumbers)}");
        
        // 6. Async/Await - Asynchronous Programming
        Console.WriteLine("\n6. Async/Await - Asynchronous Programming:");
        await Task.Delay(100);
        Console.WriteLine("Async operation completed");
        
        // 7. Exception Filters
        Console.WriteLine("\n7. Exception Filters:");
        try
        {
            throw new InvalidOperationException("Invalid operation");
        }
        catch (InvalidOperationException ex) when (ex.Message.Contains("Invalid"))
        {
            Console.WriteLine($"Caught filtered exception: {ex.Message}");
        }
        
        // 8. Using Declarations
        Console.WriteLine("\n8. Using Declarations:");
        using (var stream = new System.IO.FileStream("example.txt", System.IO.FileMode.OpenOrCreate))
        {
            Console.WriteLine("File stream opened and will be disposed automatically");
        }
        
        // 9. Null-conditional Operator
        Console.WriteLine("\n9. Null-conditional Operator:");
        string? nullableString = null;
        string length = nullableString?.Length.ToString() ?? "0";
        Console.WriteLine($"String length: {length}");
        
        // 10. Ternary Conditional Operator
        Console.WriteLine("\n10. Ternary Conditional Operator:");
        int a = 10, b = 20;
        int maxValue = (a > b) ? a : b;
        Console.WriteLine($"Max: {maxValue}");
        
        // 11. Coalescing Operator
        Console.WriteLine("\n11. Coalescing Operator:");
        string? name = null;
        string displayName = name ?? "Guest";
        Console.WriteLine($"Display name: {displayName}");
        
        // 12. Pattern Matching
        Console.WriteLine("\n12. Pattern Matching:");
        object obj = "Hello, Pattern Matching!";
        
        if (obj is string str)
        {
            Console.WriteLine($"String length: {str.Length}");
        }
        
        // 13. Records
        Console.WriteLine("\n13. Records:");
        var record = new { Name = "Alice", Age = 30 };
        Console.WriteLine($"Record: {record}");
        
        // 14. Mathematical Operations
        Console.WriteLine("\n14. Mathematical Operations:");
        double mathResult = Math.Sqrt(25);
        Console.WriteLine($"Square root of 25: {mathResult}");
        
        // 15. Static Local Functions
        Console.WriteLine("\n15. Static Local Functions:");
        int addResult = Add(3, 4);
        Console.WriteLine($"Addition result: {addResult}");
        
        static int Add(int x, int y) => x + y;
        
        await Task.Delay(1000);
        Console.WriteLine();
    }
}
