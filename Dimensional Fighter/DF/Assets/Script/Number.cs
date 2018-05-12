using UnityEngine;
using System.Collections;

public class Number : MonoBehaviour {

    [SerializeField]
    public int number = 0;

    private GameObject[] numbers = new GameObject[7];

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 7; i++)
            numbers[i] = transform.GetChild(i).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        showNumber();
	}

    void showNumber() {
        switch (number) {
            case 0:
                numbers[0].SetActive(true);
                numbers[1].SetActive(true);
                numbers[2].SetActive(true);
                numbers[3].SetActive(false);
                numbers[4].SetActive(true);
                numbers[5].SetActive(true);
                numbers[6].SetActive(true);
                break;
            case 1:
                numbers[0].SetActive(false);
                numbers[1].SetActive(false);
                numbers[2].SetActive(true);
                numbers[3].SetActive(false);
                numbers[4].SetActive(false);
                numbers[5].SetActive(true);
                numbers[6].SetActive(false);
                break;
            case 2:
                numbers[0].SetActive(true);
                numbers[1].SetActive(false);
                numbers[2].SetActive(true);
                numbers[3].SetActive(true);
                numbers[4].SetActive(true);
                numbers[5].SetActive(false);
                numbers[6].SetActive(true);
                break;
            case 3:
                numbers[0].SetActive(true);
                numbers[1].SetActive(false);
                numbers[2].SetActive(true);
                numbers[3].SetActive(true);
                numbers[4].SetActive(false);
                numbers[5].SetActive(true);
                numbers[6].SetActive(true);
                break;
            case 4:
                numbers[0].SetActive(false);
                numbers[1].SetActive(true);
                numbers[2].SetActive(true);
                numbers[3].SetActive(true);
                numbers[4].SetActive(false);
                numbers[5].SetActive(true);
                numbers[6].SetActive(false);
                break;
            case 5:
                numbers[0].SetActive(true);
                numbers[1].SetActive(true);
                numbers[2].SetActive(false);
                numbers[3].SetActive(true);
                numbers[4].SetActive(false);
                numbers[5].SetActive(true);
                numbers[6].SetActive(true);
                break;
            case 6:
                numbers[0].SetActive(true);
                numbers[1].SetActive(true);
                numbers[2].SetActive(false);
                numbers[3].SetActive(true);
                numbers[4].SetActive(true);
                numbers[5].SetActive(true);
                numbers[6].SetActive(true);
                break;
            case 7:
                numbers[0].SetActive(true);
                numbers[1].SetActive(false);
                numbers[2].SetActive(true);
                numbers[3].SetActive(false);
                numbers[4].SetActive(false);
                numbers[5].SetActive(true);
                numbers[6].SetActive(false);
                break;
            case 8:
                numbers[0].SetActive(true);
                numbers[1].SetActive(true);
                numbers[2].SetActive(true);
                numbers[3].SetActive(true);
                numbers[4].SetActive(true);
                numbers[5].SetActive(true);
                numbers[6].SetActive(true);
                break;
            case 9:
                numbers[0].SetActive(true);
                numbers[1].SetActive(true);
                numbers[2].SetActive(true);
                numbers[3].SetActive(true);
                numbers[4].SetActive(false);
                numbers[5].SetActive(true);
                numbers[6].SetActive(true);
                break;
        }
    }
}
