using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public SaveData saveData;

    string saveFile;

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
    public int prestigePoints;
    public int swordLevel;
    public int gunLevel;
    public int movementLevel;
}
