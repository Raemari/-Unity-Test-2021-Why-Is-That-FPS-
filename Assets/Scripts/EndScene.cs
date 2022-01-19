using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    [SerializeField] GameObject finalBoss;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            //LoadFinalScene
            SceneLoader.instance.LoadFinalScene();
        }
    }
}
