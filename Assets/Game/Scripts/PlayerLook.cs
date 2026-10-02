using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    // camera up-down = playerview up-down
    private float xRotation = 0f;

    private float xSensitivity = 50f;
    private float YSensitivity = 50f;

    public void ProcessLook(Vector2 input) {
        float mouseX = input.x;
        float mouseY = input.y;
        Debug.Log(mouseY);

        xRotation -= mouseY * YSensitivity * Time.deltaTime; // sensitivity controls
        xRotation = Mathf.Clamp(xRotation, -80f, 80f); // look limits

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0); // updown

        Vector3 playerBodyRotation = new Vector3(0, mouseX * xSensitivity * Time.deltaTime, 0);
        transform.Rotate(playerBodyRotation);

    }
}
