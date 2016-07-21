using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class MainUI: MonoBehaviour {

    // Use this for initialization
    public Button StartGame;
	void Start () {
        EventTriggerListener.Get(StartGame.gameObject).onClick = StartGameClick;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void StartGameClick(GameObject go)
	{
        Debug.Log("startGame");
	}
}
