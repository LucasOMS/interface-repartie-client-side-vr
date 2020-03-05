using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class indiceDisplayer : MonoBehaviour
{

    private OVRGrabbable ovr;
    public GameObject clueGrabbable;
    public float triggerDialog;
    private SocketIOComponent socket;
    public bool test = false;
    private TMPro.TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Start()
    {

        ovr = clueGrabbable.GetComponent<OVRGrabbable>();
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        textMesh = this.gameObject.GetComponent<TMPro.TextMeshProUGUI>();
      

    }

    // Update is called once per frame
    void Update()
    {
        
        if (ovr.isGrabbed ||  test )
        {
           

                textMesh.text = "Loading";
                Debug.Log("on a trigger quelque chose");
                Debug.Log("on envoie une notification qu'on a attrapé l'indice");
         
              

            
        }
        
    }
}

