using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float throw_speed; //throw force float variable 

    private Rigidbody rb;      
    private GameManager gameManager;
    private Spawner spawner;
    public static bool gameover = false;
    public static bool hasCollided = false;
    // Start is called before the first frame update
    void Start()
    {
        gameover = false;   //making the bools set to false at start
        hasCollided=false;

        rb = GetComponent<Rigidbody>();   // accessing the rigidbody of the knife inorder to throw with forcemode
        spawner =FindObjectOfType<Spawner>();   //accessing the spawner script 
        gameManager=FindObjectOfType<GameManager>();  //accessing the gamemanger script
    }

    // Update is called once per frame
    void Update()
    {
        //knife will be thrown whenever the space bar is pressed down
        if(Input.GetKeyDown(KeyCode.Space))
        {
           rb.AddForce(Vector3.up * throw_speed,ForceMode.Impulse);       
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Log" ) //below funcitons will perform if the knife hits with "log"
        {
            if (!hasCollided)
            {
                hasCollided = true;

                //calling the decrease knife function for text changing
                gameManager.DecreaseKnife();   

                gameObject.transform.SetParent(collision.gameObject.transform);    // setting the parent of the collided knife with the log so it will move with log
         
                //changing its velocity to zero
                rb.velocity = Vector3.zero;

                //changing rigidbody to kinematic
                rb.isKinematic = true;                  

                //Calling the spawn new knife function
                spawner.SpawnKnife();         

                // Disabling the script so this knife wont be able to make any movement when space is pressed again
                enabled = false;
                Debug.Log("Has Collided with log");
            }
        }
        else if(collision.gameObject.tag == "Knife")//below funcitons will perform if the knife hits with another "knife"
        {
            Debug.Log("GameOver");
            //setting the bool to true 
            gameover = true;
            //setting the parent to null so it will fall down
            gameObject.transform.SetParent(null);
            //setting its kinematic state to false 
            rb.isKinematic = false;
            //checking the gravity box to true so it the gravity will affect of this particular knife
            rb.useGravity = true;

            //finally calling the gameover function
            gameManager.Gameover();
            enabled= false;
        }
    }
}
