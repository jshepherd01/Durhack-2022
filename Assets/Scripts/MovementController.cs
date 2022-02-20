using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour {

    public Vector2 speed = new Vector2(2, 2);
    public double reboundTime = 0;
    public Vector3 LastMove;
    public Vector3 ReboundMove;
    public Vector3 Movement;
    private GameMaster gm;

    private bool dead;

    public Material material;
    public Sprite newSprite;

    public Vector2 offset;

    private void Awake() {
        dead = false;
        //material = GameObject.Find("Quad").GetComponent<Renderer>().material;
    }

    private void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastCheckpointPos;
    }

    // Update is called once per frame
    void Update() {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        GameObject Tsprite = GameObject.Find("TurtleSprite");
        SpriteRenderer sr = Tsprite.GetComponent<SpriteRenderer>();
        if(dead != true){
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

        } else {
             GameObject.Find("TurtleSprite").GetComponent<Animator>().enabled = false;
            sr.sprite = newSprite;
            Movement = new Vector3 (0,-1,0);
            Movement *= Time.deltaTime;
            transform.Translate(Movement);
            if(transform.position.y <= -4){
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void rebound() {
        ReboundMove = LastMove * -5f;
        reboundTime = 0.1;
    }

    public void die(){
        dead = true;
        GameObject Tsprite = GameObject.Find("TurtleSprite");
        SpriteRenderer sr = Tsprite.GetComponent<SpriteRenderer>();
        sr.sprite = newSprite; 
    }
    public void bounce(Vector3 Direction) {
        ReboundMove = Direction * 5f;
        reboundTime = 0.1;
    }

    public void Reload() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
