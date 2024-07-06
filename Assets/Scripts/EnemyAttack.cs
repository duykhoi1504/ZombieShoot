using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 2f;
     void Start() {
        target=FindAnyObjectByType<PlayerHealth>();
    }

    // Update is called once per frame
    
    public void AttackHitEvent(){
        if(target==null){return;}
        target.takeDamage(damage);
        Debug.Log("bamg bamg");
    }
}
