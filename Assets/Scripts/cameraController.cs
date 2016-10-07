using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

    public Transform lookAt;
    public Transform camTransform;
    public float distance = 50.0f;
    public float yHeight = 80.0f;
    public float sensitivityX = 5.5f;
    private Camera cam;

    private float currentX = 0.0f;
    private float currentY = 0.0f;

    private void Start() {
        camTransform = transform;
        cam = Camera.main;
    }

    private void Update() {
        if (Input.GetMouseButton(1)) {
            currentX += Input.GetAxis("Mouse X") * sensitivityX;
        }
        currentY = yHeight;
    }

    private void LateUpdate() {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
