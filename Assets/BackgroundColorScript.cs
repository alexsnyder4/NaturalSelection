using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundColorScript : MonoBehaviour
{
    public GameObject obj;
    [SerializeField]
    GameState gameState;
    [SerializeField]
    Button whiteButton;
    [SerializeField]
    Button blackButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColorBlack()
    {
        if (!gameState.SimStarted)
        {
            Color fuckyou = new Color(.1f, .1f, .1f, 1f);
            obj.GetComponent<SpriteRenderer>().color = fuckyou;

            ColorBlock cb = whiteButton.colors;
            cb.normalColor = Color.gray;
            whiteButton.colors = cb;

            ColorBlock cbb = blackButton.colors;
            cbb.normalColor = Color.white;
            blackButton.colors = cbb;
        }
    }
    public void ChangeColorWhite()
    {
        if (!gameState.SimStarted)
        {
            Color fuckyou2 = new Color(.9f, .9f, .9f, 1f);
            obj.GetComponent<SpriteRenderer>().color = fuckyou2;

            ColorBlock cb = blackButton.colors;
            cb.normalColor = Color.gray;
            blackButton.colors = cb;

            ColorBlock cbb = whiteButton.colors;
            cbb.normalColor = Color.white;
            whiteButton.colors = cbb;
        }
    }
}
