using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class generatedText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = new GameObject("Child");
        gameObject.transform.SetParent(this.transform);
        

        gameObject.AddComponent<Text>().text = "Hello This is Child";
        gameObject.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
