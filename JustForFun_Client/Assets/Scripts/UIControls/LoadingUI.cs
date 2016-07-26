using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class LoadingUI : UIBehaviour {

	public NextEventHandler Next;
	// Use this for initialization
	void Start () {
        if(this.gameObject != null)
		    DontDestroyOnLoad (this.gameObject);
        InitMainScene ();
    }

	private void InitMainScene()
	{
		StartCoroutine (Global.loadTool.LoadScene ("main", Next,null));
	}

  
}
