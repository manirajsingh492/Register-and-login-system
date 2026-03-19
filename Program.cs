using System;

namespace Login
{
	class Program
	{
		static void Main(string[] args)
		{
			var userService = new UserService();

			while (true)
			{
				Console.Clear();
				Console.WriteLine("===== Account System =====");
				Console.WriteLine("1. Register");
				Console.WriteLine("2. Login");
				Console.WriteLine("3. Quit");
				Console.Write("Choose an option: ");
				string choice = Console.ReadLine()!.Trim();

				switch (choice)
				{
					case "1":
						userService.RegisterUser();
						break;

					case "2":
						userService.LoginUser();
						break;
					case "3":
						Console.WriteLine("Goodbye!");
						return;
					default:
						Console.WriteLine("Invalid choice. Press any key to try again...");
						Console.ReadKey();
						break;
				}
			}
		}
	}
}