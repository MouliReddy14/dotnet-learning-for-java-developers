using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetLearning
{
    // Modern C# features (C# 8, 9, 10, 11, 12+)
    public static class ModernFeatures
    {
        // 1. Top-level programs (C# 9+)
        // Instead of: public static void Main() { ... }
        // You can just write code directly in a .cs file (like scripting)
        
        // 2. Init-only properties (C# 9+)
        public static void InitOnlyPropertiesExample()
        {
            Console.WriteLine("=== INIT-ONLY PROPERTIES ===");
            
            // Java equivalent: final fields set in constructor
            var person = new ModernPerson 
            { 
                Name = "Alice", 
                Age = 25 
            };
            
            Console.WriteLine($"Person: {person.Name}, {person.Age}");
            // person.Name = "Bob"; // This would cause compilation error
            
            // With expressions for records
            var student = new StudentRecord("John", 20, "CS");
            var graduatedStudent = student with { Age = 24 };
            Console.WriteLine($"Original: {student}");
            Console.WriteLine($"Graduated: {graduatedStudent}");
        }
        
        // 3. Range and Index operators (C# 8+)
        public static void RangeAndIndexExample()
        {
            Console.WriteLine("\n=== RANGE AND INDEX OPERATORS ===");
            
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            
            // Java equivalent: numbers[numbers.length - 1]
            Console.WriteLine($"Last element: {numbers[^1]}"); // ^1 means "from end"
            Console.WriteLine($"Second to last: {numbers[^2]}");
            
            // Java equivalent: Arrays.copyOfRange(numbers, 2, 5)
            int[] slice = numbers[2..5]; // Range operator
            Console.WriteLine($"Slice [2..5]: {string.Join(", ", slice)}");
            
            // More range examples
            int[] firstThree = numbers[..3];   // From start to index 3
            int[] lastThree = numbers[^3..];   // Last 3 elements
            int[] middle = numbers[2..^2];     // From index 2 to 2 from end
            
            Console.WriteLine($"First three: {string.Join(", ", firstThree)}");
            Console.WriteLine($"Last three: {string.Join(", ", lastThree)}");
            Console.WriteLine($"Middle: {string.Join(", ", middle)}");
        }
        
        // 4. Switch expressions (C# 8+)
        public static void SwitchExpressionsExample()
        {
            Console.WriteLine("\n=== SWITCH EXPRESSIONS ===");
            
            // Traditional switch vs modern switch expression
            string[] items = { "apple", "banana", "cherry", "unknown" };
            
            foreach (var item in items)
            {
                // Java equivalent: switch statement with returns
                var category = item switch
                {
                    "apple" or "banana" or "cherry" => "Fruit", // Multiple patterns
                    "carrot" or "broccoli" => "Vegetable",
                    var x when x.Length > 5 => "Long name",
                    _ => "Unknown" // Default case
                };
                
                var price = item switch
                {
                    "apple" => 1.50m,
                    "banana" => 0.75m,
                    "cherry" => 2.00m,
                    _ => 0.00m
                };
                
                Console.WriteLine($"{item}: {category}, ${price}");
            }
        }
        
        // 5. Using declarations (C# 8+)
        public static async Task UsingDeclarationsExample()
        {
            Console.WriteLine("\n=== USING DECLARATIONS ===");
            
            // Java equivalent: try-with-resources
            // Old C#: using (var file = new StreamWriter("temp.txt")) { ... }
            // New C#: using declaration (automatic disposal at end of scope)
            
            using var file = new System.IO.StreamWriter("temp.txt");
            await file.WriteLineAsync("Hello from modern C#!");
            // File automatically disposed when method ends
            
            Console.WriteLine("File written with using declaration");
            
            // Clean up
            // System.IO.File.Delete("temp.txt");
        }
        
        // 6. Null-coalescing assignment (C# 8+)
        public static void NullCoalescingAssignmentExample()
        {
            Console.WriteLine("\n=== NULL-COALESCING ASSIGNMENT ===");
            
            string? name = null;
            List<string>? items = null;
            
            // Java equivalent: if (name == null) name = "Default";
            name ??= "Default Name";  // Assign only if null
            items ??= new List<string>(); // Create list only if null
            
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Items count: {items.Count}");
            
            // Multiple assignments
            string? a = null, b = null, c = null;
            a ??= b ??= c ??= "Final default";
            Console.WriteLine($"All assigned to: {a}");
        }
        
        // 7. Target-typed new expressions (C# 9+)
        public static void TargetTypedNewExample()
        {
            Console.WriteLine("\n=== TARGET-TYPED NEW EXPRESSIONS ===");
            
            // Old way: List<string> list = new List<string>();
            // New way: List<string> list = new();
            List<string> fruits = new() { "Apple", "Banana" }; // Type inferred
            Dictionary<string, int> counts = new() { ["Apple"] = 5, ["Banana"] = 3 };
            
            Console.WriteLine($"Fruits: {string.Join(", ", fruits)}");
            Console.WriteLine($"Counts: {string.Join(", ", counts.Select(kv => $"{kv.Key}={kv.Value}"))}");
        }
        
        // 8. Local functions (C# 7+)
        public static void LocalFunctionsExample()
        {
            Console.WriteLine("\n=== LOCAL FUNCTIONS ===");
            
            // Functions defined inside methods (like nested functions)
            int[] numbers = { 1, 2, 3, 4, 5 };
            
            // Local function - only accessible within this method
            int CalculateSum(int[] nums)
            {
                int sum = 0;
                foreach (int num in nums)
                    sum += num;
                return sum;
            }
            
            // Another local function using LINQ
            double CalculateAverage(int[] nums) => nums.Average();
            
            Console.WriteLine($"Sum: {CalculateSum(numbers)}");
            Console.WriteLine($"Average: {CalculateAverage(numbers)}");
        }
        
        // 9. Global using directives (C# 10+)
        // Put in a separate .cs file: global using System.Collections.Generic;
        // Then you don't need to write "using" in every file
        
        // 10. File-scoped namespaces (C# 10+)
        // Instead of: namespace MyApp { ... }
        // You can write: namespace MyApp; (applies to entire file)
        
        // 11. Raw string literals (C# 11+)
        public static void RawStringLiteralsExample()
        {
            Console.WriteLine("\n=== RAW STRING LITERALS ===");
            
            // Java equivalent: Text blocks (Java 15+)
            // Useful for JSON, SQL, HTML, etc.
            string json = """
                {
                    "name": "John",
                    "age": 30,
                    "city": "New York"
                }
                """;
            
            string sql = """
                SELECT name, age 
                FROM users 
                WHERE age > 18
                ORDER BY name
                """;
            
            Console.WriteLine("JSON:");
            Console.WriteLine(json);
            Console.WriteLine("\nSQL:");
            Console.WriteLine(sql);
        }
        
        // 12. Primary constructors (C# 12+)
        // See PrimaryConstructorExample class below
        
        // 13. Collection expressions (C# 12+)
        public static void CollectionExpressionsExample()
        {
            Console.WriteLine("\n=== COLLECTION EXPRESSIONS ===");
            
            // New syntax for creating collections
            int[] array = [1, 2, 3, 4, 5];
            List<string> list = ["apple", "banana", "cherry"];
            
            // Spreading collections
            int[] moreNumbers = [0, ..array, 6, 7]; // Spread array into new array
            List<string> moreFruits = [..list, "date", "elderberry"];
            
            Console.WriteLine($"Array: {string.Join(", ", array)}");
            Console.WriteLine($"List: {string.Join(", ", list)}");
            Console.WriteLine($"More numbers: {string.Join(", ", moreNumbers)}");
            Console.WriteLine($"More fruits: {string.Join(", ", moreFruits)}");
        }
        
        // 14. Required members (C# 11+)
        public static void RequiredMembersExample()
        {
            Console.WriteLine("\n=== REQUIRED MEMBERS ===");
            
            // Must set required properties when creating object
            var book = new BookWithRequired
            {
                Title = "C# in Depth", // Required
                Author = "Jon Skeet", // Required
                // Pages is optional
                Pages = 500
            };
            
            Console.WriteLine($"Book: {book.Title} by {book.Author} ({book.Pages} pages)");
        }
    }
    
    // Examples of modern class definitions
    
    // Init-only properties (C# 9+)
    public class ModernPerson
    {
        public string Name { get; init; } = string.Empty; // Can only be set during object initialization
        public int Age { get; init; }
    }
    
    // Record with positional syntax (C# 9+)
    public record StudentRecord(string Name, int Age, string Major);
    
    // Primary constructor (C# 12+)
    public class PrimaryConstructorExample(string name, int id)
    {
        // Parameters become private fields automatically
        public string Name => name; // Using constructor parameter
        public int Id => id;
        
        public void Display() => Console.WriteLine($"Name: {name}, ID: {id}");
    }
    
    // Required members (C# 11+)
    public class BookWithRequired
    {
        public required string Title { get; set; } // Must be set
        public required string Author { get; set; } // Must be set
        public int Pages { get; set; } // Optional
    }
    
    // File-scoped namespace example (would be in a separate file)
    // namespace DotNetLearning; // No braces needed, applies to entire file
}
