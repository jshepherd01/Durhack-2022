using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckpointPos;

    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
    }

    public int decrement = 60;
    void Update() {
        if(decrement == 0){
            decrement = 60;
        } else {
            decrement--;
        }
        
    }
}
