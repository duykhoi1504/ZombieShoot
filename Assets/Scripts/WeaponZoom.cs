using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using StarterAssets;
public class WeaponZoom : MonoBehaviour
{
    // Start is called before the first frame update
    CinemachineVirtualCamera childCamera;
    [SerializeField] float zoomInFOV=20f;
    [SerializeField] float zoomIOutFOV=40f;
    [SerializeField] float zoomInSensitivity=0.5f;
    [SerializeField] float zoomIOutSensitivity=1f;

    FirstPersonController fpsFirstContoller;
    void Start()
    {
         childCamera = this.GetComponentInChildren<CinemachineVirtualCamera>();

    // Set the field of view of the Cinemachine Virtual Camera
        childCamera.m_Lens.FieldOfView = 40f; // Set the field of view to 60 degrees
        fpsFirstContoller=GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            fpsFirstContoller.RotationSpeed=zoomInSensitivity;
          childCamera.m_Lens.FieldOfView = zoomInFOV;
        }
        else if(Input.GetButtonUp("Fire2"))
        {
            fpsFirstContoller.RotationSpeed=zoomIOutSensitivity;

            childCamera.m_Lens.FieldOfView = zoomIOutFOV;
        }
    }
}
