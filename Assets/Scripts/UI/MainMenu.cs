using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace StuartH
{
    /// <summary>
    ///MainMenu - Main menu UI control
    /// </summary>
    public class MainMenu : CanvasGroupBase
    {
        [SerializeField] private HighscoresUI highscoresUI;
        public void NewGame() => SceneManager.LoadScene(2);

        public void Highscores()
        {
            Hide();
            highscoresUI.Show(0.2f);
        }
        public static void Quit()
        {
#if UNITY_EDITOR
            Debug.Log("Quitting application");
            UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
        }

        public void Show(float v=0f) => ShowUI(v);
        public void Hide(float v=0f) => HideUI(v);

    }
}
