using UnityEngine;

public class Enemy3BH : MonoBehaviour {

    [SerializeField]
    public LineRenderer Laser;
    [SerializeField]
    public Light light;

    private int time = 0;
    private float l = 0;
    private bool Modle = false;

    // Use this for initialization
    void Start() {
        Laser.enabled = false;
        Modle = GetComponentInParent<Entety>().Modle;
    }

    // Update is called once per frame
    void Update() {
        if (GetComponentInParent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Self_yRot"))
            Shoot();
    }

    void Shoot() {
        if (Laser != null && !Modle) {
            if (time < 100) {
                light.intensity = time * 0.08f;
                time++;
            }
            else {
                Laser.enabled = true;
                l = Mathf.Lerp(l, 50, 0.02f);
                Ray ray = new Ray(transform.position, transform.forward);
                Laser.SetPosition(0, ray.origin);
                Laser.SetPosition(1, ray.GetPoint(l));
            }
        }
    }
}

