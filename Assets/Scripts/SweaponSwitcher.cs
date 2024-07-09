using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweaponSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int currentWeapon;

    void Start()
    {
        SetWeaponAvtive();
    }

    // Update is called once per frame
    void Update()
    {
       int previousWeapon=currentWeapon;
        ProcessKeyInput();
        ProcessMouseScrollWheel();
       
        if(previousWeapon!=currentWeapon){
            SetWeaponAvtive();
        }
    }

    void ProcessKeyInput(){
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon=0;
        }else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon=1;
        }else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon=2;

        }
    }
    void ProcessMouseScrollWheel(){
        if(Input.GetAxis("Mouse ScrollWheel")>0)
        {
                if(currentWeapon>=transform.childCount-1)
                {
                    currentWeapon=0;
                }else{
                    currentWeapon++;
                }
        }
        if(Input.GetAxis("Mouse ScrollWheel")<0)
        {
                if(currentWeapon<=0)
                {
                    currentWeapon=transform.childCount-1;
                }else{
                    currentWeapon--;
                }
        }
    }
    void SetWeaponAvtive(){
        int weaponIndex=0;
        foreach(Transform weapon in transform){
            if(weaponIndex==currentWeapon){
                weapon.gameObject.SetActive(true);
            }else{
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
            
        }
    }
}
