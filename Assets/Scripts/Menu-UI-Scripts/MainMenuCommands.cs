using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuCommands : MonoBehaviour
{

    [SerializeField] private GameObject thisMenu;

public void StartGame(string sceneName)
{
    SceneManager.LoadScene(sceneName);
}

public void QuitGame()
{
    Application.Quit();
}

public void ChangeMenu(GameObject menu)
{
    menu.SetActive(true);
    thisMenu.SetActive(false);

}


}