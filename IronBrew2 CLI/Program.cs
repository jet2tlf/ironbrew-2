using System;
using System.IO;
using System.Text;
using IronBrew2;
using IronBrew2.Obfuscator;

namespace IronBrew2_CLI
{
	class Program
	{
		static void Main(string[] args)
		{
			if (Directory.Exists("temp"))
				Directory.Delete("temp", true);
			Directory.CreateDirectory("temp");
			if (!IB2.Obfuscate("temp",  args[0], new ObfuscationSettings(), out string err))
			{
				Console.WriteLine("ERR: " + err);
				return;
			}

			File.Delete("output.lua");
			File.Move("temp/output.lua", "output.lua");
			Console.WriteLine("Done!");
		}
	}
}