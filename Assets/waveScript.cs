using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveScript : MonoBehaviour
{
    public GameObject rightHand;
    public float hauteur = 1.5f;
    public float largeur = 1;
    private TMPro.TextMeshProUGUI dialogArea;
    public GameObject textDialog;
    private Vector3 rightVector;
    public bool testUI = false;
    private float beforeZ = 0;
    private float timeSpent = 0;

    // Start is called before thefirst frame update
    void Start()
    {
          rightVector = rightHand.transform.position;
          dialogArea = textDialog.GetComponent<TMPro.TextMeshProUGUI>();
         beforeZ = rightVector.z;
    }


    // Update is called once per frame
    void Update()
    {

         timeSpent+= Time.deltaTime;
        if( timeSpent >= 1) // each second
        {
            rightVector = rightHand.transform.position;
            if (rightVector.y > 1.3) // hand 
            {
                if (Math.Abs(rightVector.z - beforeZ) > 0.2f) // each frame
                {

                    dialogArea.text = " il a salué gros connnnn";


                }
                beforeZ = rightVector.z;
            }
            timeSpent = 0;
        }

      
 
       
        
    }
}
