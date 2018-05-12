using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BulletBehavior))]
public class Shooting : MonoBehaviour {

    [SerializeField]
    private GameObject Bullet;
    [SerializeField]
    private int minAttackInterval = 25;
    [SerializeField]
    private int maxAttackInterval = 5;
    [SerializeField]
    public int Cooldown = 0;
    [SerializeField]
    public int maxCooldown = 50;
    [SerializeField]
    private GameObject Bar;

    private int time = 0;
    private bool isCooldown = false;
    private AudioSource Audio;

    // Use this for initialization
    void Start() {
        Audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        Shoot();
        CooldownGUI();
    }

    void Shoot() {
        if (Input.GetButton("Fire1") && !isCooldown) {
            if (Bullet != null) {
                float persent = 1 - Mathf.Sqrt(Cooldown) / Mathf.Sqrt(maxCooldown);
                int interval = (int)Mathf.Lerp(maxAttackInterval, minAttackInterval, persent);
                if (++time % interval == 0) {
                    GameObject clone1 = Instantiate(Bullet, transform.position, transform.rotation) as GameObject;
                    clone1.GetComponent<BulletBehavior>().Modle = false;
                    clone1.GetComponent<BulletBehavior>().Player = true;
                    Audio.Play();
                    time = 0;
                    Cooldown++;
                }
            }
        }
        else DeCooldown();
        if (Cooldown > maxCooldown) isCooldown = true;
    }

    void DeCooldown() {
        int interval = (maxAttackInterval + minAttackInterval) / 2;
        if (++time % interval == 0) {
            if (Cooldown > 0)
                Cooldown -= 5;
            else {
                Cooldown = 0;
                isCooldown = false;
            }
            time = 0;
        }
    }

    void CooldownGUI() {
        if (Bar != null) {
            RectTransform rt = Bar.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(389f * Cooldown / maxCooldown, 46f);
        }
    }
}
