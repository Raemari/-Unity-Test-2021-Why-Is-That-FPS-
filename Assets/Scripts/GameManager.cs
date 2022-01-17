using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;
    public KeyCode left {get; set;}
    public KeyCode right {get; set;}
    public KeyCode forward {get; set;}
    public KeyCode backward {get; set;}
    public KeyCode jump {get; set;}

    private void Awake()
    {
        if(GM ==null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
        }
        else if(GM != this)
        {
            Destroy(gameObject);
        }
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKey", "W"));
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardKey", "S"));
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
    }
}
