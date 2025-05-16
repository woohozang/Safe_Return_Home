using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{
    public FixedJoystick joystick;
    
    public float baseSpeed = 30f; //기본 속도
    public float boost = 2f;
    public bool isBoosted = false;
    

    

    // Update is called once per frame
    void Update()
    {
        float speed = isBoosted ? baseSpeed * boost : baseSpeed;
        Debug.Log($"Speed: {speed}, isBoosted: {isBoosted}");

        Vector3 direction = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);
        transform.Translate(direction * speed * Time.deltaTime);
    }
    public void SetBoostedSpeed(bool boosted)
    {
        isBoosted = boosted;
        //Debug.Log("Boosted: " + isBoosted);
    }
}
