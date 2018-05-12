using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class BulletBehavior : MonoBehaviour {

    [SerializeField]
    public float Speed = 3f;
    [SerializeField]
    public float Power = 1f;
    [SerializeField]
    private GameObject hitting;
    [SerializeField]
    public bool Modle = true;
    [SerializeField]
    public bool Player = false;

    private Rigidbody rb;
    private Vector3 movement;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        movement = transform.forward * Speed;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (!Modle) {
            if (gameObject.layer != 9)
                gameObject.layer = 9;
            Move();
            Destroy();
        }
    }

    void Move() {
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
    }

    void Destroy() {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        if (x > 20 || x < -20 || y > 15 || y < -15 || z > 10 || z < -15)
            Destroy(gameObject);
    }

    //On hit
    void OnTriggerEnter(Collider collision) {
        if (!Modle && collision.gameObject.name != "Bullet") {
            if (collision.GetComponent<Entety>() != null) {
                Entety e = collision.GetComponent<Entety>();
                if (e.Player != Player) {
                    //effect
                    if (hitting != null) {
                        GameObject h = Instantiate(hitting) as GameObject;
                        h.transform.position = transform.position;
                        h.layer = 9;
                        h.GetComponent<AudioSource>().Play();
                        Destroy(h, 1f);
                    }
                    //destroy
                    Destroy(gameObject);
                    //-HP
                    e.Health -= Power;
                    //shack camra
                    if (e.Player)
                        collision.transform.GetChild(1).gameObject.GetComponent<ShackCamera>().setShack();
                }
            }
        }
    }
}
