using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StepsFill : MonoBehaviour
{
    [SerializeField]
    Button button;
    [SerializeField]
    GameState gameState;
    [SerializeField]
    TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        button.GetComponent<Image>().fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState.SimStarted)
        {
            button.GetComponent<Image>().fillAmount += .005f;
            if (button.GetComponent<Image>().fillAmount == 1)
            {
                gameState.currGen++;
                button.GetComponent<Image>().fillAmount = 0;
                text.text = gameState.currGen.ToString();
            }
        }
    }
}
