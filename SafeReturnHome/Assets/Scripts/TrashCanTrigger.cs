using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashCanTrigger : MonoBehaviour
{ 
    public Button clean;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            clean.gameObject.SetActive(true); // 버튼 보이게 하기
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        clean.gameObject.SetActive(false);
        clean.onClick.AddListener(DestroyTrash);
    }

    void DestroyTrash()
    {
        Destroy(gameObject);
        clean.gameObject.SetActive(false);
    }
}
