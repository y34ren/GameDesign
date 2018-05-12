using UnityEngine;
using System.Collections;

public class ShackCamera : MonoBehaviour {

    private bool isShack = false;
    private int timer = 0;

    // Update is called once per frame
    void Update() {
        if (isShack)
            Shack();
    }

    public void setShack() {
        isShack = true;
        timer = 0;
    }

    void Shack() {
        if (timer++ % 3 == 0) {
            float x = Random.Range(-0.15f, 0.15f);
            float y = Random.Range(-0.15f, 0.15f);
            transform.localPosition = new Vector3(x, y, 0f);
        }
        if (timer > 15) {
            isShack = false;
            transform.localPosition = Vector3.zero;
            timer = 0;
        }
    }
}
