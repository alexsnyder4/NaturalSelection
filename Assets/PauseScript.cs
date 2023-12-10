using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
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
    
    public void TogglePlay()
    {
        gameState.SimStarted = true;
        StartCoroutine(SpawnStartTimer(1f));

    }
    IEnumerator SpawnStartTimer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameState.isSpawning = true;
    }

    public void EndSim()
    {
        gameState.SimStarted = false;
    }
}
