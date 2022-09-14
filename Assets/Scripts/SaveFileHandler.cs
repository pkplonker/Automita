
using System.IO;
using UnityEngine;

public class SaveFileHandler 
{
	public void Save()
	{
		const string dir = "/SaveData/";
		var path = Application.persistentDataPath + dir + ".txt";
		if (!Directory.Exists(Application.persistentDataPath + dir)) Directory.CreateDirectory(dir);
		//var json = JsonUtility.ToJson();
		//File.WriteAllText(path, json);
	}
}
