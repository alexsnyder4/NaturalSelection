using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;
[CreateAssetMenu(fileName = "GameState", menuName = "State/NaturalSelection")]
public class GameState : ScriptableObject
{
  
    public int numBugs = 0;
    public int startBugs = 0;
    public float BB = 0;
    public float Bb = 0;
    public float bb = 0;
    public int currGen = 1;
    public bool SimStarted = false;
    public bool isSpawning = false;
    public int calledOnce = 0;
    public float speed = 1.5f;
     


}
