using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LifePoint hp = other.gameObject.GetComponent<LifePoint>(); //LifePoint.cs ����
            if(hp != null)
            {
                hp.DeHP(1); //LifePoint�� DeHP�Լ� �ȿ� count�� 1�� �ʱ�ȭ�Ͽ� �浹��, 1�� ����
            }
            Debug.Log("Player collided with trash. Destroying trash.");
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
