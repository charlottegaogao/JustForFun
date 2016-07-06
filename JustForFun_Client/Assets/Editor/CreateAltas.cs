using UnityEngine;
using System.Collections;
using UnityEditor;
public class CreateAltas : MonoBehaviour {


	[MenuItem ("Assets/AtlasMaker")]
	public static void AltalsMaker()
	{
	/*	string spriteDir = Application.dataPath +"/Resources/Sprite";
		
		if(!Directory.Exists(spriteDir)){
			Directory.CreateDirectory(spriteDir);
		}
		
		DirectoryInfo rootDirInfo = new DirectoryInfo (Application.dataPath +"/Atlas");
		foreach (DirectoryInfo dirInfo in rootDirInfo.GetDirectories()) {
			foreach (FileInfo pngFile in dirInfo.GetFiles("*.png",SearchOption.AllDirectories)) {
				string allPath = pngFile.FullName;
				string assetPath = allPath.Substring(allPath.IndexOf("Assets"));
				Sprite sprite = Resources.LoadAssetAtPath<Sprite>(assetPath);
				GameObject go = new GameObject(sprite.name);
				go.AddComponent<SpriteRenderer>().sprite = sprite;
				allPath = spriteDir+"/"+sprite.name+".prefab";
				string prefabPath = allPath.Substring(allPath.IndexOf("Assets"));
				PrefabUtility.CreatePrefab(prefabPath,go);
				GameObject.DestroyImmediate(go);
			}
		}	*/
	}


}
