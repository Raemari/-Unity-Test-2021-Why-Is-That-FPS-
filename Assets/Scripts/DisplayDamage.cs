using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas damageReceivedCanvas;
    [SerializeField] float impactTime = 0.3f;

    private void Start()
    {
        damageReceivedCanvas.enabled = false;
    }
    public void ShowDamageReceivedUI()
    {
        StartCoroutine(ShowDamageReceived());
    }
    IEnumerator ShowDamageReceived()
    {
        //Do before waiting
        damageReceivedCanvas.enabled = true;
        yield return new WaitForSeconds(impactTime);
        //Do after waiting
        damageReceivedCanvas.enabled = true;
    }
}
