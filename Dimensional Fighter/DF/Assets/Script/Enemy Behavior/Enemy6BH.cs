using UnityEngine;

public class Enemy6BH : MonoBehaviour {

    [SerializeField]
    public GameObject Bullet;
    [SerializeField]
    public int AttackInterval = 100;

    private int time = 0;
    private bool Modle = false;
    private GameObject[] players;

    // Use this for initialization
    void Start() {
        Modle = GetComponentInParent<Entety>().Modle;
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        Shoot();
    }

    void Shoot() {
        if (Bullet != null && !Modle) {
            if (++time % AttackInterval == 0) {
                //find the nearest player
                int min = 0;
                float distance = Vector3.Distance(transform.position, players[0].transform.position);
                for (int i = 1; i < players.Length; i++)
                    if (Vector3.Distance(transform.position, players[i].transform.position) < distance)
                        min = i;
                //clone a bullet
                GameObject clone1 = Instantiate(Bullet, transform.position, Quaternion.Euler(Vector3.zero)) as GameObject;
                clone1.transform.LookAt(players[min].transform);
                clone1.GetComponent<BulletBehavior>().Modle = false;
                time = 0;
            }
        }
    }
}
