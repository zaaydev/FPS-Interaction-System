using UnityEngine;

public class PlayerRaycastScript : MonoBehaviour
{
    [SerializeField] private float rayDistance = 5f;
    [SerializeField] private Camera cam; 
    RaycastHit hit;
    [SerializeField] private TMPro.TMP_Text interactionText;

    private InteractableScript interactableScript;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.forward * rayDistance, Color.red);
        interactionText.text = "";

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, rayDistance)) {

            if (hit.collider.TryGetComponent(out interactableScript)) {
                interactionText.text = "[E] " + interactableScript.interactionMessage;
            }
        } 
    }

    public void Process_E_Interact() {
        if (interactableScript != null) {
            interactableScript.Interact();
        }
    }
}
