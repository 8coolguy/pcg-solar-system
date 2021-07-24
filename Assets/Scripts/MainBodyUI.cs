using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBodyUI : MonoBehaviour
{
    // Start is called before the first frame update
    Text uiInfo;
    void Start()
    {
        uiInfo = this.gameObject.GetComponent<Text>();
        var anchorMin = uiInfo.rectTransform.anchorMin;
        anchorMin = new Vector2(0, 1);
        var anchorMax = uiInfo.rectTransform.anchorMax;
        anchorMax = new Vector2(0, 1);
        uiInfo.alignment = TextAnchor.UpperLeft;
        var rectPos = uiInfo.rectTransform.position;
        rectPos = new Vector3(85,-13,0);
    }


    // Update is called once per frame
    void Update()
    {
        GameObject main = GameObject.FindObjectOfType<MainBody>().gameObject;
      

        
        uiInfo.text = "Current Speed:" + main.transform.GetComponent<Rigidbody>().velocity.magnitude;
        
        uiInfo.color = Color.white;
    }
}
