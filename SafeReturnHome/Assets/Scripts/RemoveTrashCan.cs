using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RemoveTrashCan : MonoBehaviour
{
    public TextMeshProUGUI removeText;
    public int startingCount = 0; //시작 카운트
    private int currentCount; //제거했을 때 증가된 현재 카운트

    private TrashCanCollision trashCanCollision; //TrashCanCollision 참조

    void Start()
    {
        currentCount = startingCount;
        trashCanCollision = FindObjectOfType<TrashCanCollision>();
        UpdateRemoveText();
    }

    void UpdateRemoveText() //쓰레기통 하나 제거할 때 텍스트 업데이트
    {
        if (removeText != null) 
        {
            removeText.text = "Score : " + currentCount;
        }
    }

    public void AddRemoveTrash(int count)
    {
        if (trashCanCollision != null) //비어있지 않으면
            trashCanCollision.OnCleanButtonClick(); //실행

        currentCount += count; //버튼 클릭 후 카운트 증가
        UpdateRemoveText(); //증가된 카운트 업데이트 적용

        if (currentCount >= 5)
        {
            Debug.Log("Complete Stage"); //5개 제거완료하면 스테이지 클리어, 집 활성화
            // 추가 처리 가능: 씬 전환, 애니메이션 등
        }
    }
}
