using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReader : MonoBehaviour
{
    public static PlayerInputReader Instance;
    [SerializeField] private PlayerInputActions playerInput;
    
    private PlayerMovement playerMovement;
    private PlayerBehavior playerBehavior;

    void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        else Instance = this;

        playerInput = new PlayerInputActions();
        playerInput.DefaultMap.Enable();
    }

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInput.DefaultMap.Movement.started += playerMovement.OnMove;
        playerInput.DefaultMap.Movement.performed += playerMovement.OnMove;
        playerInput.DefaultMap.Movement.canceled += playerMovement.OnMove;

        playerBehavior = GetComponent<PlayerBehavior>();
        playerInput.DefaultMap.Shoot.started += playerBehavior.Shoot;
    }
}
