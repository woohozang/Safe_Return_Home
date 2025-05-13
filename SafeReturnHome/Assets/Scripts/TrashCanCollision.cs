using UnityEngine;
using UnityEngine.UI;

public class TrashCanCollision : MonoBehaviour
{
    private Button cleanButton; // ��ư
    private GameObject trashCan; // �ش� TrashCan ��ü
    private bool isPlayerInside = false;

    public void SetButton(Button button, GameObject trashCanObject)
    {
        cleanButton = button;
        trashCan = trashCanObject;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Player�� �浹 �� ��ư Ȱ��ȭ
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
            cleanButton.onClick.RemoveAllListeners(); // ������ ���ŵ� ��!
        }
    }
    void OnCleanButtonClick()
    {
        // TrashCan ����
        Destroy(trashCan);

        // ��ư ��Ȱ��ȭ
        cleanButton.gameObject.SetActive(false);
    }
}