using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Variables")]

    [SerializeField] private float speed;
    [SerializeField] private float smoothTime = 0.1f;
    [SerializeField] private float rotationSpeed = 720f;

    private Vector2 moveDirection;
    private Vector3 currentMovement;
    private Vector3 currentVelocity;

    [Header("References")]

    [SerializeField] private GameObject playerModel;
    private CharacterController cc;
    private Camera cam;


    // ----------------- Default Methods -----------------

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        cam = Camera.main;

        moveDirection = Vector3.zero;
    }

    private void FixedUpdate()
    {
        Movement();

        Vector3 move = currentMovement;

        if (!cc.enabled) return;
        cc.Move(move * Time.fixedDeltaTime);
    }
    

    // ----------------- Private Methods -----------------

    private void Movement()
    {

        Vector3 targetMove = (Vector3.forward * moveDirection.y) + (Vector3.right * moveDirection.x);
        if (targetMove.sqrMagnitude > 1f) targetMove.Normalize();
        targetMove *= speed;

        Vector3 facingDirection = new Vector3(targetMove.x, 0f, targetMove.z);
        if (facingDirection.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(facingDirection, Vector3.up);
            playerModel.transform.rotation = Quaternion.RotateTowards(
                playerModel.transform.rotation,
                targetRotation,
                rotationSpeed * Time.fixedDeltaTime);
        }
        
        currentMovement = Vector3.SmoothDamp(currentMovement, targetMove, ref currentVelocity, smoothTime);
    }

    // ----------------- Input Actions -----------------

    public void OnMove(InputAction.CallbackContext cx)
    {
        moveDirection = cx.ReadValue<Vector2>();
    }
}
