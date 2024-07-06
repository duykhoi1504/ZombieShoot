using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints=100f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(float damage){
        hitPoints-=damage;
        if(hitPoints < 0){
            Destroy(this.gameObject);
        }
    }
}
