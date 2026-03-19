using System;

namespace Login
{
	public class UserService
	{
		private readonly FileService _fileService;
		private readonly PasswordService _passwordService;

		public UserService()
		{
			_fileService = new FileService();
			_passwordService = new PasswordService(_fileService);
		}

		// Register a new user
		public void RegisterUser()
		{
			Console.Clear();
			Console.WriteLine("=== Register ===");

			Console.Write("Enter username: ");
			string username = Console.ReadLine()!.Trim();

			// Check for duplicate username
			if (_fileService.GetAllUsernames().Contains(username))
			{
				Console.WriteLine("Username already exists. Press any key to try again...");
				Console.ReadKey();
				return;
			}

			Console.Write("Enter password: ");
			string password = Console.ReadLine()!.Trim();

			// Validate password
			if (!_passwordService.IsPasswordStrong(password))
			{
				Console.WriteLine("Password too weak. Must be ≥10 characters and not common.");
				Console.ReadKey();
				return;
			}

			// Save user
			User user = new User { Username = username, Password = password };
			_fileService.SaveUser(user);

			Console.WriteLine("Registration successful! Press any key to continue...");
			Console.ReadKey();
		}

		// Login existing user
		public void LoginUser()
		{
			Console.Clear();
			Console.WriteLine("=== Login ===");

			Console.Write("Enter username: ");
			string username = Console.ReadLine()!.Trim();

			Console.Write("Enter password: ");
			string password = Console.ReadLine()!.Trim();

			User? user = _fileService.ReadUser(username);

			if (user != null && user.Password == password)
			{
				Console.WriteLine("Login successful!");
			}
			else
			{
				Console.WriteLine("Login failed. Try again.");
			}

			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}
	}
}