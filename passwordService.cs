using System;
using System.Collections.Generic;

namespace Login
{
	public class PasswordService
	{
		private readonly FileService _fileService;

		public PasswordService(FileService fileService)
		{
			_fileService = fileService;
		}

		// Check if password is strong
		public bool IsPasswordStrong(string password)
		{
			// Check minimum length
			if (password.Length < 10)
				return false;

			// Check against common passwords
			List<string> commonPasswords = _fileService.GetCommonPasswords();
			if (commonPasswords.Contains(password))
				return false;

			return true;
		}
	}
}