using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void SceneNext()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void ScenePrevious()
    {
        SceneManager.LoadScene("FirstScene");
    }
    // Update is called once per frame
    
}
