using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpeedUpBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public JoyStick speedbtn;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer Down");
        speedbtn.SetBoostedSpeed(true);
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Pointer Up");
        speedbtn.SetBoostedSpeed(false);
    }
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speedbtn.SetBoostedSpeed(true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speedbtn.SetBoostedSpeed(false);
        }
    }*/
}
