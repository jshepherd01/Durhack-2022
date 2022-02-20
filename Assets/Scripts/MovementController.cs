using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public Vector2 speed = new Vector2(2, 2);
    public double reboundTime = 0;
    public Vector3 LastMove;
    public Vector3 ReboundMove;
    public Vector3 Movement;

    public Material material;

    public Vector2 offset;

    private void Awake() {
        //material = GameObject.Find("Quad").GetComponent<Renderer>().material;
    }

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

        if (transform.position.y <= -4) {
            transform.position = new Vector3(transform.position.x, -4, 0);
        }
        if (transform.position.y >= 4) {
            transform.position = new Vector3(transform.position.x, 4, 0);
        }

        Movement = new Vector3(speed.x * inputX, ((transform.position.y <= -4 && inputY < 0) || (transform.position.y >= 4 && inputY > 0)) ? 0 : speed.y * inputY, 0);

        LastMove = Movement * 1f;

        if (reboundTime > 0) {
            if (reboundTime >= Time.deltaTime) {
                Movement += ReboundMove;
                reboundTime -= Time.deltaTime;
            } else {
                Movement += ReboundMove * (float)(reboundTime / Time.deltaTime);
                reboundTime = 0;
            }
        }

        Movement *= Time.deltaTime;

        //material.mainTextureOffset += new Vector2 (Movement.x/6, 0);

        transform.Translate(Movement);
    }

    public void rebound() {
        ReboundMove = LastMove * -5f;
        reboundTime = 0.1;
    }

}
