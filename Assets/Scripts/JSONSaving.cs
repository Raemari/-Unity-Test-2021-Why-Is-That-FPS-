using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONSaving : MonoBehaviour
{
    private PlayerData playerData;

    private string path= "";
    private string persistentPath = "";
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayerData();
        SetPaths();
    }
    //helper class for cleaner code
    private void CreatePlayerData()
    {
        playerData = new PlayerData(200, 5, 20, 1, 2, 1);
    }
    private void SetPaths()
    {
        //will point to asset directory in unity
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        //the path you shoud use once you actually ship the game
        persistentPath = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        SaveData();

        if(Input.GetKeyDown(KeyCode.L))
        LoadData();
    }
    public void SaveData()
    {
        string savePath = persistentPath;
        Debug.Log("Saving data at " + savePath);
        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }
    public void LoadData()
    {
        using StreamReader reader = new StreamReader(persistentPath);
        string json = reader.ReadToEnd();

        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log(data.ToString());
    }
}
