using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeKinematic : MonoBehaviour
{
    private Rigidbody rb;
    private bool isLanded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // 바닥(Layer나 태그 체크도 가능)과 첫 충돌 시
        if (!isLanded && collision.gameObject.CompareTag("Ground"))
        {
            isLanded = true;
            rb.isKinematic = true; // 이제 고정!
        }
    }
}
