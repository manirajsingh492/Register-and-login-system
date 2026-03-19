using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Login
{
	public class FileService
	{
		private readonly string dataDir = "Data";

		public FileService()
		{
			if (!Directory.Exists(dataDir))
				Directory.CreateDirectory(dataDir);
		}

		
		public void SaveUser(User user)
		{
			string filePath = Path.Combine(dataDir, $"{user.Username}.txt");
			File.WriteAllLines(filePath, new[] { $"username:{user.Username}",
				$"password:{user.Password}" });
		}

		// Read a user file, return User object
		public User? 
			ReadUser(string username)
		{
			string filePath = Path.Combine(dataDir, $"{username}.txt");
			if (!File.Exists(filePath))
				return null;

			var lines = File.ReadAllLines(filePath);
			return new User
			{
				Username = lines[0].Split(':')[1],
				Password = lines[1].Split(':')[1]
			};
		}

		// Get all registered usernames
		public List<string> GetAllUsernames()
		{
			return Directory.GetFiles(dataDir, "*.txt")
							.Select(f => Path.GetFileNameWithoutExtension(f))
							.Where(f => f.ToLower() != "password") // exclude password.txt
							.ToList();
		}

		// Get all common passwords from password.txt
		public List<string> GetCommonPasswords()
		{
			string commonFile = Path.Combine(dataDir, "password.txt");
			if (!File.Exists(commonFile))
				return new List<string>();

			return File.ReadAllLines(commonFile).ToList();
		}
	}
}