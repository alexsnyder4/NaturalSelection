using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SlowSpeed()
    {
        if (!gameState.SimStarted)
        {
            gameState.speed = 1.5f;
        }
        
    }

    public void FastSpeed()
    {
        if (!gameState.SimStarted)
        {
            gameState.speed = 3f;
        }
    }

}
