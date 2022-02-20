using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

    public int MaxPlayerHealth;

    public int PlayerHealth; // every 2 points of health is one heart
    public int TurtleShells;

    [SerializeField] private Image[] hearts;

    public Sprite FullHealth, MidHealth, NoHealth, ShellHealth;

    // Start is called before the first frame update
    private void Start() {
        GameObject[] Damagers = GameObject.FindGameObjectsWithTag("DamagingObject");
        foreach (var obj in Damagers) {
            DamageCollision collisionScript = obj.GetComponent<DamageCollision>();
            if (collisionScript != null) {
                collisionScript._healthController = this;
            }
            BagCollision bagCollisionScript = obj.GetComponent<BagCollision>();
            if (bagCollisionScript != null) {
                bagCollisionScript._healthController = this;
            }
            OilCollision oilCollisionScript = obj.GetComponent<OilCollision>();
            if (oilCollisionScript != null) {
                oilCollisionScript._healthController = this;
            }
            ElectronicCollision electricalCollisionScript = obj.GetComponent<ElectronicCollision>();
            if (electricalCollisionScript != null) {
                electricalCollisionScript._healthController = this;
            }
        }

        GameObject[] Healers = GameObject.FindGameObjectsWithTag("HealingObject");
        foreach (var obj in Healers) {
            HealCollision collisionScript = obj.GetComponent<HealCollision>();
            if (collisionScript != null) {
                collisionScript._healthController = this;
            }
        }

        PlayerHealth = MaxPlayerHealth;
        TurtleShells = PlayerHealth/2;
        UpdateHealth();
    }

    // UpdateHealth is called whenever the displayed hearts need to change
    private void UpdateHealth() {
        for (int i=0; i<hearts.Length; i++) {
            if (PlayerHealth >= (i+1)*2) {
                if (TurtleShells > i) {
                    hearts[i].sprite = ShellHealth;
                } else {
                    hearts[i].sprite = FullHealth;
                }
            } else if (PlayerHealth > i*2) {
                hearts[i].sprite = MidHealth;
            } else {
                hearts[i].sprite = NoHealth;
            }
        }

        if (PlayerHealth <= 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // DoDamage is called whenever the player should be damaged
    public void DoDamage(int dmg) {
        for (int i=0; i<dmg; i++) {
            if (TurtleShells*2 >= PlayerHealth) {
                TurtleShells -= 1;
            } else {
                PlayerHealth -= 1;
            }
        }
        UpdateHealth();
    }

    public void Heal(int heal) {
        PlayerHealth += heal;
        if (PlayerHealth > MaxPlayerHealth) {
            PlayerHealth = MaxPlayerHealth;
        }
        TurtleShells = PlayerHealth/2;

        UpdateHealth();
    }
}
