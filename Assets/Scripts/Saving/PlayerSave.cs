using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerSave : MonoBehaviour
{
    // Start is called before the first frame update
    public void Save(GameObject _player, string _savePath)
    {
        string saveData = JsonUtility.ToJson(_player, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, _savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }

    public void Load(GameObject _player, string _savePath)
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, _savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, _savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), _player);
            file.Close();
        }
    }
}
