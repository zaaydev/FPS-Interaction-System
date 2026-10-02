using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerScript : MonoBehaviour
{
    private PlayerInputActions playerActions;
    private PlayerControllerScript playerControllerScript;
    private PlayerLook LookScript;


    private void Awake()
    {
        playerActions = new PlayerInputActions();
        playerControllerScript = GetComponent<PlayerControllerScript>();
        LookScript = GetComponent<PlayerLook>();
    }


    void Update()
    {
        Vector2 playerInputValue = playerActions.PlayerMap.Move.ReadValue<Vector2>();
        Vector2 lookValue = playerActions.PlayerMap.Look.ReadValue<Vector2>();


        playerControllerScript.ProcessMove(playerInputValue);
        LookScript.ProcessLook(lookValue);
    }

    private void triggerPlayerJump(InputAction.CallbackContext uselessExtraInfo) {  
        playerControllerScript.ProcessJump();
    }

    private void OnEnable()
    {
        playerActions.PlayerMap.Enable();  
        playerActions.PlayerMap.Jump.performed += triggerPlayerJump;  
        
    }   
    
    private void OnDisable()
    {
        playerActions.PlayerMap.Disable();            
    }
}
