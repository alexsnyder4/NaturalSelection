using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorScript : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ColorChangeWhite()
    {
        obj.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void ColorChangeBlack()
    {
        obj.GetComponent<SpriteRenderer>().color = Color.black;
    }
}
