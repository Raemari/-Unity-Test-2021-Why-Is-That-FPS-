using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerToPlayCutScene : MonoBehaviour
{
    [SerializeField] PlayableDirector timeline;
    // Start is called before the first frame update
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "EndTrigger")
        {
            timeline.enabled = true;
            timeline.Play();
        }
    }
}
