using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    // Start is called before the first frame update
    internal int score = 0;
    public int jumpCount = 0;
    public GameObject youWinScreen;
    public GameObject MovableObject;
    public GameObject cameraP1;
    public GameObject cameraP2;
    public List<GameObject> gems;
    public bool P1_ready = false;
    public bool P2_ready = false;
    void Start()
    {
        youWinScreen.SetActive(false); ;
    }

    // Update is called once per frame
    void Update()
    {
        if(P1_ready && P2_ready)
        {
            youWinScreen.SetActive(true);
            Time.timeScale = 0;
        }
        if(score >= 4)
        {
            MovableObject.layer = 3;
        }
        
    }
    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void changeCameraView(PlayerMovement player)
    {
        if(player.curPlayer == PlayerMovement.players.player1)
        {
            cameraP1.SetActive(false);
            cameraP2.SetActive(true) ;
        }
        else
        {
            cameraP1.SetActive(true);
            cameraP2.SetActive(false);
        }
    }
}
