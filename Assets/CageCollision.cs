using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CageCollision : MonoBehaviour
{
    public Sprite opened;

    private IEnumerator OnTriggerEnter2D(Collider2D Collision) {
        if (Collision.CompareTag("Player")) {
            GetComponent<SpriteRenderer>().sprite = opened;
            Collision.gameObject.GetComponent<MovementController>().speed = Vector2.zero;
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("Congrats");
        }
    }
}
