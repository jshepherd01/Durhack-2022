using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oilfrombarrel : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y > 6) {
            Destroy(this.gameObject);
        }
    }
}
