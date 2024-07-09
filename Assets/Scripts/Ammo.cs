using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    //khai bao 1 mảng chứa các băng đạn
    [SerializeField] AmmoSlot[] ammoSlot;

    //Băng đạn
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType){
        return GetAmmoSlot(ammoType).ammoAmount;
    }
    public void ReduceCurrentAmmo(AmmoType ammoType){
       GetAmmoSlot(ammoType).ammoAmount--;
    }


    //kiểm tra xem loại đạn của weapon đang trang bị có trùng với ammo của túi đạn của player
    //True: thì trả về băng đạn đó
    private AmmoSlot GetAmmoSlot(AmmoType ammoType){
        foreach(AmmoSlot slot in ammoSlot){
            if(slot.ammoType==ammoType){
                return slot;
            }
        }
        return null;
    }
    public void IncreaseAmmo(AmmoType ammoType, int amount){
        GetAmmoSlot(ammoType).ammoAmount += amount;
    }
}
