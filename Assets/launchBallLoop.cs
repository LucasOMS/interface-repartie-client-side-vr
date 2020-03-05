using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchBallLoop : MonoBehaviour
{

    public GameObject myPrefab;
    private GameObject myNewPrefab;

    void OntriggerEnter(Collider other)
    {
        Debug.Log("on est la OntriggerEnter");
        Destroy(myNewPrefab);
        myNewPrefab = Instantiate(myPrefab, new Vector3(-0.00183785f, 0.27f, 41.40639f), Quaternion.identity);
        myNewPrefab.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 500));



    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("on est la OnCollisionEnter");
    }

    // Start is called before the first frame update
    void Start()
    {


       // myPrefab.AddComponent<Rigidbody>();
        myNewPrefab =  Instantiate(myPrefab, new Vector3(-0.00183785f, 0.27f, 41.40639f), Quaternion.identity);
        myNewPrefab.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 500));
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
}
