using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerFootStep : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W)){
            GetComponent<Animator>().SetTrigger("Move");
        }
        if(Input.GetKeyUp(KeyCode.W)){
            GetComponent<Animator>().SetTrigger("Idle");

        }
    }
}
