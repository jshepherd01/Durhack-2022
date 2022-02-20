using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilDrumFall : MonoBehaviour
{
    private bool isMoving = false;
    private float UnitsPerSecond = 2f;
    private GameObject player;

    void Start() {
        player = GameObject.Find("TurtleObject");
    }

    void Update() {
        if (!isMoving && transform.position.x - player.transform.position.x <= 4) {
            isMoving = true;
        }

        if (isMoving && transform.position.y >= -2.7) {
            transform.Translate(new Vector3(0, - UnitsPerSecond * Time.deltaTime, 0));
        }
    }
}
