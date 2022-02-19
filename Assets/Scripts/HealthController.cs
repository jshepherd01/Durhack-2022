using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

    public int PlayerHealth; // every 2 points of health is one heart
    public int TurtleShells;

    [SerializeField] private Image[] hearts;

    public Sprite FullHealth, MidHealth, NoHealth, ShellHealth;

    // Start is called before the first frame update
    private void Start() {
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
}
