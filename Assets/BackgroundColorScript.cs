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
        Color fuckyou = new Color(.1f, .1f, .1f, 1f);
        obj.GetComponent<SpriteRenderer>().color = fuckyou;
    }
    public void ChangeColorWhite()
    {
        Color fuckyou2 = new Color(.9f, .9f, .9f, 1f);
        obj.GetComponent<SpriteRenderer>().color = fuckyou2;
    }
}
