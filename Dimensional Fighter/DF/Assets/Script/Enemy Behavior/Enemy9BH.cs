using UnityEngine;
using System.Collections;

public class Enemy9BH : MonoBehaviour {

    [SerializeField]
    public GameObject Flight;
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
        if (Flight != null && !Modle) {
            if (++time % AttackInterval == 0) {
                GameObject f = Instantiate(Flight, transform.position, Quaternion.Euler(Vector3.zero)) as GameObject;
                f.transform.SetParent(transform.parent.parent);
                f.GetComponent<Entety>().Modle = false;
                f.SetActive(true);
                time = 0;
            }
        }
    }
}
