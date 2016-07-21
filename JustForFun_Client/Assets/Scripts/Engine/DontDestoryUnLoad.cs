using UnityEngine;
using System.Collections;

public class DontDestoryUnLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
    }
}
