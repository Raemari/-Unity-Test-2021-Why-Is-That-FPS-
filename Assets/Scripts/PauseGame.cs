using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] GameObject settingsCanvas;
    public Weapon weapon;
    private bool isGamePaused;
    private void Start()
    {
        settingsCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
    }
    private void Update()
    {
        weapon = FindObjectOfType<Weapon>();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isGamePaused = !isGamePaused;
            GamePaused();
        }
    }
    public void GamePaused()
    {
        //data should be saved every time pause game is clicked
        if(isGamePaused)
        {
            Cursor.visible = true;
            weapon.allowedToShoot = false;
            pauseCanvas.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            FindObjectOfType<WeaponSwitcher>().enabled = false;
        }
        else
        {
            ResumeGameFromPause();
        }
    }
    public void ResumeGameFromPause()
    {
        Cursor.visible = false;
        isGamePaused = false;
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        FindObjectOfType<WeaponSwitcher>().enabled = true;
        weapon.allowedToShoot = true;
    }
    public void SettingCanvas()
    {
        settingsCanvas.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
    }
    public void BackFromSettings()
    {
        Time.timeScale = 1;
        settingsCanvas.SetActive(false);
        FindObjectOfType<WeaponSwitcher>().enabled = true;
    }
}
