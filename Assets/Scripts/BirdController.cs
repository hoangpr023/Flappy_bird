using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    GameObject obj;
    GameObject gameController;
    public float FlyForce;
    public AudioClip audioFly;
    public AudioClip audioGameOver;

    Animator anim;

    private AudioSource audioSource;
    bool isEndGame;
    // Start is called before the first frame update
    void Start()
    {
        
        isEndGame = false;
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = audioFly;
        FlyForce = 50;
        if (gameController == null)
            gameController = GameObject.FindGameObjectWithTag("GameController");

        anim = obj.GetComponent<Animator>();
        anim.SetBool("isDead", false);
        anim.SetFloat("flyForce", 0);
    }   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && isEndGame == false)
        {
            audioSource.Play();
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, FlyForce));            
        }
        anim.SetFloat("flyForce", obj.GetComponent<Rigidbody2D>().velocity.y);
    }
    void OnCollisionEnter2D(Collision2D orther)
    {
        
        EndGame();
    }
    void OnTriggerEnter2D(Collider2D orther)
    {
        gameController.GetComponent<Controller>().GetPoint();
    }
    void EndGame()
    {
        anim.SetBool("isDead", true);
        isEndGame = true;
        audioSource.clip = audioGameOver;
        audioSource.Play();
        gameController.GetComponent<Controller>().EndGame();
    }
}
