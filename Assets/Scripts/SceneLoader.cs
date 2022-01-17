using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    // [SerializeField] GameObject pauseCanvas;
    // private bool isGamePaused;
    // //TODO LIPAT YUNG GAME PAUSE SA PLAYERMANAGER
    // private void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         isGamePaused = !isGamePaused;
    //         PauseGame();
    //     }
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
    public void StartGame()
    {
        //saved progress will get lost, proceed to new game?
    }
    public void ResumeGame()
    {
        //check if there's current data if no save data, cant resume game
    }
    public void ShowSettingsMenu()
    {
        //create a new scene for options change
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void ResetData()
    {
        //reset all saved data and settings
    }
    // public void PauseGame()
    // {
    //     //data should be saved every time pause game is clicked
    //     if(isGamePaused)
    //     {
    //         pauseCanvas.SetActive(true);
    //         Time.timeScale = 0;
    //         Cursor.lockState = CursorLockMode.None;
    //         FindObjectOfType<WeaponSwitcher>().enabled = false;
    //     }
    //     else
    //     {
    //         ResumeGameFromPause();
    //     }
    // }
    // public void ResumeGameFromPause()
    // {
    //     Time.timeScale = 1;
    //     pauseCanvas.SetActive(false);
    //     FindObjectOfType<WeaponSwitcher>().enabled = true;
    // }
}
