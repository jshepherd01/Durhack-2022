using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float timer;
    public GameObject OilFab;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 1.5) {
            //spawn oil add velocity
            Instantiate(OilFab, gameObject.transform.position + new Vector3(0.5f, 0.8f, 0), Quaternion.identity);
            timer = 0;

        }
        
    }
}
