using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyMovement : MonoBehaviour {

    enum Movetypes : int { Stand, Spring, Horizontal, Vertical, Follow, Ram };

    [SerializeField]
    public int MoveType = (int)Movetypes.Stand;
    [SerializeField]
    public float Speed = 5f;

    private Vector3 velocity = Vector3.zero;
    private Rigidbody rb;
    private GameObject[] players;
    private int Timer = -1;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        //Reset values
        switch (MoveType) {
            case 0:
                Speed = 0f;
                break;
            case 1:
                velocity.x = Random.Range(-100f, 100f);
                velocity.y = Random.Range(-100f, 100f);
                velocity = velocity.normalized * Speed;
                rb.AddForce(velocity, ForceMode.Impulse);
                break;
            case 2:
                velocity.x = Speed;
                rb.AddForce(velocity, ForceMode.Impulse);
                break;
            case 3:
                velocity.y = Speed;
                rb.AddForce(velocity, ForceMode.Impulse);
                break;
            case 4:
                players = GameObject.FindGameObjectsWithTag("Player");
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate() {
        switch (MoveType) {
            case 4:
                Follow();
                break;
            case 5:
                Ram();
                break;
        }
    }

    void Follow() {
        if (players != null) {
            int min = 0;
            float distance = Vector3.Distance(transform.position, players[0].transform.position);
            for (int i = 1; i < players.Length; i++)
                if (Vector3.Distance(transform.position, players[i].transform.position) < distance)
                    min = i;
            velocity = players[min].transform.position - transform.position;
            velocity.z = 0;
            velocity = velocity.normalized * Speed * Time.fixedDeltaTime;
            rb.AddForce(velocity, ForceMode.Impulse);
        }
    }

    void Ram() {
        if (++Timer % (Speed * Speed) == 0) {
            rb.Sleep();
            velocity.x = Random.Range(-100f, 100f);
            velocity.y = Random.Range(-100f, 100f);
            velocity = velocity.normalized * Speed;
            rb.AddForce(velocity, ForceMode.Impulse);
            Timer = 0;
        }
    }
}