using System;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera1;
    public Camera normalCamera;
    public CinemachineDollyCart dollyCart;
    public CinemachineSmoothPath path;
    public float distanceToSwitch = 10f;
    public GameObject player;

    private void Start()
    {
        normalCamera.enabled = false;
        player.SetActive(false);
    }

    private void Update()
    {
        CheckWaypoint();
    }

    private void CheckWaypoint()
    {
        if (virtualCamera1 == null || normalCamera == null || dollyCart == null || path == null)
        {
            Debug.LogError("Referanslardan biri eksik. Lütfen virtualCamera1, normalCamera, dollyCart ve path referanslarını atadığınızdan emin olun.");
            return;
        }

        // Yolun toplam uzunluğunu ve Dolly Cart'ın mevcut konumunu al
        float pathLength = path.PathLength;
        float cartPosition = dollyCart.m_Position;

        // Dolly Cart'ın konumu, yolun toplam uzunluğundan belirli bir mesafe farkına eşit veya büyükse kamerayı değiştir
        if (cartPosition >= pathLength - distanceToSwitch)
        {
            SwitchCamera();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        if (virtualCamera1 != null)
        {
            virtualCamera1.enabled = false;

            // Ana kamerayı devre dışı bırak
            Camera mainCamera = virtualCamera1.GetComponentInChildren<Camera>();
            if (mainCamera != null)
            {
                mainCamera.enabled = false;
            }
        }

        if (normalCamera != null)
        {
            normalCamera.enabled = true;
        }
        
        player.SetActive(true);
    }
}