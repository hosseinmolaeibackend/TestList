using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp8
{
	internal class Program
	{
		public static byte[] GetHash(string inputString)
		{
			using (HashAlgorithm algorithm = SHA256.Create())
				return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
		}
		public static string GetHashString(string inputString)
		{
			StringBuilder sb = new StringBuilder();
			foreach (byte b in GetHash(inputString))
				sb.Append(b.ToString("X2"));

			return sb.ToString();
		}
		static void Main(string[] args)
		{
			//int? m3 = 4;
			//string? name = "hossein";
			//Console.WriteLine(name + null);

			//Stopwatch sw = new Stopwatch();
			//sw.Start();
			//List<object> list = new List<object>();
			//list.Add(1);
			//list.Add("hossein");
			//list.Add(3.56);
			//foreach (var item in list)
			//{
			//	Console.WriteLine(item);
			//}
			//sw.Stop();
			//Console.WriteLine("obj list: " + sw + " s");
			//Stopwatch sw1 = new Stopwatch();
			//sw1.Start();

			//List<string> list2 = new List<string>();
			//list2.Add("1");
			//list2.Add("2");
			//list2.Add("3");
			//foreach (var item in list2)
			//{
			//	Console.WriteLine(item);
			//}
			//sw1.Stop();
			//Console.WriteLine("str list: " + sw1 + " s");

			//Stopwatch sw2 = new Stopwatch();
			//sw2.Start();
			//List<int> list3 = new List<int>();
			//list3.Add(1);
			//list3.Add(2);
			//list3.Add(3);
			//foreach (var item in list3)
			//{
			//	Console.WriteLine(item);
			//}
			//sw2.Stop();
			//Console.WriteLine("int list: " + sw2 + " s");

			//Stopwatch sw3 = new Stopwatch();
			//sw3.Start();
			//StringBuilder sb = new StringBuilder();
			//sb.Append('c', 55);
			//sb.Append('a', 53);
			//sb.Append('b', 88);
			//sb.Append('f', 76);
			//Console.WriteLine($"sb string builder:{sb.ToString()}");
			//sw3.Stop();
			//Console.WriteLine($"string builder: {sw3} s");

			BenchmarkRunner.Run<listTest>();


		}

	}
	public class listTest
	{
		[Benchmark]
		public List<object> listObjectTesting()
		{
			List<object> list = new List<object>();
			list.Add(1);
			list.Add("hossein");
			list.Add(3.56);
			
			return list;
		}
		[Benchmark]
		public List<string> listStringTesting2()
		{
			List<string> list2 = new List<string>();
			list2.Add("1");
			list2.Add("2");
			list2.Add("3");
			
			return list2;
		}
		[Benchmark]
		public List<int> ListIntTesting()
		{
			List<int> list3 = new List<int>();
			list3.Add(1);
			list3.Add(2);
			list3.Add(3);

			return list3;
		}
		[Benchmark]
		public string ListStringBuilderTesting()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append('c', 55);
			sb.Append('a', 53);
			sb.Append('b', 88);
			sb.Append('f', 76);
			return sb.ToString();
		}
	}
	public class Test
	{
		public static int power(int x, int y)
		{
			for (int i = 0; i < y; i++)
			{
				x *= x;
			}
			return x;
		}

		internal static int power(int x)
		{
			throw new NotImplementedException();
		}
	}

	delegate int Transform(int x, int y);
	public class hashing
	{
		public string HashPassword(string password)
		{
			byte[] salt = new byte[256 / 8];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(salt);
			}

			byte[] hash = PBKDF2(
				password: password,
				salt: salt,
				iterations: 100000,
				hashAlgorithm: HashAlgorithmName.SHA256,
				outputLength: 128 / 4
			);

			return Convert.ToBase64String(salt) + "|" + Convert.ToBase64String(hash);
		}

		private byte[] PBKDF2(string password, byte[] salt, int iterations, HashAlgorithmName hashAlgorithm, int outputLength)
		{
			using var pbkdf2 = new Rfc2898DeriveBytes(
				password,
				salt,
				iterations,
				hashAlgorithm
			);
			return pbkdf2.GetBytes(outputLength);
		}
	}
}


//hashing hashing = new hashing();
//var hash = hashing.HashPassword("123456789");
//string inputString = "AQAAAAIAAYagAAAAEPO1JK5lfDAQiO9lVY9Ler2CQF6ApP2JEBQg/QUeknqamMsVkai+JTApKjwPffMBPg==";
//Console.WriteLine($"hash lenght: {hash.Length} \n identity hash lenght: {inputString.Length}");

//long sum = 0;
//object lockObject = new object();
//Stopwatch stopwatch = Stopwatch.StartNew();

//Parallel.For(1, 100000001, i =>
//{
//	long square = (long)i * i;
//	lock (lockObject) // جلوگیری از تداخل در جمع
//	{
//		sum += square;
//	}
//});

//stopwatch.Stop();

//Console.WriteLine($"sum : {sum}");
//Console.WriteLine($"Excute time:" +
//	$" {stopwatch.Elapsed.TotalSeconds} seconds");