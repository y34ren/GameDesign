using UnityEngine;

public class Enemy1BH : MonoBehaviour {

    [SerializeField]
    public GameObject Bullet;
    [SerializeField]
    public int NumberOfBullet = 5;
    [SerializeField]
    public int AttackInterval = 100;

    private int time = 0;
    private bool Modle = false;

    // Use this for initialization
    void Start() {
        Modle = GetComponentInParent<Entety>().Modle;
    }

    // Update is called once per frame
    void Update() {
        Shoot();
    }

    void Shoot() {
        if (Bullet != null && !Modle) {
            if (++time % AttackInterval == 0) {
                for (int i = 0; i < NumberOfBullet; i++) {
                    Vector3 v = new Vector3(Random.Range(-10f, 10f) + 180, Random.Range(-10f, 10f), 0f);
                    GameObject clone1 = Instantiate(Bullet, transform.position, Quaternion.Euler(v)) as GameObject;
                    BulletBehavior b = clone1.GetComponent<BulletBehavior>();
                    b.Modle = false;
                    b.Speed += Random.Range(-2.5f, 2.5f);
                }
                time = 0;
            }
        }
    }
}
