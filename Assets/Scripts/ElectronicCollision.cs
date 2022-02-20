using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronicCollision : MonoBehaviour {
    [SerializeField] private int damage;
    public HealthController _healthController;

    public MovementController player;
    public Rigidbody2D playerBody;

    private void Start() {
        player = GameObject.Find("TurtleObject").GetComponent<MovementController>();
        playerBody = GameObject.Find("TurtleObject").GetComponent<Rigidbody2D>();
    }

    private IEnumerator ShowLightningBolts() {
        foreach (Transform bolt in transform) {
            bolt.GetComponent<SpriteRenderer>().enabled = true;
        }
        yield return new WaitForSeconds(0.3f);
        foreach (Transform bolt in transform) {
            bolt.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private IEnumerator OnTriggerEnter2D(Collider2D Collision) {
        if (Collision.CompareTag("Player")) {
            _healthController.DoDamage(damage);
            Vector2 prevPlayer = player.speed;
            player.speed = new Vector2(0, 0);
            player.rebound();
            GameObject playerImage = Collision.gameObject.transform.Find("TurtleSprite").gameObject;
            StartCoroutine(playerImage.GetComponent<PlayerColourController>().ApplyStun(1f));
            StartCoroutine(ShowLightningBolts());
            yield return new WaitForSeconds(1f);
            player.speed = prevPlayer;
        }
    }
}
