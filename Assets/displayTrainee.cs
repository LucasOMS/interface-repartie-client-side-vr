using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class displayTrainee : MonoBehaviour
{
    // Start is called before the first frame update
    private OVRGrabbable ovr;
    public GameObject clueGrabbable;
    public float triggerDialog;
    private SocketIOComponent socket;
    public bool test = false; // testing purpose 
    private  bool justTriggerOnce = true;


    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

       // displayNearTheClue();

    }


    private void displayNearTheClue()
    {
      //  this.transform.position = new Vector3(-29.23F, 0.14F, 2.04F);
        float distance = Vector3.Distance(this.transform.position, clueGrabbable.transform.position);
        if (justTriggerOnce)
        {
            Debug.Log("on lance le son une fois ");
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play(0);
            justTriggerOnce = false;
        }
       


    }
}
