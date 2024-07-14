using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
  // Start is called before the first frame update
  [Tooltip("health")]
  [SerializeField] float hitPoints = 100f;
  [SerializeField] GameObject deathFX;
  [SerializeField] GameObject hitVFX;
  bool isDead = false;
  public bool IsDead()
  {
    return isDead;
  }
  public void takeDamage(float damage)
  {
    // Instantiate(hitVFX, this.transform.position, Quaternion.identity);
    GameObject impact = Instantiate(hitVFX, this.transform.position, Quaternion.identity);
    Destroy(impact, 2);
    //  GetComponent<EnemyAI>().OnDamageTaken();
    BroadcastMessage("OnDamageTaken");
    hitPoints -= damage;
    if (hitPoints <= 0)
    {
      Die();
    }
  }

  private void Die()
  {
    if (isDead) return;
    isDead = true;
    GameObject impactDead = Instantiate(deathFX, this.transform.position, Quaternion.identity);
    MusicPlayer.Instant.PLaySFX("dead");
    Destroy(impactDead, 2);
    GetComponent<Animator>().SetTrigger("die");
    Destroy(gameObject, 2);

  }
}
