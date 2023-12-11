using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    GameState gameState;
    [SerializeField]
    GameObject[] killZones;

    [SerializeField]
    Slider slider1;
    [SerializeField]
    Slider slider2;
    [SerializeField]
    Slider slider3;

    
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
    public void RandomMovement()
    {
        if (!gameState.SimStarted)
        {
            gameState.movementType = true;
        }
    }
    public void LinearMovement()
    {
        if (!gameState.SimStarted)
        {
            gameState.movementType = false;
        }
    }
    public void FewKillZones()
    {
        if (!gameState.SimStarted)
        {
            for(int i = 0; i < killZones.Length; i++)
            {
                if(i < 4)
                {
                    killZones[i].GetComponent<Collider2D>().enabled = false;
                    killZones[i].GetComponent<SpriteRenderer>().enabled = false;
                }
                
            }
        }
    }
    public void ManyKillZones()
    {
        if (!gameState.SimStarted)
        {
            for(int i = 0; i < killZones.Length; i++)
            {
                if(i < 4)
                {
                    killZones[i].GetComponent<Collider2D>().enabled = true;
                    killZones[i].GetComponent<SpriteRenderer>().enabled = true;
                }
                
            }
        }
    }

    public void Slider1Value()
    {
        gameState.BBDom = (int)(slider1.value * gameState.startBugs * 10);
    }
    public void Slider2Value()
    {
        gameState.BbMid = (int)(slider2.value * gameState.startBugs * 10);
    }
    public void Slider3Value()
    {
        gameState.bbSub = (int)(slider3.value * gameState.startBugs * 10);
    }
}
