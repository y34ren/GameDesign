using UnityEngine;

public class Enemy2BH : MonoBehaviour {

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
                GameObject clone1 = Instantiate(Bullet, transform.position, transform.rotation) as GameObject;
                clone1.GetComponent<BulletBehavior>().Modle = false;
                time = 0;
            }
        }
    }
}
