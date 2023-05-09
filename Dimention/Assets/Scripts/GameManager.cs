using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public SaveData saveData;

    public bool[] upgradesGotten = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

    string saveFile;

    public float currentTime = 0;

    FileStream dataStream;

    BinaryFormatter converter = new BinaryFormatter();

    

    public static GameObject thisObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WriteFile();
        }
    }

    public void Loader()
    {
        ReadFile();
    }

    private void Awake()
    {
        saveFile = Application.persistentDataPath + "/gamedata.data";
        saveData = new SaveData();
        DontDestroyOnLoad(gameObject);
        thisObject = gameObject;
    }

    public void WriteFile()
    {
        dataStream = new FileStream(saveFile, FileMode.Create);
        converter.Serialize(dataStream, saveData);
        dataStream.Close();
    }

    public void ReadFile()
    {
        if (File.Exists(saveFile))
        {
            dataStream = new FileStream(saveFile, FileMode.Open);
            saveData = (SaveData)converter.Deserialize(dataStream);
            dataStream.Close();
        }
    }

}
[System.Serializable]

public class SaveData
{
    public int prestigePoints = 0;
    public int swordLevel = 1;
    public int gunLevel = 1;
    public int movementLevel = 1;
    public bool hasPlayedOnce = false;
    public float bestTime = 0;
}
