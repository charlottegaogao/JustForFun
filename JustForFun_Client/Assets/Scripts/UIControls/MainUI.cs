using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainUI: MonoBehaviour {

	// Use this for initialization
	public Button startGame;
	void Start () {
		startGame.onClick.AddListener (delegate() {
			this.BtnClick(startGame);
	});
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void BtnClick(Button sender)
	{

	}
}
