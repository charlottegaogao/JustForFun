using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public delegate void NextEventHandler(object sender, EventArgs args);
public class Global {

    public static MainGame _current { get; set; }
	public static string targetPath;
	public static LoadTools loadTool;
	public static Camera uiCamera;
	public static Camera mainCamera;
    public static Transform uiRoot;
	public static Dictionary<string,AssetBundle> sceneBundles = new Dictionary<string,AssetBundle>();
    public static void ShowLoadingUI()
    {
        LoadingUI loadingUI = loadTool.LoadUI<LoadingUI>("LoadingUI",uiRoot);
		loadingUI.Next = (s,e) =>
		{
			GameObject.Destroy(loadingUI.gameObject);
			ShowMainUI();

		};

    }


    public static void ShowMainUI()
    {
        MainUI mainUI = loadTool.LoadUI<MainUI>("MainUI", uiRoot);
    }




}
