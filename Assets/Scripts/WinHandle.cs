using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinHandle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]  Canvas winCanvas;
    [SerializeField] EnemyAI[] enemys;
  
    void Start()
    {
       
        winCanvas.enabled=false;   
       
      
    }
    // void Update(){
    //     foreach(EnemyAI enemy in enemys){
    //         if(enemy!=null)return;
    //         else{
    //             HandleWin();
    //         }
    //     }
    // }
   public void HandleWin(){
     winCanvas.enabled=true;
     Time.timeScale=0;
     FindObjectOfType<SweaponSwitcher>().enabled=false;
     Cursor.lockState=CursorLockMode.None;    
     Cursor.visible=true;

   }
}
