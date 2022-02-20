using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Transform player, camera;
    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("TurtleObject").GetComponent<Transform>();
        camera = GameObject.Find("Main Camera").GetComponent<Transform>();
        var position = camera.position;
        position.x = player.position.x;
        camera.position = position;
    }
}
