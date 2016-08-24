using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using GFramework.UIControl;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
public delegate void NextEventHandler(object sender, EventArgs args);
public class Global {

    public static MainGame _current { get; set; }
	public static string targetPath;
	public static LoadTools loadTool;
	public static Camera uiCamera;
	public static Camera mainCamera;
    public static Transform uiRoot;
	public static Dictionary<string,AssetBundle> sceneBundles = new Dictionary<string,AssetBundle>();
    public static RoleData RoleData
    { get { return _roleData; } }

    private static RoleData _roleData;
    const string ROLE_DATA_FILE = "roleData.Rec";
    public static void ShowLoadingUI()
    {
        LoadingUI loadingUI = loadTool.LoadUI<LoadingUI>("LoadingUI",uiRoot);
		loadingUI.Next = (s,e) =>
		{
            UnityEngine.Object.Destroy(loadingUI.gameObject);
			ShowMainUI();

		};

    }

    public static void ShowMainUI()
    {
        MainUI mainUI = loadTool.LoadUI<MainUI>("MainUI", uiRoot);
		mainUI.Next = (s, e) => {
			UnityEngine.Object.Destroy(mainUI.gameObject);
			ShowGameUI();
		};
    }

	public static void ShowGameUI()
	{
		Debug.Log ("show game ui");
	}

    public static void LoadRoleData()
    {
        if(loadTool.CanRead(ROLE_DATA_FILE))
        {
            _roleData = loadTool.ReadFromLocal(RoleData, ROLE_DATA_FILE);
        }
        if(_roleData == null)
        {
            _roleData = new RoleData(0, 0, 0);
            loadTool.SaveToLocal(_roleData, ROLE_DATA_FILE);
        }
    }

    public static void ClearRoleData()
    {
        _roleData = null;
        _roleData = new RoleData(0, 0, 0);
        loadTool.SaveToLocal(_roleData, ROLE_DATA_FILE);
    }

    public static void AddLoginTimes()
    {
        _roleData.LoginTimes += 1;
        loadTool.SaveToLocal(_roleData, ROLE_DATA_FILE);
    }





   
}
