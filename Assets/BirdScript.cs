using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicManagerScript logic;
    public bool birdIsAlive = true;
    public AudioSource goingUp;
    public ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        GameObject logicObject = GameObject.FindGameObjectWithTag("Logic");
        if (logicObject != null)
        {
            logic = logicObject.GetComponent<LogicManagerScript>();
        }
        else
        {
            Debug.LogError("LogicManagerScript not found. Make sure you have a GameObject with the tag 'Logic' in the scene.");
        }

        particleSystem.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (birdIsAlive == true)
        {
            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                myRigidbody.velocity = Vector2.up*flapStrength;
                goingUp.Play();
            }
        }
        

    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive=false;
    }

    void OnBecameInvisible()
    {
        logic.gameOver();
        birdIsAlive=false;
    }
}
