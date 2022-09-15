using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

namespace StuartH
{
	/// <summary>
	///SaveFileHandler - Handles the saving and loading of the highscores
	/// </summary>
	public static class SaveFileHandler
	{
		const string dir = "/SaveData/";
		private static string GetPathWithFile() => Application.persistentDataPath + "/gamedata.json";
		private static string GetPath() => Application.persistentDataPath  ;

		public static void Save(ScoreHolder scoreHolder)
		{
			Debug.Log("Trying to save to" + GetPathWithFile());

			var json = JsonUtility.ToJson(scoreHolder.scores);
			File.WriteAllText(GetPathWithFile(), json);
			Debug.Log("Saved file");

		}

		public static void Load(ScoreHolder scoreHolder)
		{
			Debug.Log("Trying to load from" + GetPathWithFile());
			if (!Directory.Exists(GetPath()))
			{
				Debug.Log("failed to access dir");
				return ;
			}

			if (!File.Exists(GetPathWithFile())) return ;
			var x = File.ReadAllText(GetPathWithFile());
			var sh = JsonUtility.FromJson<ScoreHolder.ScoreSaveDataList>(x);
			scoreHolder.LoadScores(sh);
			Debug.Log("Loaded file");
			return ;
		}
	}

	
}