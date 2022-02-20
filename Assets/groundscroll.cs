using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundscroll : MonoBehaviour
{

    public Rigidbody2D turtle;
    public Vector3 Movement;

    Material material;

    Vector2 offset;

    public int xVelocity, yVelocity;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        offset = new Vector2(inputX,0);
        material.mainTextureOffset += offset * Time.deltaTime;
        
    }
}