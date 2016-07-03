using UnityEngine;
using System.Collections;

public class MainGame : MonoBehaviour {

	// Use this for initialization
    void Awake()
    {
        Global._current = this;
    }
	void Start () {
        Global.ShowLoadingUI(); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
