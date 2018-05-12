using UnityEngine;

public class Enemy4BH : MonoBehaviour {

    [SerializeField]
    public GameObject Bullet;
    [SerializeField]
    public int NumberOfBullet = 5;
    [SerializeField]
    public int Row = 1;
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
                for (int j = 0; j < Row; j++)
                    for (int i = 0; i < NumberOfBullet; i++) {
                        Vector3 v = new Vector3((1f - Row) * 5f + 10f * j, i * 360f / NumberOfBullet - (j % 2) * 180f / NumberOfBullet, 0f);
                        GameObject clone1 = Instantiate(Bullet, transform.position, Quaternion.Euler(v)) as GameObject;
                        clone1.GetComponent<BulletBehavior>().Modle = false;
                    }
                time = 0;
            }
        }
    }
}
