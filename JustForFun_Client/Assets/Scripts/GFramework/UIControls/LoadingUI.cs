using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;
namespace GFramework.UIControl
{ 
    public class LoadingUI : UIBehaviour {

	    public NextEventHandler Next;
        public Text loadingText;
        // Use this for initialization
        protected override void Start () {
            if(this.gameObject != null)
		        DontDestroyOnLoad (this.gameObject);
            InitMainScene ();
        }

	    private void InitMainScene()
	    {
		    StartCoroutine (Global.loadTool.LoadScene ("main", Next,null));
	    }

  
    }
}
