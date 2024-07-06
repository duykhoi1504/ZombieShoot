using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("health")]
    [SerializeField] float hitPoints=100f;
     [SerializeField] GameObject deathFX;
  [SerializeField] GameObject hitVFX;
    public void takeDamage(float damage){
      Instantiate(hitVFX, this.transform.position, Quaternion.identity);
       
        hitPoints-=damage;
        if(hitPoints<=0){
            Instantiate(deathFX, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
