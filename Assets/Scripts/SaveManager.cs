using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

public class SaveManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class SaveData
{
    public string saveName;
    public Vector3 respawnPosition;
    public int lives;
    public int ammoAmmount;
    public int enemyAlive;
}
