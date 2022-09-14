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


		public static void Save(ScoreHolder scores)
		{

			var ssd = new ScoreSaveDataList();
			foreach (var s in scores.scores)
			{
				ssd.scores.Add(new ScoreSaveData(s));
			}

			var json = JsonUtility.ToJson(ssd);
			File.WriteAllText(GetPathWithFile(), json);
			//File.WriteAllText(GetPath(), json);
		}

		public static bool Load(ScoreHolder scoreHolder)
		{
			if (!Directory.Exists(Application.persistentDataPath + dir)) return false;
			var x = File.ReadAllText(GetPath());
			var saves = JsonUtility.FromJson<ScoreSaveDataList>(x);
			scoreHolder.LoadScores(saves);
			return true;
		}
	}

	[Serializable]
	public class ScoreSaveData
	{
		public int gold;
		public float time;

		public ScoreSaveData(Highscore s)
		{
			gold = s.gold;
			time = s.time;
		}
	}
	
	[Serializable]
	public class ScoreSaveDataList
	{
		public List<ScoreSaveData> scores = new List<ScoreSaveData>();
	
	}
}