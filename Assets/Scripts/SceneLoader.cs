using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void Retry(){
        SceneManager.LoadScene(0);
        Time.timeScale=1;
    }
    public void Quit(){
        Application.Quit();
    }
}
