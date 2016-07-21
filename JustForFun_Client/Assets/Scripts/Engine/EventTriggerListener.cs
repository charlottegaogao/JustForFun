using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class EventTriggerListener: UnityEngine.EventSystems.EventTrigger {

    public delegate void VoidDelegate(GameObject go);
    public VoidDelegate onClick;
    public VoidDelegate onPress;

    public delegate bool BOOLDelegate(GameObject go, bool state);
    

    static public EventTriggerListener Get(GameObject go)
    {
        EventTriggerListener eventListener = go.GetComponent<EventTriggerListener>();
        if (eventListener == null) eventListener = go.AddComponent<EventTriggerListener>();

        return eventListener; 
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (onClick != null) onClick(gameObject);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (onPress != null) onPress(gameObject);
    }

}