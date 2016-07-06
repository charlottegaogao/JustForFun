using UnityEngine;
using System;
using System.Collections;

public class LoadingUI : MonoBehaviour {

	public NextEventHandler Next;
	// Use this for initialization

	void Start () {
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
