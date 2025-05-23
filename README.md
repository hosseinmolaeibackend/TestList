
# TestList

A .NET console application demonstrating various C# concepts, including hashing, benchmarking with BenchmarkDotNet, and collection performance comparisons.

## Features

- **Hashing Utilities:**  
  Generate SHA256 hashes for strings and securely hash passwords using PBKDF2.
- **Benchmarking:**  
  Uses BenchmarkDotNet to compare performance between different C# collections and StringBuilder operations.
- **Sample Algorithms:**  
  Includes a power function and demonstrates usage of C# delegates.
- **Performance Measurement:**  
  Example code for timing operations with `Stopwatch`.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later recommended)
- [BenchmarkDotNet](https://benchmarkdotnet.org/) NuGet package

### Running the Application

1. Clone the repository:
   ```bash
   git clone https://github.com/hosseinmolaeibackend/TestList.git
   ```
2. Navigate to the project directory:
   ```bash
   cd TestList/ConsoleApp8
   ```
3. Restore dependencies:
   ```bash
   dotnet restore
   ```
4. Run the application:
   ```bash
   dotnet run
   ```

### Running Benchmarks

The `Main` method runs benchmarks using BenchmarkDotNet. The following collection and string operations are benchmarked:

- List of objects
- List of strings
- List of integers
- StringBuilder operations

To see the benchmark results, simply run the application as described above.

## Example Usage

### Hashing a String

```csharp
string hash = Program.GetHashString("your string here");
Console.WriteLine(hash);
```

### Hashing a Password

```csharp
var hasher = new hashing();
string hashedPassword = hasher.HashPassword("yourPassword");
Console.WriteLine(hashedPassword);
```

## Project Structure

- `Program.cs` — Main application logic, hashing utilities, benchmarking classes, and test methods.

## Dependencies

- [BenchmarkDotNet](https://www.nuget.org/packages/BenchmarkDotNet)
- System.Security.Cryptography

## License

This project is licensed under the MIT License.
