using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float lightDecay =.1f;
    [SerializeField] float angleDecay=1f;
    [SerializeField] float miniumAngle =40f;
    bool isTurnOn=true;
    Light myLight;
    void Start()
    {
         myLight = GetComponent<Light>();
         
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
        if(Input.GetKeyDown(KeyCode.F)){
            isTurnOn=!isTurnOn;
            myLight.enabled = isTurnOn;
         }
    }

    public void RestoreLightAngle(float restoreAngle){
        myLight.spotAngle = restoreAngle;
    }
    public void AddLightIntensity(float intensityAmount)
    {
        myLight.intensity += intensityAmount;
    }
    private void DecreaseLightAngle(){
        if(myLight.spotAngle <= miniumAngle)
        {
            return;
        }
        else
        {
            myLight.spotAngle -=angleDecay * Time.deltaTime;
        }

    }
    private void DecreaseLightIntensity(){
        myLight.intensity-=lightDecay * Time.deltaTime;
    }
}
