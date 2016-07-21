using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {


	// Use this for initialization
	public Camera UICamera;
	public Camera mainCamera;
    public Transform UIRoot;
    void Awake()
    {
        Global._current = this;
    }
	void Start () {
		DontDestroyOnLoad(this.gameObject);
		Global.loadTool = this.gameObject.GetComponent<LoadTools>();
		Global.mainCamera = mainCamera;
		Global.uiCamera = UICamera;
        Global.uiRoot = UIRoot;
		Global.ShowLoadingUI(); 

	}
	
	// Update is called once per frame
	void Update () {

	}

}
