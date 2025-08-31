using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;
using System.Text.Json;
using System.Reflection;

namespace DotNetLearning
{
    // Missing concepts that Java developers need to know about .NET
    public static class MissingConcepts
    {
        public static async Task RunAllExamples()
        {
            Console.WriteLine("=== ADDITIONAL .NET CONCEPTS FOR JAVA DEVELOPERS ===");
            Console.WriteLine("====================================================\n");

            // 1. Value Types vs Reference Types (important difference from Java)
            ValueTypesVsReferenceTypesExample();
            
            // 2. Structs (no direct Java equivalent)
            StructsExample();
            
            // 3. Tuples (Java has limited support)
            TuplesExample();
            
            // 4. Anonymous Types (no Java equivalent)
            AnonymousTypesExample();
            
            // 5. Var vs Dynamic (Java doesn't have dynamic)
            VarVsDynamicExample();
            
            // 6. Indexers (no Java equivalent)
            IndexersExample();
            
            // 7. Operator Overloading (limited in Java)
            OperatorOverloadingExample();
            
            // 8. Events vs Observers (different implementation)
            EventsVsObserversExample();
            
            // 9. Reflection (different API from Java)
            ReflectionExample();
            
            // 10. Attributes vs Annotations
            AttributesExample();
            
            // 11. LINQ to Objects vs Java Streams (deeper comparison)
            LinqToObjectsExample();
            
            // 12. Async/Await vs CompletableFuture (deeper dive)
            await AsyncAwaitDeepDiveExample();
            
            // 13. Memory Management (GC differences)
            MemoryManagementExample();
            
            // 14. String Handling (intern pool, StringBuilder)
            StringHandlingExample();
            
            // 15. Exception Handling (deeper differences)
            ExceptionHandlingDeepDiveExample();
            
            // 16. Namespaces vs Packages
            NamespacesExample();
            
            // 17. Access Modifiers (differences from Java)
            AccessModifiersExample();
            
            // 18. Static vs Instance (differences)
            StaticVsInstanceExample();
            
            // 19. Enums (more powerful than Java)
            EnumsExample();
            
            // 20. Nullable Value Types vs Optional
            NullableValueTypesExample();

            Console.WriteLine("\n=== Additional Concepts Complete! ===");
        }

        // 1. Value Types vs Reference Types - Critical difference from Java
        private static void ValueTypesVsReferenceTypesExample()
        {
            Console.WriteLine("1. VALUE TYPES vs REFERENCE TYPES");
            Console.WriteLine("==================================");
            
            // Java: Everything except primitives are reference types
            // C#: Value types (struct, enum, primitives) vs Reference types (class, interface, delegate)
            
            Console.WriteLine("Value Types (stored on stack):");
            
            // Value type assignment copies the value
            int a = 10;
            int b = a;  // b gets a copy of a's value
            a = 20;     // Changing a doesn't affect b
            Console.WriteLine($"  a = {a}, b = {b}  // b is unaffected");
            
            // Custom value type (struct)
            var point1 = new Point(1, 2);
            var point2 = point1;  // Copies the entire struct
            // point1.X = 10;        // Cannot modify readonly struct
            Console.WriteLine($"  point1: ({point1.X}, {point1.Y}), point2: ({point2.X}, {point2.Y})");
            
            Console.WriteLine("\nReference Types (stored on heap):");
            
            // Reference type assignment copies the reference
            var person1 = new PersonClass("Alice");
            var person2 = person1;  // person2 points to same object as person1
            person1.Name = "Bob";   // Changes both person1 and person2
            Console.WriteLine($"  person1: {person1.Name}, person2: {person2.Name}  // Both changed");
            
            // Boxing and Unboxing (Java auto-boxing equivalent)
            Console.WriteLine("\nBoxing/Unboxing:");
            int value = 42;
            object boxed = value;        // Boxing: value type -> reference type
            int unboxed = (int)boxed;    // Unboxing: reference type -> value type
            Console.WriteLine($"  Original: {value}, Boxed: {boxed}, Unboxed: {unboxed}");
            
            Console.WriteLine();
        }

