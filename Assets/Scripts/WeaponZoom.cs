using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera fpsCamera;
    [SerializeField] float normalFOV = 60f;
    [SerializeField] float zoomedFOV = 20f;
    FirstPersonController firstPersonController;
    [SerializeField] float normalRotationSpeed = 1.0f;
    [SerializeField] float normalMoveSpeed = 4.0f;
    [SerializeField] float normalSprintSpeed = 6.0f;
    [SerializeField] float zoomedRotationSpeed = 0.1f;
    [SerializeField] float zoomedMoveSpeed = 1f;
    [SerializeField] float zoomedSprintSpeed = 0.2f;

    void Start() {
        firstPersonController = GetComponent<FirstPersonController>();
    }
 
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            ZoomView();
        }
        else
        {
            fpsCamera.m_Lens.FieldOfView = normalFOV;
            firstPersonController.RotationSpeed = normalRotationSpeed;
            firstPersonController.MoveSpeed = normalMoveSpeed;
            firstPersonController.SprintSpeed = normalSprintSpeed;
        }
    }
 
    void ZoomView()
    {
        fpsCamera.m_Lens.FieldOfView = zoomedFOV;
        firstPersonController.RotationSpeed = zoomedRotationSpeed;
        firstPersonController.MoveSpeed = zoomedMoveSpeed;
        firstPersonController.SprintSpeed = zoomedSprintSpeed;
    }
}