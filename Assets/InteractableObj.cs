using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour
{
    public GameManager gManager;
    public GameObject light;
    public GameObject Obstacle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player2")
        {
            light.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Keypad1)){
                gManager.P2_ready = true;
                gManager.changeCameraView(collision.gameObject.GetComponent<PlayerMovement>());
                Obstacle.SetActive(false) ;
            }
            
        }
    }
}
