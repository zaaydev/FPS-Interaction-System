using UnityEngine;

public class ElevatorDoor : InteractableScript
{
    [SerializeField] private Animator door1Animator;
    [SerializeField] private Animator door2Animator;
    [SerializeField] private Renderer buttonRenderer;
    private bool isOpen;


    public override void Interact()
    {
        isOpen = door1Animator.GetBool("isOpen");
        door1Animator.SetBool("isOpen", !isOpen);
        door2Animator.SetBool("isOpen2", !isOpen);

        if (isOpen == true)
        {
            buttonRenderer.material.color = Color.green;
            buttonRenderer.material.SetColor("_EmissionColor", Color.green * 3f);
        }
        else
        {
            buttonRenderer.material.color = Color.red;
            buttonRenderer.material.SetColor("_EmissionColor", Color.red * 3f);
        }
    }
}
