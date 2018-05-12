using UnityEngine;
using System.Collections;

public class Entety : MonoBehaviour {
    [SerializeField]
    public float Health = 10f;
    [SerializeField]
    private GameObject Explosion;
    [SerializeField]
    public bool Player = false;
    [SerializeField]
    public bool Modle = false;
    [SerializeField]
    private GameObject Bar;
    [SerializeField]
    private GameObject gameControlor;

    private bool isDie = false;
    private float maxHealth = 10f;
    private GameSystem gs;

    // Use this for initialization
    void Start() {
        gs = gameControlor.GetComponent<GameSystem>();
    }

    // Update is called once per frame
    void Update() {
        if (!Modle) {
            HealthGUI();
            if (gameObject.layer != 9) gameObject.layer = 9;
            for (int i = 0; i < transform.childCount; i++)
                if (transform.GetChild(i).gameObject.layer != 9)
                    transform.GetChild(i).gameObject.layer = 9;
            if (isDie)
                Die();
            else if (Health < 0)
                isDie = true;
        }
    }

    void Die() {
        if (Player) {
            gs.deplay();
        }
        else {
            if (Explosion != null) {
                GameObject E = Instantiate(Explosion, transform.position, transform.rotation) as GameObject;
                E.layer = 9;
                E.GetComponent<AudioSource>().Play();
                Destroy(E, 1f);
            }
            Destroy(gameObject);
            gs.destruction++;
        }
    }

    void HealthGUI() {
        if (Bar != null) {
            RectTransform rt = Bar.GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2(389f * Health / maxHealth, 46f);
        }
    }
}
