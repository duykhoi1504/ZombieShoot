using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas impactCanvas;
    [SerializeField] float impactTime= 0.3f;
    void Start()
    {
        impactCanvas.enabled = false;
    }

    public void ShowDamageImpact(){
        StartCoroutine(Showplatter());

    }
    IEnumerator Showplatter(){
        impactCanvas.enabled=true;
        yield return new WaitForSeconds(impactTime);
        impactCanvas.enabled = false;

    }
}
