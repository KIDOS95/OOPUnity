using UnityEngine;
using System.IO;

public static class JsonController
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

    public class Item
    {
        public int RecordPoints;
    }
}
