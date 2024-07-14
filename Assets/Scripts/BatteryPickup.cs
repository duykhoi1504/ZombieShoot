using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float restoreAngle=90f;
    [SerializeField] float addIntensity=1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")){
            other.GetComponentInChildren<FlashLightSystem>().RestoreLightAngle(restoreAngle);
            other.GetComponentInChildren<FlashLightSystem>().AddLightIntensity(addIntensity);
             MusicPlayer.Instant.PLaySFX("pickup");
            Destroy(gameObject);
        }
    }
  
}
