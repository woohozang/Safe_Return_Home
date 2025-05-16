using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTrigger : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LifePoint hp = other.gameObject.GetComponent<LifePoint>(); //LifePoint.cs 참조
            if(hp != null)
            {
                hp.DeHP(1); //LifePoint의 DeHP함수 안에 count에 1을 초기화하여 충돌시, 1씩 감소
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
