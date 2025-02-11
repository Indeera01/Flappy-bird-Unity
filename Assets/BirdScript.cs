using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public logicScript logic;
    public bool isBirdAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) == true && isBirdAlive == true)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        if (transform.position.y == 11 || transform.position.y == -11)
        {
            logic.gameOver();
            isBirdAlive = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) == true)
        {
            logic.closeGame();  
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        isBirdAlive = false;
    }
}
