using UnityEngine;
using System.Collections;

public class Wave : MonoBehaviour {

    [SerializeField]
    private GameObject Spwan;

    private GameObject[] numbers = new GameObject[2];

    // Use this for initialization
    void Start() {
        for (int i = 0; i < 2; i++)
            numbers[i] = transform.GetChild(i).gameObject;
    }

    // Update is called once per frame
    void Update() {
        showWave(getWave());
    }

    int getWave() {
        if (Spwan != null)
            return Spwan.GetComponent<Spwan>().level;
        return 0;
    }

    void showWave(int wave) {
        int ten = wave / 10;
        int bit = wave % 10;
        numbers[0].GetComponent<Number>().number = ten;
        numbers[1].GetComponent<Number>().number = bit;
    }
}
