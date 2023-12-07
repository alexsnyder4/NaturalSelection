using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StepsFill : MonoBehaviour
{
    [SerializeField]
    Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.GetComponent<Image>().fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        button.GetComponent<Image>().fillAmount += .0005f;
        if (button.GetComponent<Image>().fillAmount == 1)
        {
            button.GetComponent<Image>().fillAmount = 0;
        }
    }
}
