using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    private int bobTime;
    private int count = 0;
    private float direction = 0.0005f;

    private void Start() {
        bobTime = Random.Range(200,300);
    }

    // Update is called once per frame
    private void Update() {
        if(count < bobTime) {
            this.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + direction);
            count++;
        } else {
            direction *= -1;
            count = 0;
        }
    }
}
