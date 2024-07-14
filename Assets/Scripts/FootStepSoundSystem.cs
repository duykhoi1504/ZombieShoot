using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSoundSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource AudioSource;
    public AudioClip footstep1;
    public AudioClip footstep2;
    public AudioClip footstep3;
    public AudioClip footstep4;
    
    RaycastHit hit;
    public Transform RayStart;
    public float range;
    public LayerMask layerMask;
    public void FootStep(){
        if(Physics.Raycast(RayStart.position,RayStart.transform.up*-1,out hit,range,layerMask))
        {
            FootStepSFX(footstep3);
        }
    }
      public void FootStepSFX(AudioClip audio)
    {
        AudioSource.pitch = Random.Range(0.8f, 1f);
        AudioSource.PlayOneShot(audio);
    }
}
