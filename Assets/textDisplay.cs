using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TMPro.TextMeshProUGUI textMesh = this.gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        textMesh.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
