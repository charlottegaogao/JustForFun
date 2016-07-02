using UnityEngine;
using System.Collections;

public class LoadTools {
	
    public string LoadTable(string name)
    {
        TextAsset binAsset = Resources.Load(name, typeof(TextAsset)) as TextAsset;
        string tableString = binAsset.text;
        return tableString;
    }
}
