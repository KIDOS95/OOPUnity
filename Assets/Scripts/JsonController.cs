using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonController : MonoBehaviour
{
    public static Item item;

    [ContextMenu("Load")]
    public static void LoadField()
    {
        item = JsonUtility.FromJson<Item>(File.ReadAllText
            (Application.streamingAssetsPath + "/GameSave.json"));
    }

    [ContextMenu("Save")]
    public static void SaveField()
    {
        File.WriteAllText(Application.streamingAssetsPath + 
            "/GameSave.json", JsonUtility.ToJson(item));
    }

    [System.Serializable]
    public class Item
    {
        public int RecordPoints;
    }

}
