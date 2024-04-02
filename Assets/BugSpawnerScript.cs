using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BugSpawnerScript : MonoBehaviour
{
    [SerializeField] 
    GameState gameState;
    public int currentBugs = 0;
    [SerializeField]
    GameObject bugPrefab;
    public bool matchStarted;
    private int calledOnce = 0;

    float rectangleMinX = -6.727f;
    float rectangleMaxX = 5.251f;
    float rectangleMinY = -2.916f;
    float rectangleMaxY = 3.314f;

    private static bool ballSpawned = false;

    public static bool BallSpawned { get => ballSpawned; }

    public static void SetBallSpawned(bool value)
    {
        ballSpawned = value;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentBugs = gameState.numBugs;
        matchStarted = gameState.SimStarted;
        calledOnce = gameState.calledOnce;

        if (calledOnce < 1 && matchStarted)
        {
            SpawnBugsInitial(gameState.startBugs);
            calledOnce++;
            gameState.calledOnce = calledOnce;
        }
    }

    public void SpawnBugsInitial(int numBugsToSpawn)
    {
        int BBToSpawn = (int)(gameState.startBugs * gameState.BBDom);
        int BbToSpawn = (int)(gameState.startBugs * gameState.BbMid);
        int bbToSpawn = (int)(gameState.startBugs * gameState.bbSub);
        
        for (int i = 0; i < BBToSpawn; i++)
        {
            Vector3 randomPosition = GetRandomPositionInsideRectangle();
            
            string name = bugPrefab.name + "_" + System.Guid.NewGuid().ToString();
            GameObject newBug = Instantiate(bugPrefab, randomPosition, Quaternion.identity);
            newBug.name = name;
            newBug.gameObject.GetComponent<MovementScript>().allele = "BB";
            newBug.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            Debug.Log("After stat BB: " + newBug.gameObject.GetComponent<MovementScript>().allele);
            gameState.numBugs++;
            gameState.currentDom++;
        }
        for (int i = 0; i < BbToSpawn; i++)
        {
            Vector3 randomPosition = GetRandomPositionInsideRectangle();
            
            string name = bugPrefab.name + "_" + System.Guid.NewGuid().ToString();
            GameObject newBug = Instantiate(bugPrefab, randomPosition, Quaternion.identity);
            newBug.name = name;
            newBug.gameObject.GetComponent<MovementScript>().allele = "Bb";
            newBug.gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            Debug.Log("After stat Bb: " + newBug.gameObject.GetComponent<MovementScript>().allele);
            gameState.numBugs++;
            gameState.currentMid++;
        }
        for (int i = 0; i < bbToSpawn; i++)
        {
            Vector3 randomPosition = GetRandomPositionInsideRectangle();

            string name = bugPrefab.name + "_" + System.Guid.NewGuid().ToString();
            GameObject newBug = Instantiate(bugPrefab, randomPosition, Quaternion.identity);
            newBug.name = name;
            newBug.gameObject.GetComponent<MovementScript>().allele = "bb";
            newBug.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            Debug.Log("After stat bb: " + newBug.gameObject.GetComponent<MovementScript>().allele);
            gameState.numBugs++;
            gameState.currentSub++;
        }
    }

  
    

    public Vector3 GetRandomPositionInsideRectangle()
    {
        // Generate a random position
        float randomX = Random.Range(rectangleMinX, rectangleMaxX);
        float randomY = Random.Range(rectangleMinY, rectangleMaxY);
        
        return new Vector3(randomX, randomY, 0f);
    }
    
  

}
