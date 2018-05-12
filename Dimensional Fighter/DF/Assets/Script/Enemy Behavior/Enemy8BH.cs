using UnityEngine;

public class Enemy8BH : MonoBehaviour {

    [SerializeField]
    public GameObject Bullet;
    [SerializeField]
    public int NumberOfBullet = 5;

    private bool trigger = false;
    private Entety e;
    private bool Modle = false;

    // Use this for initialization
    void Start() {
        e = GetComponentInParent<Entety>();
        trigger = false;
        Modle = GetComponentInParent<Entety>().Modle;
    }

    // Update is called once per frame
    void Update() {
        if (e.Health < 0 && !trigger) {
            trigger = true;
            Die();
        }
    }

    void Die() {
        if (Bullet != null && !Modle) {
            for (int j = 0; j < NumberOfBullet; j++) {
                Vector3 v = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
                GameObject clone1 = Instantiate(Bullet, transform.position, Quaternion.Euler(v)) as GameObject;
                BulletBehavior b = clone1.GetComponent<BulletBehavior>();
                b.Modle = false;
                b.Speed += Random.Range(-2.5f, 2.5f);
            }
        }
    }
}
