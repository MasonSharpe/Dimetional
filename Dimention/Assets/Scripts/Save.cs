using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Save : MonoBehaviour
{
    SaveData saveData;
    GameManager data;

    string saveFile;

    FileStream dataStream;
    CharacterController cc;

    BinaryFormatter converter = new BinaryFormatter();

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            saveData.prestigePoints = data.prestigePoints;
            saveData.swordLevel = data.swordLevel;
            saveData.gunLevel = data.gunLevel;
            saveData.movementLevel = data.movementLevel;
            WriteFile();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ReadFile();
            cc.enabled = false;
            //transform.position = new Vector3(saveData.x, saveData.y, saveData.z);
            cc.enabled = true;
        }
    }

    private void Awake()
    {
        saveFile = Application.persistentDataPath + "/gamedata.data";
        saveData = new SaveData();
        cc = GetComponent<CharacterController>();
        data = gameObject.GetComponent<GameManager>();
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
