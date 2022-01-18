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

    private AudioSource audioSource;
    [SerializeField] AudioClip bgSound;
    [SerializeField] AudioClip doorOpenSound;
    [SerializeField] AudioClip doorLockedSound;
    [SerializeField] AudioClip doorUnlockedSound;
    [SerializeField] AudioClip shootSound;
    [SerializeField] AudioClip hurtSound;
    [SerializeField] AudioClip reloadSound;


    private void Awake()
    {
        if(GM ==null)
        {
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
    private void Start() => audioSource = GetComponent<AudioSource>();

    public void PlayBG()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(bgSound);
    }
    public void PlayDoorOpen()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(doorOpenSound);
    }
    public void PlayDoorLocked()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(doorLockedSound);
    }
    public void PlayDoorUnlocked()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(doorUnlockedSound);
    }
    public void PlayShoot()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(shootSound);
    }
    public void PlayHurt()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(hurtSound);
    }
    public void PlayReload()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(reloadSound);
    }
}
