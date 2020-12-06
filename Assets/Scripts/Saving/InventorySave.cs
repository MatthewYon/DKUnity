using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class InventorySave : MonoBehaviour
{

    public InventoryObject _inv;
    [SerializeField] private string _savePath;
    
}
