using UnityEngine;

public abstract class InteractableScript : MonoBehaviour
{
    public string interactionMessage = "Interact";

    public abstract void Interact();
}
