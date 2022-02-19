using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MainControl : MonoBehaviour
{

    public Vector2 speed = new Vector2(20, 20);

    // Update is called once per frame
    void Update() {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        GameObject Tsprite = GameObject.Find("TurtleSprite");
        SpriteRenderer sr = Tsprite.GetComponent<SpriteRenderer>();
        if (inputX < 0) {
            sr.flipX = false;
        } else {
            sr.flipX = true;
        }
        Vector3 Movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

        Movement *= Time.deltaTime;

        transform.Translate(Movement);
    }
}
