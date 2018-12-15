using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TileEventTrigger: EventTrigger
{
    string testMessage = "OnPointerEnter";
    public override void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log(testMessage);
    }

}

