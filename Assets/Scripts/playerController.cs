using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    public float moveSpeed = 20.0f;

    private Rigidbody rb;
    private Camera playerCamera;
    private Vector3 keyboardInput;
    private Vector3 playerDirection;
    private Vector3 moveVelocity;
    private int cameraLayermask;

    // Use this for initialization //
    void Start() {

        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main;

        // Layers for Camera Raycast to focus on //
        int groundLayer = 8;

        // Add layers to Layermask
        cameraLayermask = 1 << groundLayer;
    }

    // Update is called once per frame //
    void Update() {

        keyboardInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        playerDirection = playerCamera.transform.TransformDirection(keyboardInput);
        playerDirection.y = 0f;
        playerDirection.Normalize();
        print(playerDirection);

        moveVelocity = playerDirection * moveSpeed;

        if (!Input.GetMouseButton(1)) {

            Ray cameraRay = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(cameraRay, out hit, Mathf.Infinity, cameraLayermask)) {

                Debug.DrawLine(cameraRay.origin, hit.point, Color.blue);

                transform.LookAt(new Vector3(hit.point.x, hit.point.y + 0.5f, hit.point.z));
            }
        }
    }

    void FixedUpdate() {

        //Replace Gravity
        moveVelocity.y = rb.velocity.y;
        rb.velocity = moveVelocity;

    }
}
