using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColourController : MonoBehaviour
{
    public GameObject turtle;
    private bool isStunned = false;
    private int last = 0;
    private int lastStun = 0;

    public IEnumerator ApplyTempColor(Color color, float duration = 0.3f) {
        int thisIndex = ++last;

        turtle.GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(duration);

        if (last == thisIndex) {
            if (isStunned) {
                turtle.GetComponent<SpriteRenderer>().color = Color.cyan;
            } else {
                turtle.GetComponent<SpriteRenderer>().color = Color.white;
            }
            last = 0;
        }
    }

    public IEnumerator ApplyStun(float duration) {
        int thisIndex = ++lastStun;

        turtle.GetComponent<SpriteRenderer>().color = Color.cyan;
        isStunned = true;
        yield return new WaitForSeconds(duration);

        if (lastStun == thisIndex) {
            turtle.GetComponent<SpriteRenderer>().color = Color.white;
            lastStun = 0;
            isStunned = false;
        }
    }
}
