using SocketIO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class setup_environnement : MonoBehaviour
{

    // main object
    public GameObject player;
    public GameObject clue;
    public GameObject dialog;
    public GameObject textDialog;
    public GameObject trainee;
    public GameObject bottleOfWater;
    public float distance;



    public GameObject rightHand;
    public float hauteur = 1.5f;
    public float largeur = 1;
    private float timeSpent = 0;
    private Vector3 rightVector;
    public bool testUI = false;
    private float beforeZ = 0;
    private bool triggerOnceWave = false ;

    private  bool displayDialog = false;




    public bool testGrab = false;
    private OVRGrabbable ovr;
    private TMPro.TextMeshProUGUI dialogArea;
    OVRGrabbable grabbable;
    private SocketIOComponent socket;


    // Start is called before the first frame update
    void Start()
    {
        ovr = clue.GetComponent<OVRGrabbable>();
        player.transform.position = PlayerStats.Position;
        dialogArea = textDialog.GetComponent<TMPro.TextMeshProUGUI>();


        grabbable = bottleOfWater.GetComponent<OVRGrabbable>();

        
        rightVector = rightHand.transform.position;
        dialogArea = textDialog.GetComponent<TMPro.TextMeshProUGUI>();
        beforeZ = rightVector.z;

        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();




    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(bottleOfWater.transform.rotation.eulerAngles.x);
        Debug.Log(270.0f < bottleOfWater.transform.rotation.eulerAngles.x
        && bottleOfWater.transform.rotation.eulerAngles.x < 300.0f);

        if ( OVRInput.Get(OVRInput.RawButton.X) )
        {
            SceneManager.LoadScene("firstScene", LoadSceneMode.Single);
        }


        scenarioClue();
        scenarioTrainee();
        scenarioBottle();
        dialog.SetActive(displayDialog);







    }

    private void scenarioClue()
    {

       // Debug.Log(player.transform.position);
        float distance = Vector3.Distance(player.transform.position, clue.transform.position);
        if (distance < this.distance)
        {
            //dialog.SetActive(true);
            displayDialog = true;
          

            // logic of the project 
            if (ovr.isGrabbed || testGrab)
            {
                //   dialog.SetActive(true);
                PlayerStats.HaveClue = true;
                dialogArea.text = "On dirait que l'arbitre a rendu un gros service";
            }
            else
            {
                dialogArea.text = "Hmm une note sur le banc";
            }
        }
        else
        {
          //  displayDialog = false;
          //  dialog.SetActive(false);
        }
           
    }

    private void scenarioBottle()
    {

         float distance = Vector3.Distance(player.transform.position, bottleOfWater.transform.position);
        if (distance < this.distance)
        {
            displayDialog = true;
           // dialog.SetActive(true);
            if (!grabbable.isGrabbed)
            {
               
                
                 dialogArea.text = "Hmm l'eau serait-elle dopée ?";
                
            }
            else
            {

                if (checkDrink())
                {
                    dialogArea.text = "Glouglouglou, l'eau ne semble pas dopée";
                }
                else
                {

                    dialogArea.text = "Goûtons la pour voir";
                }
            }


            // essayons de boire l'eau 

        }
        else
        {
           // displayDialog = false;
        }
      
    }
   

    private void scenarioTrainee()
    {
        float distance = Vector3.Distance(player.transform.position, trainee.transform.position); // trainee distance
      //  Debug.Log(distance);
        if (PlayerStats.HaveClue && distance < this.distance) // on a l'indice on est proche de l'entraineur
        {
            //  dialog.SetActive(true);

            displayDialog = true;
            if (checkWave() || triggerOnceWave )
            {
                dialogArea.text = "Moi : Bonjour, on dirait que vous avez été acheté !! \n" +
                    "Lui : Moi ? Acheté ? Mais non ! Nos enfants sont dans la même école " +
                    "et il était dans l'incapacité de venir chercher les siens l'autre jour !!";
                socket.Emit("END_TALK", new JSONObject());
                triggerOnceWave = true;
            }
            else
            {
                dialogArea.text = "Saluer avec votre main droite l'entraineur";
            }
        }
        else if (!PlayerStats.HaveClue && distance < this.distance) // on est proche de l'entraineur mais on a pas l'indice
        {

            displayDialog = true;
          //  dialog.SetActive(true);
            dialogArea.text = "Lui : je n'ai rien à vous dire pour l'instant";
        }
        else
        {
            //displayDialog = false;
          //  dialog.SetActive(false);
            // do not display 
        }
    }

    private bool checkDrink() => 270.0f < bottleOfWater.transform.rotation.eulerAngles.x
        && bottleOfWater.transform.rotation.eulerAngles.x < 300.0f;

    private bool checkWave()
    {

        timeSpent += Time.deltaTime;
        if (timeSpent >= 1) // each second
        {
            rightVector = rightHand.transform.position;
            if (rightVector.y > 1.4) // hand 
            {
                if (Math.Abs(rightVector.z - beforeZ) > 0.2f) // each frame
                {

                    return true;


                }
                beforeZ = rightVector.z;
            }
            timeSpent = 0;
        }
        return false;
    }
}
