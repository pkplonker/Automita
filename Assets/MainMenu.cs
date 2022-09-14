using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int mainMenuIndex = 1;
       [SerializeField] private int gameIndex = 2;

   public void TryAgain  () {

       SceneManager.LoadScene(gameIndex);
   }
   
   public void Menu  () {

       SceneManager.LoadScene(mainMenuIndex);
   }
    
}
