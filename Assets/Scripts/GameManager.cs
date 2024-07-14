using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform enemys;

    private void Awake() {
        Time.timeScale=1;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform a in enemys){
            if(a.gameObject.activeSelf )break;
            else{
                GetComponent<WinHandle>().HandleWin();
            }
        }
    }
}