        // 2. Structs - No direct Java equivalent
        private static void StructsExample()
        {
            Console.WriteLine("2. STRUCTS (No Java Equivalent)");
            Console.WriteLine("================================");
            
            // Java: Only classes and primitives, no user-defined value types
            // C#: Can create custom value types with structs
            
            Console.WriteLine("Creating and using structs:");
            
            var rect = new RectangleStruct(10, 20);
            Console.WriteLine($"  Rectangle: Width={rect.Width}, Height={rect.Height}, Area={rect.Area}");
            
            // Structs are immutable by design (best practice)
            var newRect = rect.WithWidth(15);  // Returns new struct
            Console.WriteLine($"  New Rectangle: Width={newRect.Width}, Height={newRect.Height}");
            Console.WriteLine($"  Original unchanged: Width={rect.Width}, Height={rect.Height}");
            
            // Struct vs Class performance
            Console.WriteLine("\nPerformance difference:");
            Console.WriteLine("  - Structs: Stack allocated, no GC pressure, copied by value");
            Console.WriteLine("  - Classes: Heap allocated, GC managed, copied by reference");
            
            Console.WriteLine();
        }

        // 3. Tuples - Limited Java support
        private static void TuplesExample()
        {
            Console.WriteLine("3. TUPLES");
            Console.WriteLine("=========");
            
            // Java: Limited tuple support (Pair class, Records in Java 14+)
            // C#: Built-in tuple support with named fields
            
            Console.WriteLine("Named tuples:");
            
            // Create named tuple
            var person = (Name: "Alice", Age: 30, Department: "Engineering");
            Console.WriteLine($"  Person: {person.Name}, {person.Age}, {person.Department}");
            
            // Tuple deconstruction
            var (name, age, dept) = person;
            Console.WriteLine($"  Deconstructed: {name}, {age}, {dept}");
            
            // Method returning tuple
            var (min, max, avg) = CalculateStats(new[] { 1, 5, 3, 9, 2 });
            Console.WriteLine($"  Stats: Min={min}, Max={max}, Avg={avg:F1}");
            
            // Tuple as method parameter
            PrintPersonInfo((Name: "Bob", Age: 25, City: "Seattle"));
            
            // Tuple collections
            var employees = new List<(string Name, decimal Salary, string Dept)>
            {
                ("Alice", 75000, "Engineering"),
                ("Bob", 65000, "Marketing"),
                ("Carol", 80000, "Engineering")
            };
            
            Console.WriteLine("  Employee tuples:");
            foreach (var emp in employees)
            {
                Console.WriteLine($"    {emp.Name}: ${emp.Salary} ({emp.Dept})");
            }
            
            Console.WriteLine();
        }

        // Helper methods for tuples
        private static (int Min, int Max, double Average) CalculateStats(int[] numbers)
        {
            return (numbers.Min(), numbers.Max(), numbers.Average());
        }
        
        private static void PrintPersonInfo((string Name, int Age, string City) person)
        {
            Console.WriteLine($"  Person info: {person.Name}, {person.Age} years old, lives in {person.City}");
        }

        // 4. Anonymous Types - No Java equivalent
        private static void AnonymousTypesExample()
        {
            Console.WriteLine("4. ANONYMOUS TYPES (No Java Equivalent)");
            Console.WriteLine("========================================");
            
            // Java: No anonymous types, must create classes
            // C#: Can create types on-the-fly
            
            Console.WriteLine("Creating anonymous types:");
            
            // Anonymous type with inferred property names
            var product = new { Name = "Laptop", Price = 999.99, InStock = true };
            Console.WriteLine($"  Product: {product.Name}, ${product.Price}, InStock: {product.InStock}");
            
            // Anonymous types in LINQ projections
            var employees = new[]
            {
                new { Name = "Alice", Salary = 75000, Dept = "Engineering" },
                new { Name = "Bob", Salary = 65000, Dept = "Marketing" }
            };
            
            var summary = employees
                .Where(e => e.Salary > 60000)
                .Select(e => new { e.Name, e.Dept, TaxBracket = e.Salary > 70000 ? "High" : "Medium" })
                .ToList();
            
            Console.WriteLine("  Employee summary:");
            foreach (var emp in summary)
            {
                Console.WriteLine($"    {emp.Name} ({emp.Dept}): {emp.TaxBracket} tax bracket");
            }
            
            // Anonymous types are immutable and type-safe
            Console.WriteLine("\n  Anonymous type characteristics:");
            Console.WriteLine("    - Immutable (read-only properties)");
            Console.WriteLine("    - Type-safe (strongly typed)");
            Console.WriteLine("    - Compiler-generated names");
            Console.WriteLine("    - Useful for temporary projections");
            
            Console.WriteLine();
        }

