using UnityEngine;

public class PlayerRaycastScript : MonoBehaviour
{
    [SerializeField] private float rayDistance = 3f;
    [SerializeField] private Camera cam; 
    [SerializeField] private TMPro.TMP_Text interactionText;
    [SerializeField] private LayerMask layerMask;
    RaycastHit hit; 

    private InteractableScript interactableScript;

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(cam.transform.position, cam.transform.forward * rayDistance, Color.red);
        interactionText.text = string.Empty;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, rayDistance, layerMask)) {

            if (hit.collider.TryGetComponent(out interactableScript)) {
                interactionText.text = "[E] " + interactableScript.interactionMessage;
            }
        } 
    }

    public void Process_E_Interact() {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, rayDistance, layerMask)) {
            if (hit.collider.TryGetComponent(out interactableScript)) {
                interactableScript.Interact();
            }

        }
    }
}
