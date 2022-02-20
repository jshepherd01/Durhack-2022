using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public Vector2 speed = new Vector2(2, 2);
    public int reboundTime = 0;
    public Vector3 ReboundMove;
    public Vector3 Movement;

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

        Vector2 SpritePosition = transform.position;

        if (SpritePosition.y <= -4 && inputY < 0) {
            Movement = new Vector3(speed.x * inputX, 0, 0);
        } else if (SpritePosition.y >= 4 && inputY > 0) {
            Movement = new Vector3(speed.x * inputX, 0, 0);
        } else {
            Movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);
        }

        if (reboundTime > 0) {
            reboundTime -= 1;
            Movement += ReboundMove;
        }

        Movement *= Time.deltaTime;

        transform.Translate(Movement);
    }

    public void rebound() {
        ReboundMove = Movement * -500f;
        reboundTime = 15;
        // transform.Translate(Movement * -50f);
    }

}
