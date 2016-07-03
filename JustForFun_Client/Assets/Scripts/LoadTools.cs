using UnityEngine;
using System.Collections;

public class LoadTools :MonoBehaviour{
	
    public string LoadTable(string name)
    {
        string targetPath = "Tables/" + name;
        TextAsset binAsset = Resources.Load(name, typeof(TextAsset)) as TextAsset;
        string tableString = binAsset.text;
        return tableString;
    }

    public static T LoadUI<T>(string name)
    {
        string targetPath = "Prefabs/" + name;
        GameObject instance = Instantiate(Resources.Load(targetPath, typeof(GameObject))) as GameObject;
        return instance.GetComponent<T>();
    }
}
