using System;
using UnityEngine;
using System.Collections;

public class LoadTools :MonoBehaviour{

	void Start()
	{
		DontDestroyOnLoad (this.gameObject);
	}
    public string LoadTable(string name)
    {
        string targetPath = "Tables/" + name;
		TextAsset binAsset = Resources.Load(targetPath, typeof(TextAsset)) as TextAsset;
        string tableString = binAsset.text;
        return tableString;
    }

    public T LoadUI<T>(string name, Transform parent)
    {
        string targetPath = "Prefabs/" + name;
	
        GameObject instance = Instantiate(Resources.Load(targetPath, typeof(GameObject))) as GameObject;
		if (parent != null)
			instance.transform.parent = parent;
		instance.transform.localScale = Vector3.one;

		return instance.GetComponent<T>();
	}
	
	
	public IEnumerator LoadScene(string name, NextEventHandler Next, string preBundle)
	{
		AssetBundle scenebundle;
		if (!Global.sceneBundles.TryGetValue (name, out scenebundle)) {
			string targetPath =
		    #if UNITY_ANDROID
				"jar:file://" + Application.dataPath + "!/assets/";
			#elif UNITY_IOS
			Application.dataPath +"/Raw";
			#else
			"file://" + Application.dataPath + "/StreamingAssets/";
			#endif
			targetPath = targetPath + "/scene/" + name;
			using (WWW www = new WWW(targetPath)) {
				yield return www;
				if (www.error != null)
				{
					yield break;
				}
				Global.sceneBundles[name] = www.assetBundle;
			}

		} 
		AsyncOperation asyncOperation = Application.LoadLevelAsync(name);
		yield return asyncOperation;

		if (preBundle != null && Global.sceneBundles.TryGetValue (preBundle, out scenebundle)) {
			scenebundle.Unload(true);
		}
		if(Next != null)
			Next(this, new EventArgs (){});

	}
}
