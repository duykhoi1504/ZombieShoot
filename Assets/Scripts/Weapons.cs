using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera FPCamera;
    [SerializeField] float range=100f;
    [SerializeField] float damage=20f;
    [SerializeField] ParticleSystem muzzleFlash;
     [SerializeField] GameObject hitEffect;
    [SerializeField] AmmoType ammoType;
      [SerializeField] Ammo ammoSlot;

      bool canShoot=true;
      [SerializeField] float timeBetweenShots=0.5f;

    void OnEnable() {
        canShoot=true;
    }
    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, FPCamera.transform.forward*10, Color.green);
        if(Input.GetButtonDown("Fire1") && canShoot==true)
        {
             GetComponent<Animator>().SetTrigger("shoot");
            StartCoroutine(Shoot());
        }
        
    }
    IEnumerator Shoot()
    {
        canShoot=false;
        if(ammoSlot.GetCurrentAmmo(ammoType)>0)
        {
            PlayMuzzleFlash(); 
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);   
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot=true;
    }
     void PlayMuzzleFlash(){
        muzzleFlash.Play();
    }
    
    void ProcessRaycast(){
        RaycastHit hit;
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward,out hit, range))
        {
            CreateHitImpact(hit);
                Debug.Log("i hit thing"+hit.transform.name);
               EnemyHealth target=hit.transform.GetComponent<EnemyHealth>();
               if(target)
                target.takeDamage(damage);
        }
        else
        {
            return;
        }
    }
    void CreateHitImpact(RaycastHit hit){

            GameObject impact=Instantiate(hitEffect,hit.point,Quaternion.LookRotation(hit.normal));
            Destroy(impact,2);
    }
}
