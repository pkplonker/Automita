using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
///MainMenu - Main menu UI control
/// </summary>
public class MainMenu : MonoBehaviour
{
   public void NewGame()=>SceneManager.LoadScene(2);
   
   public static void Quit()
   {
#if UNITY_EDITOR
      Debug.Log("Quitting application");
      UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
   }
}
