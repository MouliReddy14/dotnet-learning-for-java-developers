using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace DotNetLearning
{
    // Advanced .NET concepts with Java comparisons
    public static class AdvancedConcepts
    {
        // 1. Generics (similar to Java generics but with some differences)
        public static void GenericsExample()
        {
            Console.WriteLine("=== GENERICS ===");
            
            // Java: List<String> stringList = new ArrayList<>();
            var stringList = new GenericContainer<string>();
            stringList.Add("Hello");
            stringList.Add("World");
            
            // Java: List<Integer> intList = new ArrayList<>();
            var intList = new GenericContainer<int>();
            intList.Add(1);
            intList.Add(2);
            
            Console.WriteLine($"String container: {stringList.GetAll()}");
            Console.WriteLine($"Int container: {intList.GetAll()}");
        }
        
        // 2. Interfaces (similar to Java interfaces)
        public static void InterfacesExample()
        {
            Console.WriteLine("\n=== INTERFACES ===");
            
            // Java: List<Drawable> shapes = new ArrayList<>();
            List<IDrawable> shapes = new List<IDrawable>
            {
                new Circle(5),
                new Rectangle(10, 20)
            };
            
            foreach (var shape in shapes)
            {
                shape.Draw(); // Polymorphism through interfaces
                Console.WriteLine($"Area: {shape.CalculateArea()}");
            }
        }
        
        // 3. Abstract Classes (similar to Java abstract classes)
        public static void AbstractClassExample()
        {
            Console.WriteLine("\n=== ABSTRACT CLASSES ===");
            
            // Java: Animal dog = new Dog();
            Animal dog = new Dog();
            Animal cat = new Cat();
            
            dog.MakeSound(); // Abstract method implementation
            cat.MakeSound();
            
            dog.Sleep(); // Concrete method from abstract class
            cat.Sleep();
        }
        
        // 4. File I/O (different from Java's approach)
        public static async Task FileIOExample()
        {
            Console.WriteLine("\n=== FILE I/O ===");
            
            string filePath = "sample.txt";
            
            // Writing to file
            // Java: Files.writeString(path, content) or FileWriter
            await File.WriteAllTextAsync(filePath, "Hello from .NET!\nSecond line.");
            Console.WriteLine("File written successfully");
            
            // Reading from file
            // Java: Files.readString(path) or BufferedReader
            string content = await File.ReadAllTextAsync(filePath);
            Console.WriteLine($"File content: {content}");
            
            // Reading lines
            // Java: Files.readAllLines(path)
            string[] lines = await File.ReadAllLinesAsync(filePath);
            Console.WriteLine($"Number of lines: {lines.Length}");
            
            // Clean up
            File.Delete(filePath);
        }
        
        // 5. JSON Serialization (different from Java's Jackson/Gson)
        public static void JsonExample()
        {
            Console.WriteLine("\n=== JSON SERIALIZATION ===");
            
            var person = new { Name = "John", Age = 30, City = "New York" };
            
            // Serialize to JSON
            // Java: ObjectMapper.writeValueAsString(object) or Gson.toJson()
            string json = JsonSerializer.Serialize(person);
            Console.WriteLine($"JSON: {json}");
            
            // Deserialize from JSON
            // Java: ObjectMapper.readValue(json, Class) or Gson.fromJson()
            var deserializedPerson = JsonSerializer.Deserialize<dynamic>(json);
            Console.WriteLine($"Deserialized: {deserializedPerson}");
        }
        
        // 6. Nullable Reference Types (C# 8+ feature, no direct Java equivalent)
        public static void NullableTypesExample()
        {
            Console.WriteLine("\n=== NULLABLE REFERENCE TYPES ===");
            
            // C# nullable reference types (compile-time null safety)
            string? nullableString = null; // Can be null
            string nonNullableString = "Hello"; // Should not be null
            
            // Null-conditional operators (C# specific)
            Console.WriteLine($"Length of nullable string: {nullableString?.Length ?? 0}");
            Console.WriteLine($"Length of non-nullable string: {nonNullableString.Length}");
            
            // Null-coalescing operator
            string result = nullableString ?? "Default value";
            Console.WriteLine($"Null coalescing result: {result}");
        }
        
        // 7. Pattern Matching (more advanced than Java's switch)
        public static void PatternMatchingExample()
        {
            Console.WriteLine("\n=== PATTERN MATCHING ===");
            
            object?[] objects = { 42, "Hello", 3.14, new Person("Alice", 25), null };
            
            foreach (var obj in objects)
            {
                // C# pattern matching (more powerful than Java's instanceof)
                string description = obj switch
                {
                    int i when i > 0 => $"Positive integer: {i}",
                    int i => $"Non-positive integer: {i}",
                    string s when s.Length > 5 => $"Long string: {s}",
                    string s => $"Short string: {s}",
                    double d => $"Double: {d}",
                    Person p => $"Person: {p.Name}",
                    null => "Null value",
                    _ => "Unknown type"
                };
                
                Console.WriteLine(description);
            }
        }
        
        // 8. Records (C# 9+ feature, similar to Java records but different syntax)
        public static void RecordsExample()
        {
            Console.WriteLine("\n=== RECORDS ===");
            
            // C# record (immutable by default)
            var person1 = new PersonRecord("John", 30);
            var person2 = new PersonRecord("John", 30);
            
            Console.WriteLine($"Person 1: {person1}");
            Console.WriteLine($"Person 2: {person2}");
            Console.WriteLine($"Are equal: {person1 == person2}"); // Value equality
            
            // With expression (create new record with some properties changed)
            var person3 = person1 with { Age = 31 };
            Console.WriteLine($"Person 3 (modified): {person3}");
        }
    }
    
    // Generic class example
    // Java: public class GenericContainer<T> { ... }
    public class GenericContainer<T>
    {
        private List<T> _items = new List<T>();
        
        public void Add(T item)
        {
            _items.Add(item);
        }
        
        public string GetAll()
        {
            return string.Join(", ", _items);
        }
    }
    
    // Interface example
    // Java: public interface Drawable { ... }
    public interface IDrawable
    {
        void Draw();
        double CalculateArea();
    }
    
    // Interface implementations
    public class Circle : IDrawable
    {
        private double _radius;
        
        public Circle(double radius)
        {
            _radius = radius;
        }
        
        public void Draw()
        {
            Console.WriteLine($"Drawing a circle with radius {_radius}");
        }
        
        public double CalculateArea()
        {
            return Math.PI * _radius * _radius;
        }
    }
    
    public class Rectangle : IDrawable
    {
        private double _width, _height;
        
        public Rectangle(double width, double height)
        {
            _width = width;
            _height = height;
        }
        
        public void Draw()
        {
            Console.WriteLine($"Drawing a rectangle {_width}x{_height}");
        }
        
        public double CalculateArea()
        {
            return _width * _height;
        }
    }
    
    // Abstract class example
    // Java: public abstract class Animal { ... }
    public abstract class Animal
    {
        public abstract void MakeSound(); // Abstract method
        
        public virtual void Sleep() // Virtual method (can be overridden)
        {
            Console.WriteLine("The animal is sleeping");
        }
    }
    
    public class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
    }
    
    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
        
        public override void Sleep()
        {
            Console.WriteLine("The cat is napping in a sunny spot");
        }
    }
    
    // Record example (C# 9+ feature)
    // Java: public record PersonRecord(String name, int age) { }
    public record PersonRecord(string Name, int Age);
}
