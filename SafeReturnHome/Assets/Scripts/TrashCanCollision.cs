using UnityEngine;
using UnityEngine.UI;

public class TrashCanCollision : MonoBehaviour
{
    private Button cleanButton; // 버튼
    private GameObject trashCan; // 해당 TrashCan 객체
    private bool isPlayerInside = false;

    public void SetButton(Button button, GameObject trashCanObject)
    {
        cleanButton = button;
        trashCan = trashCanObject;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Player와 충돌 시 버튼 활성화
        if (collision.gameObject.CompareTag("Player"))
        {
            ShowButton();
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && !isPlayerInside)
        {
            ShowButton();
        }
    }
    void ShowButton()
    {
        cleanButton.gameObject.SetActive(true);
        cleanButton.onClick.RemoveAllListeners();
        cleanButton.onClick.AddListener(OnCleanButtonClick);
        isPlayerInside = true;
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInside = false;
            cleanButton.gameObject.SetActive(false);
            cleanButton.onClick.RemoveAllListeners(); // 리스너 제거도 꼭!
        }
    }
    void OnCleanButtonClick()
    {
        // TrashCan 제거
        Destroy(trashCan);

        // 버튼 비활성화
        cleanButton.gameObject.SetActive(false);
    }
}