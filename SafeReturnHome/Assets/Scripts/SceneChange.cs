using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Button StartBtn;
    //public Button ResetBtn;
    // Start is called before the first frame update
    public void SceneNext()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (StartBtn != null)
        {
            StartBtn.onClick.AddListener(SceneNext);
        }
    }
}
