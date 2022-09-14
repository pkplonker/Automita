
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public static class SaveFileHandler 
{
	const string dir = "/SaveData/";
	private static string GetPath()=>Application.persistentDataPath + dir + ".txt";
	
	
	public static void Save(ScoreHolder scores)
	{

		var ssd = new List<ScoreSaveData>();
		foreach (var s in scores.scores)
		{
			ssd.Add(new ScoreSaveData(s));
		}
		
		if (!Directory.Exists(Application.persistentDataPath + dir)) Directory.CreateDirectory(dir);
		var json = JsonUtility.ToJson(ssd);
		File.WriteAllText(GetPath(), json);
	}

	public static bool Load(ScoreHolder scoreHolder)
	{
		if (!Directory.Exists(Application.persistentDataPath + dir)) return false;
		var x = File.ReadAllText(GetPath());
		var saves = JsonUtility.FromJson<List<ScoreSaveData>>(x);
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
