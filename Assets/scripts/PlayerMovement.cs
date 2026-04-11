using System;
using Unity.Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    [Header("Control Options")]
    [SerializeField] public bool CanMove = true;
    [SerializeField] public float MovementSpeed = 5f;
    [SerializeField] private float Sensitivity = 2.0f;
    [SerializeField] public float VerticalLimit = 80.0f;

    private CinemachineCamera playerCamera;
    private CharacterController characterController;
    private float verticalRotation;
    private ComputerUIManager _uiManager;
    
    private void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<CinemachineCamera>();
        _uiManager = ComputerUIManager.Instance;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (CanMove && !_uiManager.ComputerActive)
        {
            Movement();
            LookRotation();
        }
    }

    private void Movement()
    {
        float vSpeed = Input.GetAxis("Vertical") * MovementSpeed;
        float hSpeed = Input.GetAxis("Horizontal") * MovementSpeed;
        Vector3 plrSpeed = new Vector3(hSpeed, 0, vSpeed);
        plrSpeed = transform.rotation * plrSpeed;
        
        characterController.SimpleMove(plrSpeed);
    }

    private void LookRotation()
    {
        float mouseXrot = Input.GetAxis("Mouse X") * Sensitivity;
        transform.Rotate(0, mouseXrot, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * Sensitivity;
        verticalRotation = Math.Clamp(verticalRotation, -VerticalLimit, VerticalLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}