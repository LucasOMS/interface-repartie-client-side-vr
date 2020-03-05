using SocketIO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class readEvent : MonoBehaviour
{
    private SocketIOComponent socket;
    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;
    public GameObject footTerrain;
    public bool loadScene = false;
  
    // Start is called before the first frame update
    void Start()
    {
      
        GameObject go = GameObject.Find("SocketIO");
        socket = go.GetComponent<SocketIOComponent>();
        socket.On("EXPLORE_PLACE", launchScene);
        if (!PlayerStats.isAlreadySent)
        {
            footTerrain.SetActive(false);
        }

    }
    public void launchScene(SocketIOEvent e)
    {
        //  SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        footTerrain.SetActive(true);
        PlayerStats.isAlreadySent = true;
    }


    public void forceDisplayOtherScene(float vol)
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }



    public void  displayForClue(float v)
    {
        if (v == 1)
            PlayerStats.Position = new Vector3(-30.5f, 1.0F, -10.8f);
        else if (v == 3)
            PlayerStats.Position = new Vector3(25.5f, 1.0f, 12.8f);
        else if (v == 2)
            PlayerStats.Position = new Vector3(-7.5f, 1.0f, 36.1f);

        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
    // Update is called once per frame
    void Update()
    {
        if (loadScene)
        {
            PlayerStats.Position = new Vector3(30, 30, 30);
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);

        }
    }
}
