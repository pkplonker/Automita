using UnityEngine;


namespace StuartH
{
    /// <summary>
    ///PauseMenu - Pause menu UI control
    /// </summary>
    public class PauseMenu : CanvasGroupBase
    {
        private bool isActive;

        private void Awake() => SetInactive(0);


        public void PauseToggle(float fade = 0f)
        {
            if (isActive) SetInactive(fade);
            else SetActive(fade);
        }

        private void SetActive(float fade)
        {
            isActive = true;
            ShowUI(fade);
            Time.timeScale = 0f;
        }

        private void SetInactive(float fade)
        {
            isActive = false;
            HideUI(fade);
            Time.timeScale = 1f;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) PauseToggle();
        }

        public void Quit() => MainMenu.Quit();


    }
}
