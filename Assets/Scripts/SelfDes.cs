using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDes : MonoBehaviour
{
    [SerializeField] float timeDes=2f;
    void Start()
    {
        Destroy(this.gameObject,timeDes);
    }
}
