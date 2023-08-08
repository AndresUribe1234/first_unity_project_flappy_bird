using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicManagerScript logic;
    public BirdScript bird;
    // Start is called before the first frame update
    void Start()
    {
          GameObject logicObject = GameObject.FindGameObjectWithTag("Logic");
          GameObject birdObject = GameObject.FindGameObjectWithTag("Bird");
        if (logicObject != null)
        {
            logic = logicObject.GetComponent<LogicManagerScript>();
        }
        else
        {
            Debug.LogError("LogicManagerScript not found. Make sure you have a GameObject with the tag 'Logic' in the scene.");
        }

        if (birdObject != null)
        {
            bird = birdObject.GetComponent<BirdScript>();
        }
        else
        {
            Debug.LogError("LogicManagerScript not found. Make sure you have a GameObject with the tag 'Logic' in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer ==3 && bird.birdIsAlive)
        {
            logic.addScore(1);
        }
        
    }

    
}
