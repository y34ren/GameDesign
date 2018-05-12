using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float MoveSpeed = 5f;
    [SerializeField]
    private float RotateSpeed = 3f;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Spwan spwan;

    private Rigidbody rb;
    private Vector3 movement = Vector3.zero;
    private Vector3 xRotation = Vector3.zero;
    private Vector3 yRotation = Vector3.zero;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (spwan.playing) {
            //Make movement vector
            Vector3 xMov = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
            Vector3 yMov = new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
            movement = (xMov + yMov).normalized * MoveSpeed;
            //Make rotation vector
            xRotation = new Vector3(0f, Input.GetAxisRaw("Mouse X"), 0f) * RotateSpeed;
            yRotation = new Vector3(-Input.GetAxisRaw("Mouse Y"), 0f, 0f) * RotateSpeed;
        }
    }

    void FixedUpdate() {
        if (movement != Vector3.zero) Move();
        Rotate();
    }

    //Movement
    void Move() {
        //move
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        //Fix position
        Vector3 pos = rb.position;
        pos.x = pos.x > 14f ? 14f : pos.x;
        pos.x = pos.x < -14f ? -14f : pos.x;
        pos.y = pos.y > 9f ? 9f : pos.y;
        pos.y = pos.y < -9f ? -9f : pos.y;
        rb.position = pos;
    }

    //Rotation
    void Rotate() {
        //Rotate around
        rb.MoveRotation(rb.rotation * Quaternion.Euler(xRotation));
        //Rotate UP-DOWN
        if (cam != null)
            cam.transform.Rotate(yRotation);
    }
}