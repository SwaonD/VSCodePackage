using System;
using System.IO;
using UnityEngine;

namespace VSCodeEditor
{
	public static class	FrameworkVersion
	{
		public static string	GetFrameWorkVersion()
		{
			string folderPath = $"C:\\Program Files\\Unity\\Hub\\Editor\\{Application.unityVersion}\\Editor\\Data\\MonoBleedingEdge\\lib\\mono\\xbuild-frameworks\\.NETFramework";
			if (Directory.Exists(folderPath))
			{
				try
				{
					string[] dir = Directory.GetDirectories(folderPath);

					string version = Path.GetFileName(dir[^1]);
					return (version);
				}
				catch (Exception e)
				{
					Debug.LogError("Error access folder (back to Framework v4.7.1) : " + e.Message);
					return ("v4.7.1");
				}
			}
			else
			{
				Debug.LogError("Error Framework version import, beck to v4.7.1");
				return ("v4.7.1");
			}
		}
	}
}
