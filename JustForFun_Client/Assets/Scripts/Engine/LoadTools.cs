using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
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
 

    /// <summary>
    /// 对象转换为数据流存在本地
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type"></param>
    /// <param name="path"></param>
    public void SaveToLocal<T>(T type, string name)
    {
        
        string pathName = Application.persistentDataPath + "//";
        FileStream fs = new FileStream(pathName + name, FileMode.Create);
        fs = ToFileStream<T>(type, fs);
        fs.Close();
        fs.Dispose();
        Debug.Log("SaveToLocal Success!" +pathName);
    }

    /// <summary>
    /// 对象序列化为文件流
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type"></param>
    /// <param name="fs"></param>
    /// <returns></returns>
    private FileStream ToFileStream<T>(T type, FileStream fs)
    {
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, type);
        return fs;
    }

    public bool CanRead(string name)
    {
        string pathName = Application.persistentDataPath + "//";
        try
        {
            FileStream fs = new FileStream(pathName + name, FileMode.Open);
            fs.Close();
            fs.Dispose();
            return true;
        }
        catch(Exception e)
        {
            return false;
        }
        
    }

    public T ReadFromLocal<T>(T type, string name)
    {
        string pathName = Application.persistentDataPath + "//";
        FileStream fs = new FileStream(pathName + name, FileMode.Open);
        return FileStreamTo<T>(fs);

    }

    /// <summary>
    /// 文件流反序列化为对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="fs"></param>
    /// <returns></returns>
    private T FileStreamTo<T>(FileStream fs)
    {
        BinaryFormatter bf = new BinaryFormatter();
        T t = (T)bf.Deserialize(fs);
        fs.Close();
        fs.Dispose();
        return t;
    }
} 




