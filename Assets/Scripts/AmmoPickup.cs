using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AmmoType ammoType;
    [SerializeField] int ammoAmount;
       [SerializeField] GameObject iteamPickupVFX;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            FindObjectOfType<Ammo>().IncreaseAmmo(ammoType,ammoAmount);
            Instantiate(iteamPickupVFX, this.transform.position, Quaternion.identity);
             MusicPlayer.Instant.PLaySFX("pickup");
            // Ammo currentAmmo=other.GetComponent<Ammo>();
            // currentAmmo.IncreaseAmmo(ammoType,ammoAmount);
            this.gameObject.SetActive(false);
        }
    }
}
