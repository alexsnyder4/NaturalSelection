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
    float num = 0.005f;
    // Start is called before the first frame update
    void Start()
    {
        button.GetComponent<Image>().fillAmount = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (gameState.SimStarted)
        {
            StartCoroutine(IncreaseFill(num));
            if (button.GetComponent<Image>().fillAmount >= 1)
            {
                num = 0.005f;
                gameState.currGen++;
                button.GetComponent<Image>().fillAmount = 0;
                text.text = gameState.currGen.ToString();
            }
        }
    }

    IEnumerator IncreaseFill(float waitTime)
    {
        button.GetComponent<Image>().fillAmount = num += 0.005f;
        yield return new WaitForSeconds(waitTime);  
        
    }
}
