using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using StarterAssets;
public class WeaponZoom : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] CinemachineVirtualCamera childCamera;
    [SerializeField] float zoomInFOV = 20f;
    [SerializeField] float zoomIOutFOV = 40f;
    [SerializeField] float zoomInSensitivity = 0.5f;
    [SerializeField] float zoomIOutSensitivity = 1f;

    FirstPersonController fpsFirstContoller;
    private void OnDisable() {
        ZoomOut();
    }
    void Start()
    {
        //  childCamera = this.GetComponentInParent<CinemachineVirtualCamera>();
        childCamera = FindAnyObjectByType<CinemachineVirtualCamera>();


        // Set the field of view of the Cinemachine Virtual Camera
        childCamera.m_Lens.FieldOfView = 40f; // Set the field of view to 60 degrees
        fpsFirstContoller = GetComponentInParent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ZoomIn();
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            ZoomOut();
        }
    }


    private void ZoomIn()
    {
        //zoom in
        fpsFirstContoller.RotationSpeed = zoomInSensitivity;
        childCamera.m_Lens.FieldOfView = zoomInFOV;
    }
    
    private void ZoomOut()
    {
        //zoom out
        fpsFirstContoller.RotationSpeed = zoomIOutSensitivity;

        childCamera.m_Lens.FieldOfView = zoomIOutFOV;
    }
}
