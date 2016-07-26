using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;
public class MainUI: UIBehaviour{

    // Use this for initialization

    public Button StartGame;
	void Start () {
		Debug.Log ("main ui start");
		Image btnImage = StartGame.gameObject.GetComponent<Image> ();
		btnImage.material.color = new Color (1f, 1f, 1f,0f);
		Tweener tweener = btnImage.material.DOFade (1f,1f);
		EventTriggerListener.Get(StartGame.gameObject).onClick = StartGameClick;
		tweener.onComplete = delegate() {
		};			
	}

	void OnEnable()
	{
		Debug.Log ("main ui enable");
	}

	void OnDisable()
	{
		Debug.Log ("main ui disable");
		//EventTriggerListener.Get (StartGame.gameObject).onClick = null;
	}
	void StartGameClick(GameObject go)
	{
        Debug.Log("startGame");
	}


}
