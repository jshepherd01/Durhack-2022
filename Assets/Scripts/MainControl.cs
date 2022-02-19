using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControl : MonoBehaviour
{

    public Vector2 speed = new Vector2(2, 2);

    // Update is called once per frame
    void Update() {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 Movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        Movement *= Time.deltaTime;

        transform.Translate(Movement);
    }
}
