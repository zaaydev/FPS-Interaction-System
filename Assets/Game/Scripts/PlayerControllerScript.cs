using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float gravity = -9.8f;
    private Vector3 playerVelocity;
    private float jumpHeight = 1.5f;


    public void ProcessMove(Vector2 input) {
        Vector3 moveDirection = Vector3.zero;

        // apply movement
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        
        // apply gravity
        playerVelocity.y += gravity * Time.deltaTime;
        if (controller.isGrounded && playerVelocity.y < 0) playerVelocity.y = -2f;
        moveDirection.y = playerVelocity.y;    

        // finally update the player transform state
        controller.Move(transform.TransformDirection(moveDirection) * movementSpeed * Time.deltaTime);
    } 

    public void ProcessJump() {
        playerVelocity.y = Mathf.Sqrt(jumpHeight * -1f * gravity);
    }
}
