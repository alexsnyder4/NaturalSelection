using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public void ChangeColorBlack()
    {
        Color fuckyou = new Color(10f, 10f, 10f);
        obj.GetComponent<SpriteRenderer>().color = Color.black;
    }
    public void ChangeColorWhite()
    {
        Color fuckyou2 = new Color(234f, 234f, 234f);
        obj.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
