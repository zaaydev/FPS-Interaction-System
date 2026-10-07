using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerScript : MonoBehaviour
{
    private PlayerInputActions playerActions;
    private PlayerControllerScript playerControllerScript;
    private PlayerRaycastScript playerRaycastScript;
    private PlayerLook LookScript;


    private void Awake()
    {
        playerActions = new PlayerInputActions();
        playerControllerScript = GetComponent<PlayerControllerScript>();
        LookScript = GetComponent<PlayerLook>();
        playerRaycastScript = GetComponent<PlayerRaycastScript>();
    }

    void Update()
    {
        Vector2 playerInputValue = playerActions.PlayerMap.Move.ReadValue<Vector2>();
        Vector2 lookValue = playerActions.PlayerMap.Look.ReadValue<Vector2>();

        playerControllerScript.ProcessMove(playerInputValue);
        LookScript.ProcessLook(lookValue);

    }

    private void TriggerPlayerJump(InputAction.CallbackContext uselessExtraInfo) {  
        playerControllerScript.ProcessJump();
    }

    private void TriggerPlayer_E_Interact(InputAction.CallbackContext uselessExtraInfo) {  
        playerRaycastScript.Process_E_Interact();
    }

    private void OnEnable()
    {
        playerActions.PlayerMap.Enable();  
        playerActions.PlayerMap.Jump.performed += TriggerPlayerJump;  
        playerActions.PlayerMap.Interact.performed += TriggerPlayer_E_Interact;  
        
    }   
    
    private void OnDisable()
    {
        playerActions.PlayerMap.Disable();            
    }
}
