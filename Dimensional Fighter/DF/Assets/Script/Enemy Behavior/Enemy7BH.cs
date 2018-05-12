using UnityEngine;

public class Enemy7BH : MonoBehaviour {

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
            for (int j = 0; j < NumberOfBullet * 2; j++) {
                float r = j * 180f / NumberOfBullet - 180f;
                float s = NumberOfBullet * Mathf.Cos(r);
                for (int i = 0; i < s; i++) {
                    Vector3 v = new Vector3(r, i * 360f / s - (j % 2) * 180f / s, 0f);
                    GameObject clone1 = Instantiate(Bullet, transform.position, Quaternion.Euler(v)) as GameObject;
                    clone1.GetComponent<BulletBehavior>().Modle = false;
                }
            }
        }
    }
}
