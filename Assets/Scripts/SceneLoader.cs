using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    // private void OnTriggerEnter(Collider other)
    // {
    //     LoadFinalScene();
    //     Debug.Log("triggerfinalscene");
    //     Cursor.visible = true;
    // }
    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void LoadIntroScene()
    {
        //loads Intro Scene
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadFloor1NewGame()
    {
        //loads Floor1 scene
        Time.timeScale = 1;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Cursor.visible = true;
        Time.timeScale = 1;
    }
    // public void LoadFinalScene()
    // {
    //     //load final scene, should be cut scene for ending
    //     SceneManager.LoadScene(3);
    // }
}
