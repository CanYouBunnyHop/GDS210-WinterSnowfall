using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 

public class JumpButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonPressed;
    public int buttonState;
    public PlayerMovement pm;

    public void OnPointerDown(PointerEventData eventData)
    {
        pm.OnClickJumpButton();
        buttonPressed = true;
        Debug.Log("ButtonDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
      
        buttonPressed = false;
        Debug.Log("ButtonUp");
    }

    public void Update()
    {
        if (buttonPressed) {buttonState = 1; }

        if (!buttonPressed) {buttonState = 2; Invoke("ResetButton", 0.01f); } 
    }

    public void ResetButton()
    {
        buttonState = 0;
    }
}
