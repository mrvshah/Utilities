// Type: System.IO.Directory
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.AccessControl;

namespace System.IO
{
	[ComVisible(true)]
	public static class Directory
	{
		[SecuritySafeCritical]
		public static DirectoryInfo GetParent(string path);

		[SecuritySafeCritical]
		public static DirectoryInfo CreateDirectory(string path);

		[SecuritySafeCritical]
		public static DirectoryInfo CreateDirectory(string path, DirectorySecurity directorySecurity);

		[SecuritySafeCritical]
		public static bool Exists(string path);

		public static void SetCreationTime(string path, DateTime creationTime);

		[SecuritySafeCritical]
		public static void SetCreationTimeUtc(string path, DateTime creationTimeUtc);

		[SecuritySafeCritical]
		public static DateTime GetCreationTime(string path);

		[SecuritySafeCritical]
		public static DateTime GetCreationTimeUtc(string path);

		public static void SetLastWriteTime(string path, DateTime lastWriteTime);

		[SecuritySafeCritical]
		public static void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);

		[SecuritySafeCritical]
		public static DateTime GetLastWriteTime(string path);

		[SecuritySafeCritical]
		public static DateTime GetLastWriteTimeUtc(string path);

		public static void SetLastAccessTime(string path, DateTime lastAccessTime);

		[SecuritySafeCritical]
		public static void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);

		[SecuritySafeCritical]
		public static DateTime GetLastAccessTime(string path);

		[SecuritySafeCritical]
		public static DateTime GetLastAccessTimeUtc(string path);

		public static DirectorySecurity GetAccessControl(string path);
		public static DirectorySecurity GetAccessControl(string path, AccessControlSections includeSections);

		[SecuritySafeCritical]
		public static void SetAccessControl(string path, DirectorySecurity directorySecurity);

		public static string[] GetFiles(string path);
		public static string[] GetFiles(string path, string searchPattern);
		public static string[] GetFiles(string path, string searchPattern, SearchOption searchOption);
		public static string[] GetDirectories(string path);
		public static string[] GetDirectories(string path, string searchPattern);
		public static string[] GetDirectories(string path, string searchPattern, SearchOption searchOption);
		public static string[] GetFileSystemEntries(string path);
		public static string[] GetFileSystemEntries(string path, string searchPattern);
		public static string[] GetFileSystemEntries(string path, string searchPattern, SearchOption searchOption);
		public static IEnumerable<string> EnumerateDirectories(string path);
		public static IEnumerable<string> EnumerateDirectories(string path, string searchPattern);
		public static IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption);
		public static IEnumerable<string> EnumerateFiles(string path);
		public static IEnumerable<string> EnumerateFiles(string path, string searchPattern);
		public static IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption);
		public static IEnumerable<string> EnumerateFileSystemEntries(string path);
		public static IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern);

		public static IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern,
		                                                             SearchOption searchOption);

		[SecuritySafeCritical]
		public static string[] GetLogicalDrives();

		[SecuritySafeCritical]
		public static string GetDirectoryRoot(string path);

		[SecuritySafeCritical]
		public static string GetCurrentDirectory();

		[SecuritySafeCritical]
		public static void SetCurrentDirectory(string path);

		[SecuritySafeCritical]
		public static void Move(string sourceDirName, string destDirName);

		[SecuritySafeCritical]
		public static void Delete(string path);

		[SecuritySafeCritical]
		public static void Delete(string path, bool recursive);
	}
}
