using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleporttostart : MonoBehaviour
{
    public GameObject GroundObject2;

    public Vector3 newPosition;
 
    public float offsetX;
    
    private float OtherSpritePositionX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnBecameInvisible()
    {
        Debug.Log("Is invisible");
        
        // transform.position = GroundObject2.transform.position;
        // transform.position.x = transform.position.x + 10.25059f;

        
        OtherSpritePositionX = GroundObject2.transform.position.x;
 
        //10.25059f
        newPosition.x = OtherSpritePositionX + offsetX;
        newPosition.y = transform.position.y;
        newPosition.z = transform.position.z;
 
 
        transform.position = newPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