        // 5. Var vs Dynamic - Java doesn't have dynamic
        private static void VarVsDynamicExample()
        {
            Console.WriteLine("5. VAR vs DYNAMIC");
            Console.WriteLine("=================");
            
            // Java: var (Java 10+) similar to C# var, no dynamic equivalent
            // C#: var (compile-time) vs dynamic (runtime)
            
            Console.WriteLine("var (compile-time type inference):");
            var number = 42;        // Compiler knows this is int
            var text = "Hello";     // Compiler knows this is string
            var list = new List<string>(); // Compiler knows this is List<string>
            
            Console.WriteLine($"  number type: {number.GetType().Name}");
            Console.WriteLine($"  text type: {text.GetType().Name}");
            Console.WriteLine($"  list type: {list.GetType().Name}");
            
            Console.WriteLine("\ndynamic (runtime type resolution):");
            dynamic obj = 42;
            Console.WriteLine($"  obj as int: {obj} (type: {obj.GetType().Name})");
            
            obj = "Now I'm a string";
            Console.WriteLine($"  obj as string: {obj} (type: {obj.GetType().Name})");
            
            obj = new List<int> { 1, 2, 3 };
            Console.WriteLine($"  obj as List: Count = {obj.Count} (type: {obj.GetType().Name})");
            
            // Dynamic method calls (resolved at runtime)
            dynamic calculator = new Calculator();
            var result = calculator.Add(5, 3);  // Method call resolved at runtime
            Console.WriteLine($"  Dynamic method call result: {result}");
            
            Console.WriteLine("\n  Key differences:");
            Console.WriteLine("    - var: Type determined at compile-time, type-safe");
            Console.WriteLine("    - dynamic: Type resolved at runtime, no compile-time checking");
            Console.WriteLine("    - Use var for type inference, dynamic for interop scenarios");
            
            Console.WriteLine();
        }

        // 6. Indexers - No Java equivalent
        private static void IndexersExample()
        {
            Console.WriteLine("6. INDEXERS (No Java Equivalent)");
            Console.WriteLine("=================================");
            
            // Java: Must use get/set methods like getItem(index), setItem(index, value)
            // C#: Can use array-like syntax with custom logic
            
            Console.WriteLine("Using indexers:");
            
            var dictionary = new SmartDictionary<string, int>();
            
            // Set values using indexer
            dictionary["apple"] = 5;
            dictionary["banana"] = 3;
            dictionary["cherry"] = 8;
            
            // Get values using indexer
            Console.WriteLine($"  apple: {dictionary["apple"]}");
            Console.WriteLine($"  banana: {dictionary["banana"]}");
            Console.WriteLine($"  non-existent: {dictionary["grape"]}");  // Returns default value
            
            // Multiple parameter indexers
            var matrix = new Matrix(3, 3);
            matrix[0, 0] = 1;
            matrix[1, 1] = 5;
            matrix[2, 2] = 9;
            
            Console.WriteLine($"  Matrix[0,0]: {matrix[0, 0]}");
            Console.WriteLine($"  Matrix[1,1]: {matrix[1, 1]}");
            Console.WriteLine($"  Matrix[2,2]: {matrix[2, 2]}");
            
            Console.WriteLine();
        }

        // 7. Operator Overloading - Limited in Java
        private static void OperatorOverloadingExample()
        {
            Console.WriteLine("7. OPERATOR OVERLOADING");
            Console.WriteLine("=======================");
            
            // Java: Very limited operator overloading (only + for strings)
            // C#: Can overload most operators
            
            Console.WriteLine("Custom operators:");
            
            var v1 = new Vector(3, 4);
            var v2 = new Vector(1, 2);
            
            // Addition operator
            var sum = v1 + v2;
            Console.WriteLine($"  {v1} + {v2} = {sum}");
            
            // Multiplication operator
            var scaled = v1 * 2;
            Console.WriteLine($"  {v1} * 2 = {scaled}");
            
            // Equality operators
            var v3 = new Vector(3, 4);
            Console.WriteLine($"  {v1} == {v3}: {v1 == v3}");
            Console.WriteLine($"  {v1} == {v2}: {v1 == v2}");
            
            // Comparison operators
            Console.WriteLine($"  {v1} > {v2}: {v1 > v2}");  // Based on magnitude
            
            Console.WriteLine("\n  Overloadable operators:");
            Console.WriteLine("    - Arithmetic: +, -, *, /, %");
            Console.WriteLine("    - Comparison: ==, !=, <, >, <=, >=");
            Console.WriteLine("    - Logical: !, &, |, ^");
            Console.WriteLine("    - Increment/Decrement: ++, --");
            
            Console.WriteLine();
        }

