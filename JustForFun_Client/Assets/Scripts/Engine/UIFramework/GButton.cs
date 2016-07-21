using UnityEngine;
using System.Collections;
using UnityEngine.UI;


[ExecuteInEditMode]
[AddComponentMenu("UI/GButton")]
public class GButton : Button{

    public Text text;
    bool pressed;
    public EventTriggerListener.VoidDelegate onPress = null;
    
    Button button;
    protected override void Awake()
    {
        base.Awake();
        EventTriggerListener.Get(this.gameObject).onClick = Btn_Click;
        EventTriggerListener.Get(this.gameObject).onPress = Btn_Press;
    }

    void Btn_Click(GameObject go)
    {
    }

    void Btn_Press(GameObject go)
    {
        if(null != onPress)
        {
            try
            {
                pressed = true;
                onPress(go);
            }
            catch(System.Exception ex)
            {
                Debug.Log(ex.Message);
            }

        }
    }


}
