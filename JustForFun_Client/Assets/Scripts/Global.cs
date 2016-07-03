using UnityEngine;
using System.Collections;

public class Global {

    public static MainGame _current { get; set; }
    public static void ShowLoadingUI()
    {
        LoadingUI loadingUI = LoadTools.LoadUI<LoadingUI>("LoadingUI");
    }

    public static void ShowMainUI()
    {

    }
}
