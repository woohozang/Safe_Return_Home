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
        // �ٴ�(Layer�� �±� üũ�� ����)�� ù �浹 ��
        if (!isLanded && collision.gameObject.CompareTag("Ground"))
        {
            isLanded = true;
            rb.isKinematic = true; // ���� ����!
        }
    }
}
