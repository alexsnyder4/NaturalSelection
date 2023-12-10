using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class InputScript : MonoBehaviour
{
    [SerializeField]
    GameState gameState;
    
    public InputField betInput;
    void Start()
    {
        betInput.onEndEdit.AddListener(delegate { inputBetValue(betInput); });
    }
    public void inputBetValue(InputField userInput)
    {
        gameState.startBugs = int.Parse(userInput.text);
        Debug.Log(userInput.text);
    }
    
}
