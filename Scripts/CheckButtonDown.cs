using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckButtonDown : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    public static bool isButtonPushing;
    public void OnPointerDown(PointerEventData eventData){
        isButtonPushing = true;
    }
    public void OnPointerUp(PointerEventData eventData){
        isButtonPushing = false;
    }
}
