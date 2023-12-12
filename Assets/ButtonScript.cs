using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    GameState gameState;
    [SerializeField]
    GameObject[] killZones;
    [SerializeField]
    Button fastButton;
    [SerializeField]
    Button slowButton;
    
    [SerializeField]
    Button manyButton;
    [SerializeField]
    Button fewButton;
    [SerializeField]
    Button randomButton;
    [SerializeField]
    Button linearButton;
    [SerializeField]
    Slider slider1;
    [SerializeField]
    Slider slider2;
    [SerializeField]
    Slider slider3;

    [SerializeField]
    TMP_Text currBB;
    [SerializeField]
    TMP_Text currBb;
    [SerializeField]
    TMP_Text currbb;

    // Start is called before the first frame update
    void Start()
    {
        currBB.text = "Current BB: " + gameState.currentDom;
        currBb.text = "Current Bb: " + gameState.currentMid;
        currbb.text = "Current bb: " + gameState.currentSub;
    }

    // Update is called once per frame
    void Update()
    {
        currBB.text = "Current BB: " + gameState.currentDom;
        currBb.text = "Current Bb: " + gameState.currentMid;
        currbb.text = "Current bb: " + gameState.currentSub;
    }


    public void SlowSpeed()
    {
        if (!gameState.SimStarted)
        {
            gameState.speed = 1.5f;
            
            ColorBlock cb = slowButton.colors;
            cb.normalColor = Color.gray;
            slowButton.colors = cb;

            ColorBlock cbb = fastButton.colors;
            cbb.normalColor = Color.white;
            fastButton.colors = cbb;
        }
        
    }

    public void FastSpeed()
    {
        if (!gameState.SimStarted)
        {
            gameState.speed = 3f;

            ColorBlock cb = fastButton.colors;
            cb.normalColor = Color.gray;
            fastButton.colors = cb;

            ColorBlock cbb = slowButton.colors;
            cbb.normalColor = Color.white;
            slowButton.colors = cbb;
        }
    }
    public void RandomMovement()
    {
        if (!gameState.SimStarted)
        {
            gameState.movementType = true;
            ColorBlock cb = randomButton.colors;
            cb.normalColor = Color.gray;
            randomButton.colors = cb;

            ColorBlock cbb = linearButton.colors;
            cbb.normalColor = Color.white;
            linearButton.colors = cbb;
        }
    }
    public void LinearMovement()
    {
        if (!gameState.SimStarted)
        {
            gameState.movementType = false;
            
            ColorBlock cb = linearButton.colors;
            cb.normalColor = Color.gray;
            linearButton.colors = cb;

            ColorBlock cbb = randomButton.colors;
            cbb.normalColor = Color.white;
            randomButton.colors = cbb;
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
            ColorBlock cb = fewButton.colors;
            cb.normalColor = Color.gray;
            fewButton.colors = cb;

            ColorBlock cbb = manyButton.colors;
            cbb.normalColor = Color.white;
            manyButton.colors = cbb;
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
            ColorBlock cb = manyButton.colors;
            cb.normalColor = Color.gray;
            manyButton.colors = cb;

            ColorBlock cbb = fewButton.colors;
            cbb.normalColor = Color.white;
            fewButton.colors = cbb;
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
