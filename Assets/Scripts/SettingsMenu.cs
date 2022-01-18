using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class SettingsMenu : MonoBehaviour
{
    private Transform panel;
    private Event keyEvent;
    private TextMeshProUGUI buttonText;
    public TextMeshProUGUI rightText;
    public TextMeshProUGUI leftText;
    public TextMeshProUGUI forwardText;
    public TextMeshProUGUI backwardText;
    public TextMeshProUGUI jumpText;

    private KeyCode newKey;
    private bool waitingForKey;

    [SerializeField] AudioMixer audioMixer;
    [SerializeField] string  volumeParameter = "Volume";
    [SerializeField] Slider slider;
    [SerializeField] float multiplier = 30f;
    [SerializeField] Toggle toggle;
    private float lastValue;
    [SerializeField] TMP_Dropdown resolutionDropdown;
    [SerializeField] TMP_Dropdown qualityDropdown;
    [SerializeField] RenderPipelineAsset[] qualityLevels;
    private Resolution[] resolutions;
    private bool disableToggleEvent;

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
        toggle.onValueChanged.AddListener(HandleToggleValueChanged);
    }

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat(volumeParameter, slider.value);
        //needed for the case when default and playerperf values are same and 
        //thus no volume change has actually happened and then mixer value won't
        //be set since the handle is called only on value changed...
        HandleSliderValueChanged(slider.value);

        ResolutionDropDown();

        int Quality = PlayerPrefs.GetInt("qualityIndex", 0);
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        //ADDED, DOUBLE CHECK IF WORKING
        qualityDropdown.value =Quality;

        panel = transform.Find("Panel");
        waitingForKey = false;

        //iteration to find the children inside parent
        for(int i = 0; i < panel.childCount; i++)
        {
            if(panel.GetChild(i).name == "RightKey")
                panel.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.right.ToString();
            else if(panel.GetChild(i).name == "LeftKey")
                panel.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.left.ToString();
            else if(panel.GetChild(i).name == "ForwardKey")
                panel.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.forward.ToString();
            else if(panel.GetChild(i).name == "BackwardKey")
                panel.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.backward.ToString();
            else if(panel.GetChild(i).name == "JumpKey")
                panel.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = GameManager.GM.jump.ToString();
        }
    }
    private void Update()
    {
        //checking if there's an exisitng playerprefs set for the keys
        if(PlayerPrefs.HasKey("RightKey"))
            rightText.text = PlayerPrefs.GetString("rightKey");
        if(PlayerPrefs.HasKey("LeftKey"))
            leftText.text = PlayerPrefs.GetString("leftKey");
        if(PlayerPrefs.HasKey("ForwardKey"))
            forwardText.text = PlayerPrefs.GetString("forwardKey");
        if(PlayerPrefs.HasKey("BackwardKey"))
            backwardText.text = PlayerPrefs.GetString("backwardKey");
        if(PlayerPrefs.HasKey("JumpKey"))
            jumpText.text = PlayerPrefs.GetString("jumpKey");
    }
    private void OnGUI()
    {
        //assigning the keys if we're only waitingforkey
        keyEvent = Event.current;
        if(keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }
    public void StartAssignment(string keyName)
    {
        if(!waitingForKey)
        {
            StartCoroutine(AssignKey(keyName));
        }
    }
    public void SendText(TextMeshProUGUI text)
    {
        //updates the text on the button that was clicked
        buttonText = text;
    }
    IEnumerator WaitForKey()
    {
        while(!keyEvent.isKey)
        yield return null;
        Debug.Log("wait for key");
    }
    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;
        yield return WaitForKey();

        switch (keyName)
        {
            case "right":
            {
                GameManager.GM.right = newKey;
                buttonText.text = GameManager.GM.right.ToString();
                PlayerPrefs.SetString("rightKey", GameManager.GM.right.ToString());
                break;
            }
            case "left":
            {
                GameManager.GM.left = newKey;
                buttonText.text = GameManager.GM.left.ToString();
                PlayerPrefs.SetString("leftKey", GameManager.GM.left.ToString());
                break;
            }
            case "forward":
            {
                GameManager.GM.forward = newKey;
                buttonText.text = GameManager.GM.forward.ToString();
                PlayerPrefs.SetString("forwardKey", GameManager.GM.forward.ToString());
                break;
            }
            case "backward":
            {
                GameManager.GM.backward = newKey;
                buttonText.text = GameManager.GM.backward.ToString();
                PlayerPrefs.SetString("backwardKey", GameManager.GM.backward.ToString());
                break;
            }
            case "jump":
            {
                GameManager.GM.jump = newKey;
                buttonText.text = GameManager.GM.jump.ToString();
                PlayerPrefs.SetString("jumpKey", GameManager.GM.jump.ToString());
                break;
            }
        }
        yield return null;
    }
    public void ResolutionDropDown()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i= 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + "@" + resolutions[i].refreshRate + "hz";
            options.Add(option);
            //if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            //code above is wrong because the screen reso 
            //gets the desktop reso not the game's current reso
            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        QualitySettings.renderPipeline = qualityLevels[qualityIndex];
        PlayerPrefs.SetInt("qualityIndex", qualityIndex);
    }
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    private void HandleSliderValueChanged(float value)
    {
        audioMixer.SetFloat(volumeParameter, Mathf.Log10(value) * multiplier);
        // disableToggleEvent = true;
        toggle.isOn = slider.value > slider.minValue;
        // disableToggleEvent = false;
    }
   private void HandleToggleValueChanged(bool enableSound)
    {
        if (enableSound)
        {
            slider.value = lastValue > slider.minValue ? lastValue : slider.minValue + 0.0001f;
        }
        else
        {
            lastValue = slider.value;
            slider.value = slider.minValue;
        }
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParameter, slider.value);
    }
}
