using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class LoadingUI : MonoBehaviour {

	public NextEventHandler Next;
    public Button button;
	// Use this for initialization

	void Start () {
        if(this.gameObject != null)
		    DontDestroyOnLoad (this.gameObject);
        InitMainScene ();
    }
	// Update is called once per frame
	void Update () {
	
	}

	private void InitMainScene()
	{
		StartCoroutine (Global.loadTool.LoadScene ("main", Next,null));
	}

  
}