        // 8. Events vs Observer Pattern
        private static void EventsVsObserversExample()
        {
            Console.WriteLine("8. EVENTS vs OBSERVER PATTERN");
            Console.WriteLine("==============================");
            
            // Java: Observer pattern with interfaces, or functional interfaces
            // C#: Built-in event syntax with delegates
            
            Console.WriteLine("C# Events (built-in observer pattern):");
            
            var publisher = new NewsPublisher();
            var subscriber1 = new NewsSubscriber("Alice");
            var subscriber2 = new NewsSubscriber("Bob");
            
            // Subscribe to events
            publisher.NewsPublished += subscriber1.OnNewsReceived;
            publisher.NewsPublished += subscriber2.OnNewsReceived;
            
            // Anonymous event handlers
            publisher.NewsPublished += (sender, args) => 
                Console.WriteLine($"  Anonymous handler: {args.Title}");
            
            // Publish news
            publisher.PublishNews("Breaking: C# 13 Released!");
            
            // Unsubscribe
            publisher.NewsPublished -= subscriber1.OnNewsReceived;
            
            Console.WriteLine("\nAfter unsubscribing Alice:");
            publisher.PublishNews("Update: New Features Announced");
            
            Console.WriteLine("\n  Event advantages over Observer pattern:");
            Console.WriteLine("    - Type-safe multicast delegates");
            Console.WriteLine("    - Built-in null checking");
            Console.WriteLine("    - Easy subscribe/unsubscribe with += and -=");
            Console.WriteLine("    - Encapsulation (external classes can't raise events)");
            
            Console.WriteLine();
        }

