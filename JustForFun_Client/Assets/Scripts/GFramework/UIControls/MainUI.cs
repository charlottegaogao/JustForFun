using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using DG.Tweening;
namespace GFramework.UIControl
{
    public class MainUI : UIBehaviour
    {

        // Use this for initialization

        public Button StartGame;
        public Button Continue;
        protected override void Start()
        {
            Debug.Log("main ui start");

            //---------------event--------------------------------
            EventTriggerListener.Get(StartGame.gameObject).onClick = StartGameClick;
            EventTriggerListener.Get(Continue.gameObject).onClick = ContinueGame;

            //--------------visible------------------------------
            Continue.gameObject.SetActive(Global.RoleData.LoginTimes >= 1);
            
            //test code for tweener
            //      Image btnImage = StartGame.gameObject.GetComponent<Image> ();
            //btnImage.material.color = new Color (1f, 1f, 1f,0f);
            //Tweener tweener = btnImage.material.DOFade (1f,1f);
            //tweener.onComplete = delegate() {

            //      };
        }

        protected override void OnEnable()
        {
            Debug.Log("main ui enable");
        }

        protected override void OnDisable()
        {
            Debug.Log("main ui disable");
            //EventTriggerListener.Get (StartGame.gameObject).onClick = null;
        }
        void StartGameClick(GameObject go)
        {
            Global.ClearRoleData();
            Global.AddLoginTimes();
        }

        void ContinueGame(GameObject go)
        {
            Global.AddLoginTimes();
        }
    }
}
