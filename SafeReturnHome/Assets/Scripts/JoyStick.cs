using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStick : MonoBehaviour
{
    public FixedJoystick joystick;
    
    public float baseSpeed = 30f; //기본 속도
    public float boost = 2f;
    public bool isBoosted = false;
    public float rotationSpeed = 10f;
    public Animator animator;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetBoostedSpeed(true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            SetBoostedSpeed(false);
        }

        float speed = isBoosted ? baseSpeed * boost : baseSpeed;
        Debug.Log($"Speed: {speed}, isBoosted: {isBoosted}");
        Vector3 direction = new Vector3(joystick.Horizontal, 0f, joystick.Vertical);
        if (animator != null)
        {
            animator.SetFloat("Speed", direction.magnitude);
        }
        
        if (direction.magnitude >= 0.1f)
        {
            // 이동
            transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

            // 회전
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
    public void SetBoostedSpeed(bool boosted)
    {
        isBoosted = boosted;
        //Debug.Log("Boosted: " + isBoosted);
    }
}
