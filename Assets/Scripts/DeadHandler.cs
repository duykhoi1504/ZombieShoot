using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas gameOverCanvas;
    void Start()
    {
     gameOverCanvas.enabled=false;    
    }

   public void HandleDeath(){
     gameOverCanvas.enabled=true;
     Time.timeScale=0;
     FindObjectOfType<SweaponSwitcher>().enabled=false;
     Cursor.lockState=CursorLockMode.None;    
     Cursor.visible=true;

   }
}
