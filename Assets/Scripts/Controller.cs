using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class Controller : MonoBehaviour
{
    public int Point = 0;
    GameObject myObj;
    GameObject controller;
    bool isEndGame;

    public GameObject panelEndGame;
    public UnityEngine.UI.Button btnRestart;

    public Sprite btnIdle;
    public Sprite btnHover;
    public Sprite btnClick;

    public Text TextPoint;
    public Text TextNotation;
    // Start is called before the first frame update
    void Start()
    {
        Point = 0;
        isEndGame = false;
        myObj = GameObject.FindGameObjectWithTag("Player");
        controller = gameObject;
        panelEndGame.SetActive(false);
        Time.timeScale = 1;
        TextPoint.text = "Point: 0 ";
        
    }

    // Update is called once per frame
    
    void Update()
    {
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void GetPoint()
    {
        Point++;
        TextPoint.text = "Point: " + Point.ToString();
    }
    public void Idle()
    {
        btnRestart.GetComponent<Image>().sprite = btnIdle;
    }
    public void Hover()
    {
        btnRestart.GetComponent<Image>().sprite = btnHover;
    }
    public void Enter()
    {
        btnRestart.GetComponent<Image>().sprite = btnClick;
    }
    public void EndGame()
    {
        TextNotation.text = "Your Scoure: \n" + Point.ToString();
        isEndGame = true;
        Time.timeScale = 0;
        controller.GetComponent<AudioSource>().Stop();
        panelEndGame.SetActive(true);
    }
}