        // 9. Reflection - Different API from Java
        private static void ReflectionExample()
        {
            Console.WriteLine("9. REFLECTION (Different API from Java)");
            Console.WriteLine("=======================================");
            
            // Java: Class.forName(), getMethod(), etc.
            // C#: Type.GetType(), GetMethod(), etc.
            
            Console.WriteLine("Type information:");
            
            var person = new PersonClass("Alice");
            Type personType = person.GetType();
            
            Console.WriteLine($"  Type name: {personType.Name}");
            Console.WriteLine($"  Full name: {personType.FullName}");
            Console.WriteLine($"  Assembly: {personType.Assembly.GetName().Name}");
            
            Console.WriteLine("\nProperties:");
            var properties = personType.GetProperties();
            foreach (var prop in properties)
            {
                var value = prop.GetValue(person);
                Console.WriteLine($"  {prop.Name}: {value} (Type: {prop.PropertyType.Name})");
            }
            
            Console.WriteLine("\nMethods:");
            var methods = personType.GetMethods()
                .Where(m => m.DeclaringType == personType) // Exclude inherited methods
                .ToArray();
            
            foreach (var methodInfo in methods)
            {
                var parameters = string.Join(", ", methodInfo.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
                Console.WriteLine($"  {methodInfo.Name}({parameters}): {methodInfo.ReturnType.Name}");
            }
            
            Console.WriteLine("\nDynamic method invocation:");
            var methodToInvoke = personType.GetMethod("GetInfo");
            var result = methodToInvoke?.Invoke(person, null);
            Console.WriteLine($"  Dynamic call result: {result}");
            
            Console.WriteLine();
        }

        // 10. Attributes vs Annotations
        private static void AttributesExample()
        {
            Console.WriteLine("10. ATTRIBUTES vs ANNOTATIONS");
            Console.WriteLine("==============================");
            
            // Java: @Override, @Deprecated, custom annotations
            // C#: [Obsolete], [Serializable], custom attributes
            
            Console.WriteLine("Reading attributes:");
            
            var type = typeof(AttributeExample);
            
            // Class-level attributes
            var classAttributes = type.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
            if (classAttributes.Length > 0)
            {
                var desc = (System.ComponentModel.DescriptionAttribute)classAttributes[0];
                Console.WriteLine($"  Class description: {desc.Description}");
            }
            
            // Method attributes
            var method = type.GetMethod("DeprecatedMethod");
            var obsoleteAttr = method?.GetCustomAttribute<ObsoleteAttribute>();
            if (obsoleteAttr != null)
            {
                Console.WriteLine($"  Method marked as obsolete: {obsoleteAttr.Message}");
            }
            
            // Property attributes
            var property = type.GetProperty("ImportantProperty");
            var customAttr = property?.GetCustomAttribute<ImportantAttribute>();
            if (customAttr != null)
            {
                Console.WriteLine($"  Property importance level: {customAttr.Level}");
            }
            
            Console.WriteLine("\n  Common .NET attributes:");
            Console.WriteLine("    - [Obsolete] - Java @Deprecated equivalent");
            Console.WriteLine("    - [Serializable] - Serialization marker");
            Console.WriteLine("    - [DllImport] - P/Invoke for native code");
            Console.WriteLine("    - [Conditional] - Conditional compilation");
            
            Console.WriteLine();
        }

        // 11. LINQ to Objects vs Java Streams (deeper comparison)
        private static void LinqToObjectsExample()
        {
            Console.WriteLine("11. LINQ TO OBJECTS vs JAVA STREAMS (Deep Dive)");
            Console.WriteLine("================================================");
            
            var numbers = Enumerable.Range(1, 10).ToList();
            
            Console.WriteLine("Query syntax vs Method syntax:");
            
            // LINQ Query syntax (no Java equivalent)
            var queryResult = from n in numbers
                             where n % 2 == 0
                             select n * n;
            
            Console.WriteLine($"  Query syntax result: {string.Join(", ", queryResult)}");
            
            // Method syntax (similar to Java streams)
            var methodResult = numbers
                .Where(n => n % 2 == 0)
                .Select(n => n * n);
            
            Console.WriteLine($"  Method syntax result: {string.Join(", ", methodResult)}");
            
            Console.WriteLine("\nComplex query with multiple sources:");
            
            var departments = new[]
            {
                new { Name = "Engineering", Budget = 100000 },
                new { Name = "Marketing", Budget = 75000 },
                new { Name = "Sales", Budget = 80000 }
            };
            
            var employees = new[]
            {
                new { Name = "Alice", Dept = "Engineering", Salary = 75000 },
                new { Name = "Bob", Dept = "Marketing", Salary = 65000 },
                new { Name = "Carol", Dept = "Engineering", Salary = 80000 }
            };
            
            // Join query (more natural than Java streams)
            var joinResult = from emp in employees
                           join dept in departments on emp.Dept equals dept.Name
                           where emp.Salary > 70000
                           select new { emp.Name, emp.Dept, dept.Budget, emp.Salary };
            
            Console.WriteLine("  Join result:");
            foreach (var item in joinResult)
            {
                Console.WriteLine($"    {item.Name} ({item.Dept}): ${item.Salary}, Budget: ${item.Budget}");
            }
            
            Console.WriteLine();
        }

        // 12. Async/Await Deep Dive
        private static async Task AsyncAwaitDeepDiveExample()
        {
            Console.WriteLine("12. ASYNC/AWAIT DEEP DIVE");
            Console.WriteLine("=========================");
            
            // Java: CompletableFuture, callbacks, complex chaining
            // C#: async/await, much simpler syntax
            
            Console.WriteLine("Sequential vs Parallel async operations:");
            
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            
            // Sequential execution
            await SimulateWork("Task 1", 1000);
            await SimulateWork("Task 2", 1000);
            await SimulateWork("Task 3", 1000);
            
            Console.WriteLine($"  Sequential execution took: {stopwatch.ElapsedMilliseconds}ms");
            
            // Parallel execution
            stopwatch.Restart();
            
            var task1 = SimulateWork("Parallel Task 1", 1000);
            var task2 = SimulateWork("Parallel Task 2", 1000);
            var task3 = SimulateWork("Parallel Task 3", 1000);
            
            await Task.WhenAll(task1, task2, task3);
            
            Console.WriteLine($"  Parallel execution took: {stopwatch.ElapsedMilliseconds}ms");
            
            // Error handling with async/await
            Console.WriteLine("\nError handling:");
            try
            {
                await SimulateFailingWork();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"  Caught exception: {ex.Message}");
            }
            
            // ConfigureAwait(false) for library code
            Console.WriteLine("\nConfigureAwait for library code:");
            await SimulateLibraryCall().ConfigureAwait(false);
            
            Console.WriteLine();
        }
        
        private static async Task SimulateWork(string taskName, int delayMs)
        {
            await Task.Delay(delayMs);
            Console.WriteLine($"    {taskName} completed");
        }
        
        private static async Task SimulateFailingWork()
        {
            await Task.Delay(100);
            throw new InvalidOperationException("Simulated async failure");
        }
        
        private static async Task SimulateLibraryCall()
        {
            await Task.Delay(100).ConfigureAwait(false);
            Console.WriteLine("  Library call completed");
        }

