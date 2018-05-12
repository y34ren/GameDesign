using UnityEngine;
using System.Collections;

public class Enemy10BH : MonoBehaviour {

    [SerializeField]
    public GameObject Bullet;
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
                Vector3 v = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));
                GameObject clone1 = Instantiate(Bullet, transform.position, Quaternion.Euler(v)) as GameObject;
                BulletBehavior b = clone1.GetComponent<BulletBehavior>();
                b.Modle = false;
                b.Speed += Random.Range(-1.25f, 1.25f);
                time = 0;
            }
        }
    }
}
