using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 
    //loads scene if clicked
    public void LoadScene()
    {
        SceneManager.LoadScene("CharacterSelect");
        Debug.Log("click");
    }
    //closes game if clicked
    public void QuitGame()
    {
        Application.Quit();
    }
}