        // 13. Memory Management differences
        private static void MemoryManagementExample()
        {
            Console.WriteLine("13. MEMORY MANAGEMENT (GC Differences)");
            Console.WriteLine("======================================");
            
            // Java: Mark and sweep GC, finalize()
            // C#: Generational GC, IDisposable, using statements
            
            Console.WriteLine("IDisposable pattern (no Java equivalent):");
            
            // Using statement ensures disposal
            using (var resource = new DisposableResource("Resource1"))
            {
                resource.DoWork();
                Console.WriteLine("  Resource will be disposed automatically");
            } // Dispose() called here automatically
            
            // Manual disposal
            var resource2 = new DisposableResource("Resource2");
            try
            {
                resource2.DoWork();
            }
            finally
            {
                resource2.Dispose();
            }
            
            Console.WriteLine("\nGC information:");
            Console.WriteLine($"  Total memory: {GC.GetTotalMemory(false):N0} bytes");
            Console.WriteLine($"  Generation 0 collections: {GC.CollectionCount(0)}");
            Console.WriteLine($"  Generation 1 collections: {GC.CollectionCount(1)}");
            Console.WriteLine($"  Generation 2 collections: {GC.CollectionCount(2)}");
            
            // Force garbage collection (usually not recommended)
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine($"  Memory after GC: {GC.GetTotalMemory(true):N0} bytes");
            
            Console.WriteLine();
        }

        // 14. String Handling differences
        private static void StringHandlingExample()
        {
            Console.WriteLine("14. STRING HANDLING (Differences from Java)");
            Console.WriteLine("===========================================");
            
            // Java: String.intern(), StringBuilder
            // C#: string.Intern(), StringBuilder, string interpolation
            
            Console.WriteLine("String interning:");
            
            string s1 = "Hello";
            string s2 = "Hello";
            string s3 = new string("Hello".ToCharArray());
            string s4 = string.Intern(s3);
            
            Console.WriteLine($"  s1 == s2: {ReferenceEquals(s1, s2)} (literal strings are interned)");
            Console.WriteLine($"  s1 == s3: {ReferenceEquals(s1, s3)} (new string not interned)");
            Console.WriteLine($"  s1 == s4: {ReferenceEquals(s1, s4)} (manually interned)");
            
            Console.WriteLine("\nStringBuilder performance:");
            
            var sw = System.Diagnostics.Stopwatch.StartNew();
            
            // Inefficient string concatenation
            string result1 = "";
            for (int i = 0; i < 1000; i++)
            {
                result1 += i.ToString();
            }
            sw.Stop();
            Console.WriteLine($"  String concatenation: {sw.ElapsedMilliseconds}ms");
            
            // Efficient StringBuilder
            sw.Restart();
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < 1000; i++)
            {
                sb.Append(i.ToString());
            }
            string result2 = sb.ToString();
            sw.Stop();
            Console.WriteLine($"  StringBuilder: {sw.ElapsedMilliseconds}ms");
            
            // String interpolation vs formatting
            string name = "Alice";
            int age = 30;
            
            Console.WriteLine("\nString formatting options:");
            Console.WriteLine($"  Interpolation: {"Hello, " + name + ". You are " + age + " years old."}");
            Console.WriteLine($"  String.Format: {string.Format("Hello, {0}. You are {1} years old.", name, age)}");
            Console.WriteLine($"  Interpolation: {"Hello, " + name + ". You are " + age + " years old."}");
            
            Console.WriteLine();
        }

        // Additional examples continue...
        // I'll add the remaining methods for completeness
        
        private static void ExceptionHandlingDeepDiveExample()
        {
            Console.WriteLine("15. EXCEPTION HANDLING (Deep Dive)");
            Console.WriteLine("==================================");
            
            Console.WriteLine("Exception filters (C# specific):");
            
            try
            {
                ThrowCustomException(1);
            }
            catch (CustomException ex) when (ex.ErrorCode == 1)
            {
                Console.WriteLine($"  Caught specific error code: {ex.ErrorCode}");
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"  Caught other error code: {ex.ErrorCode}");
            }
            
            Console.WriteLine("\nFinally vs using:");
            Console.WriteLine("  - finally: Always executes (like Java)");
            Console.WriteLine("  - using: Automatic disposal, C# specific");
            
