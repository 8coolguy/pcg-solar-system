using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    // Start is called before the first frame update
    Text timeUI; //= this.gameObject.GetComponent<Text>();
    void Start()
    {
        timeUI = this.gameObject.GetComponent<Text>();
        timeUI.color = Color.white;

    }

    // Update is called once per frame
    void Update()
    {
        timeUI.text = "Time in Solar System: " + Time.fixedTime; 
    }
}
