using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grabbedEvent : MonoBehaviour
{
    // Start is called before the first frame update
    OVRGrabbable ovr;
    SocketIOComponent socket;
    public Text text;
    private bool triggerOnce = true;

    void Start()
    {
        ovr = GetComponent<OVRGrabbable>();
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();

    }

    // Update is called once per frame
    void Update()
    {
        if ( ovr.isGrabbed  && triggerOnce)
        {
            Debug.Log("on envoie une notification qu'on a attrapé l'indice");
            Dictionary<string, string> data = new Dictionary<string, string>();
            data["clue_id"] = "1";
            socket.Emit("CLUE_FOUND", new JSONObject(data));
            triggerOnce = false;
       
        }
        
    }
}
