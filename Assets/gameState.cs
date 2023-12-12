using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
[CreateAssetMenu(fileName = "GameState", menuName = "State/NaturalSelection")]
public class GameState : ScriptableObject
{
  
    public int numBugs = 0;
    public int startBugs = 0;
    public float BBDom = 0;
    public int currentDom = 0;
    public int currentMid = 0;
    public int currentSub = 0;
    public float BbMid = 0;
    public float bbSub = 0;
    public int currGen = 1;
    public bool SimStarted = false;
    public bool isSpawning = false;
    public int calledOnce = 0;
    public float speed = 1.5f;
    public bool movementType;
    
}
