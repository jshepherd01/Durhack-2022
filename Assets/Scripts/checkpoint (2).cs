using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour {
    public GameObject Player;
    private void OnTriggerEnter2D(Collider2D Collision) {
        if (Collision.CompareTag("Player")) {
            //GameObject.Find("TurtleObject").GetComponent<MovementController>().checkpointLocal = gameObject.transform.position;
        }
    }
}
