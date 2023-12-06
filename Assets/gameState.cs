using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;
[CreateAssetMenu(fileName = "GameState", menuName = "State/NaturalSelection")]
public class gameState : ScriptableObject
{
    [SerializeField]
    public int numBugs { get; set; }
}
