using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameState gameState;

    public Slider BB;
    public Slider Bb;
    public Slider bb;
    // Start is called before the first frame update
    void Start()
    {
        gameState.SimStarted = false;
        gameState.currGen = 1;
        gameState.numBugs = 0;
        gameState.isSpawning = false;
        gameState.calledOnce = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameState.BB = BB.value;
        gameState.Bb = Bb.value;
        gameState.bb = bb.value;
    }
}
