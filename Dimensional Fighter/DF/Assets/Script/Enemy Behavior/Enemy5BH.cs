using UnityEngine;
using System.Collections.Generic;

public class Enemy5BH : MonoBehaviour {

    [SerializeField]
    public GameObject Flight;
    [SerializeField]
    public int NumberOfFlight = 4;

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
        if (Flight != null && !Modle) {
            GameObject f;
            for (int i = 0; i < NumberOfFlight; i++) {
                f = Instantiate(Flight, transform.position, Quaternion.Euler(Vector3.zero)) as GameObject;
                f.transform.SetParent(transform.parent.parent);
                f.GetComponent<Entety>().Modle = false;
                f.SetActive(true);
            }
        }
    }
}
