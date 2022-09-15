using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace StuartH
{
	/// <summary>
	///SaveFileHandler - Handles the saving and loading of the highscores
	/// </summary>
	public static class SaveFileHandler
	{
		const string dir = "/SaveData/";
		private static string GetPathWithFile() => Application.persistentDataPath + "/gamedata.json";

		private static string GetPath() => Application.persistentDataPath + dir ;


		public static void Save(ScoreHolder scoreHolder)
		{

			
			var json = JsonUtility.ToJson(scoreHolder.scores);
			File.WriteAllText(GetPathWithFile(), json);
		}

		public static bool Load(ScoreHolder scoreHolder)
		{
			if (!Directory.Exists(Application.persistentDataPath + dir)) return false;
			var x = File.ReadAllText(GetPath());
			var saves = JsonUtility.FromJson<ScoreHolder.ScoreSaveDataList>(x);
			scoreHolder.LoadScores(saves);
			return true;
		}
	}

	
}