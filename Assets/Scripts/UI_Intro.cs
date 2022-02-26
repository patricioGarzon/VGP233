using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Intro : MonoBehaviour
{
    public float PresetTime = 1;
    float TimebetweenChanges = 0;
    public GameObject StartText;
    public GameObject StartScreen;
    public GameObject InstructionsScreen;
    public AudioSource ButtonClick;
    // Start is called before the first frame update
    void Start()
    {
        TimebetweenChanges = PresetTime;
    }

    // Update is called once per frame
    void Update()
    {
        TimebetweenChanges -= Time.deltaTime;
        if(TimebetweenChanges <= 0)
        {
            TimebetweenChanges = PresetTime;
            StartText.SetActive(!StartText.active);

        }
    }
    public void onStartClick()
    {
        StartScreen.SetActive(false);
        InstructionsScreen.SetActive(true);
        ButtonClick.Play();
    }
    public void onStartGame()
    {
        ButtonClick.Play();
        Application.LoadLevel("Game");
    }
}
