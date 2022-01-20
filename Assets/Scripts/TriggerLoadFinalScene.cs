using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLoadFinalScene : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("FinalScene", LoadSceneMode.Single);
        Cursor.visible = true;
    }
}
