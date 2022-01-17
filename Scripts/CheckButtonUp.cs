using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckButtonUp : MonoBehaviour,IPointerUpHandler
{
    public void OnPointerUp(PointerEventData eventData){
        GameManager.dropButtonPushed=true;
    }
}
