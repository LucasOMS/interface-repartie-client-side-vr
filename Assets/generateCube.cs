using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateCube : MonoBehaviour
{
    public GameObject generatedBalls;

    public void DoStuff()
    {
        float changeOnLeft = 0;
        for (int i = 0; i< 10; i++)
        {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Cube);
            sphere.AddComponent(typeof(BoxCollider));
            sphere.AddComponent(typeof(Rigidbody));
            sphere.AddComponent(typeof(OVRGrabbable));

             changeOnLeft += (float)i;
            sphere.transform.position = new Vector3(changeOnLeft    , 1.87f, 1.84f);
        }
      
    }
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
