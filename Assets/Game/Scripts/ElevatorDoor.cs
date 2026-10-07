using UnityEngine;

public class ElevatorDoor : InteractableScript
{
    [SerializeField] private Animator door1Animator;
    [SerializeField] private Animator door2Animator;
    [SerializeField] private Renderer buttonRenderer;

    public override void Interact()
    {
        door1Animator.Play("Door1_Open");
        door2Animator.Play("Door2_Open");

        buttonRenderer.material.color = Color.green;
    }
}
