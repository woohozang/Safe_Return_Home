using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LifePoint : MonoBehaviour
{
    
   
    //public GameObject OverSite;
    public TextMeshProUGUI Life;
    public int HP = 3;
    private int currentHP;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        //Life.text = "ü��";
        currentHP = HP;
        UpdateHP();
        if(gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void DeHP(int count)
    {
        currentHP -= count;
        if(currentHP < 0)
        {
            currentHP = 0;
        }
        UpdateHP();
        if (currentHP <= 0)
        {
            Debug.Log("���� ����");
            TrashRespawn spawner = FindObjectOfType<TrashRespawn>();
            TrashCanRespawn canspawner = FindObjectOfType<TrashCanRespawn>();
            if (spawner != null && canspawner !=null)
            {
                spawner.ClearAllTrash();
                canspawner.ClearAllTrashCan();
            }
            ShowGameOverUI();
        }
    }

    void UpdateHP()
    {
        if (HP != null)
        {
            Life.text = "HP : " + currentHP;
        }
    }
    void ShowGameOverUI()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
    }

    // �� �Լ��� ��ư Ŭ�� �̺�Ʈ�� ����˴ϴ�.
    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���� �� �ٽ� �ε�
    }
}