            Console.WriteLine();
        }

        private static void ThrowCustomException(int code)
        {
            throw new CustomException($"Error with code {code}", code);
        }

        private static void NamespacesExample()
        {
            Console.WriteLine("16. NAMESPACES vs PACKAGES");
            Console.WriteLine("===========================");
            
            Console.WriteLine("Key differences:");
            Console.WriteLine("  Java packages:");
            Console.WriteLine("    - Must match directory structure");
            Console.WriteLine("    - package com.company.project;");
            Console.WriteLine("    - import com.company.project.Class;");
            
            Console.WriteLine("\n  C# namespaces:");
            Console.WriteLine("    - Don't need to match directory structure");
            Console.WriteLine("    - namespace Company.Project;");
            Console.WriteLine("    - using Company.Project;");
            Console.WriteLine("    - Can have nested namespaces");
            Console.WriteLine("    - Global using directives (C# 10+)");
            
            Console.WriteLine();
        }

        private static void AccessModifiersExample()
        {
            Console.WriteLine("17. ACCESS MODIFIERS (Differences)");
            Console.WriteLine("==================================");
            
            Console.WriteLine("Java vs C# access modifiers:");
            Console.WriteLine("  Java: public, protected, package-private (default), private");
            Console.WriteLine("  C#: public, protected, internal, protected internal, private protected, private");
            
            Console.WriteLine("\n  C# specific:");
            Console.WriteLine("    - internal: Visible within same assembly");
            Console.WriteLine("    - protected internal: Protected OR internal");
            Console.WriteLine("    - private protected: Protected AND internal");
            
            Console.WriteLine();
        }

        private static void StaticVsInstanceExample()
        {
            Console.WriteLine("18. STATIC vs INSTANCE (Differences)");
            Console.WriteLine("====================================");
            
            Console.WriteLine("Static constructors (C# specific):");
            Console.WriteLine("  - Called once before first use");
            Console.WriteLine("  - No access modifiers");
            Console.WriteLine("  - Used for static field initialization");
            
            Console.WriteLine("\nStatic classes (C# specific):");
            Console.WriteLine("  - Cannot be instantiated");
            Console.WriteLine("  - Cannot be inherited");
            Console.WriteLine("  - All members must be static");
            
            Console.WriteLine();
        }

        private static void EnumsExample()
        {
            Console.WriteLine("19. ENUMS (More Powerful than Java)");
            Console.WriteLine("===================================");
            
            var status = OrderStatus.Shipped;
            Console.WriteLine($"  Status: {status}");
            Console.WriteLine($"  Status value: {(int)status}");
            Console.WriteLine($"  Status description: {status.GetDescription()}");
            
            // Flags enum (bitwise operations)
            var permissions = FilePermissions.Read | FilePermissions.Write;
            Console.WriteLine($"  Permissions: {permissions}");
            Console.WriteLine($"  Has Read: {permissions.HasFlag(FilePermissions.Read)}");
            Console.WriteLine($"  Has Execute: {permissions.HasFlag(FilePermissions.Execute)}");
            
            Console.WriteLine();
        }

        private static void NullableValueTypesExample()
        {
            Console.WriteLine("20. NULLABLE VALUE TYPES vs OPTIONAL");
            Console.WriteLine("====================================");
            
            // Java: Optional<Integer>, primitive wrappers
            // C#: int?, Nullable<int>
            
            int? nullableInt = null;
            int? anotherInt = 42;
            
            Console.WriteLine($"  nullableInt.HasValue: {nullableInt.HasValue}");
            Console.WriteLine($"  anotherInt.HasValue: {anotherInt.HasValue}");
            Console.WriteLine($"  anotherInt.Value: {anotherInt.Value}");
            
            // Null coalescing
            int result = nullableInt ?? 0;
            Console.WriteLine($"  Result with null coalescing: {result}");
            
            // Null conditional operator
            int? length = nullableInt?.ToString()?.Length;
            Console.WriteLine($"  Conditional length: {length}");
            
            Console.WriteLine();
        }
    }

    // Supporting classes and structs for examples
    
    public struct Point
    {
        public int X { get; }
        public int Y { get; }
        
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public readonly struct RectangleStruct
    {
        public double Width { get; }
        public double Height { get; }
        public double Area => Width * Height;
        
        public RectangleStruct(double width, double height)
        {
            Width = width;
            Height = height;
        }
        
        public RectangleStruct WithWidth(double newWidth) => new RectangleStruct(newWidth, Height);
    }

    public class PersonClass
    {
        public string Name { get; set; } = string.Empty;
        
        public PersonClass(string name)
        {
            Name = name;
        }
        
        public string GetInfo() => $"Person: {Name}";
    }

    // Indexer examples
    public class SmartDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _data = new Dictionary<TKey, TValue>();
        
        public TValue this[TKey key]
        {
            get => _data.TryGetValue(key, out var value) ? value : default(TValue);
            set => _data[key] = value;
        }
    }

    public class Matrix
    {
        private readonly double[,] _data;
        
        public Matrix(int rows, int cols)
        {
            _data = new double[rows, cols];
        }
        
        public double this[int row, int col]
        {
            get => _data[row, col];
            set => _data[row, col] = value;
        }
    }

    // Operator overloading example
    public struct Vector
    {
        public double X { get; }
        public double Y { get; }
        public double Magnitude => Math.Sqrt(X * X + Y * Y);
        
        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }
        
        public static Vector operator +(Vector a, Vector b)
            => new Vector(a.X + b.X, a.Y + b.Y);
        
        public static Vector operator *(Vector v, double scalar)
            => new Vector(v.X * scalar, v.Y * scalar);
        
        public static bool operator ==(Vector a, Vector b)
            => a.X == b.X && a.Y == b.Y;
        
        public static bool operator !=(Vector a, Vector b)
            => !(a == b);
        
        public static bool operator >(Vector a, Vector b)
            => a.Magnitude > b.Magnitude;
        
        public static bool operator <(Vector a, Vector b)
            => a.Magnitude < b.Magnitude;
        
        public override bool Equals(object obj)
            => obj is Vector v && this == v;
        
        public override int GetHashCode()
            => HashCode.Combine(X, Y);
        
        public override string ToString()
            => $"({X}, {Y})";
    }

    // Events example
    public class NewsPublisher
    {
        public event EventHandler<NewsEventArgs> NewsPublished;
        
        public void PublishNews(string title)
        {
            NewsPublished?.Invoke(this, new NewsEventArgs(title));
        }
    }

    public class NewsEventArgs : EventArgs
    {
        public string Title { get; }
        
        public NewsEventArgs(string title)
        {
            Title = title;
        }
    }

    public class NewsSubscriber
    {
        private readonly string _name;
        
        public NewsSubscriber(string name)
        {
            _name = name;
        }
        
        public void OnNewsReceived(object sender, NewsEventArgs e)
        {
            Console.WriteLine($"  {_name} received news: {e.Title}");
        }
    }

    // Dynamic example
    public class Calculator
    {
        public int Add(int a, int b) => a + b;
        public double Add(double a, double b) => a + b;
    }

    // Disposable example
    public class DisposableResource : IDisposable
    {
        private readonly string _name;
        private bool _disposed = false;
        
        public DisposableResource(string name)
        {
            _name = name;
            Console.WriteLine($"  {_name} created");
        }
        
        public void DoWork()
        {
            if (_disposed) throw new ObjectDisposedException(_name);
            Console.WriteLine($"  {_name} doing work");
        }
        
        public void Dispose()
        {
            if (!_disposed)
            {
                Console.WriteLine($"  {_name} disposed");
                _disposed = true;
            }
        }
    }

    // Attributes example
    [System.ComponentModel.Description("Example class for demonstrating attributes")]
    public class AttributeExample
    {
        [Obsolete("Use NewMethod instead")]
        public void DeprecatedMethod()
        {
            // Old implementation
        }
        
        [Important(Level = ImportanceLevel.High)]
        public string ImportantProperty { get; set; }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
    public class ImportantAttribute : Attribute
    {
        public ImportanceLevel Level { get; set; }
    }

    public enum ImportanceLevel
    {
        Low,
        Medium,
        High,
        Critical
    }

    // Enum examples
    public enum OrderStatus
    {
        Pending = 1,
        Processing = 2,
        Shipped = 3,
        Delivered = 4,
        Cancelled = 5
    }

    [Flags]
    public enum FilePermissions
    {
        None = 0,
        Read = 1,
        Write = 2,
        Execute = 4,
        All = Read | Write | Execute
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this OrderStatus status)
        {
            return status switch
            {
                OrderStatus.Pending => "Order is pending",
                OrderStatus.Processing => "Order is being processed",
                OrderStatus.Shipped => "Order has been shipped",
                OrderStatus.Delivered => "Order has been delivered",
                OrderStatus.Cancelled => "Order was cancelled",
                _ => "Unknown status"
            };
        }
    }

    // Custom exception
    public class CustomException : Exception
    {
        public int ErrorCode { get; }
        
        public CustomException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
