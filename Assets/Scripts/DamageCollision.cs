using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollision : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private bool vanish;
    public HealthController _healthController;
    public Sprite transparent;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D Collision) {
        if (Collision.CompareTag("Player")) {
            _healthController.DoDamage(damage);
            player = Collision.gameObject.transform.Find("TurtleSprite").gameObject;
            StartCoroutine(player.GetComponent<PlayerColourController>().ApplyTempColor(Color.red));
            if (vanish) {
                GetComponent<SpriteRenderer>().sprite = transparent;
                GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }
}
