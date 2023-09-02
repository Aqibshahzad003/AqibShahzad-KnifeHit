using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{

    private int knife;
    public TextMeshProUGUI knifetext;

    public GameObject Gameoverpanel;
    public GameObject GameWinPanel;

    public GameObject spawner;
    public static bool GameWon = false;
    // Start is called before the first frame update
    void Start()
    {
        knife = 5;   //setting the knvies intial value to 5 

        knifetext.text = knife.ToString();
        GameWon = false;
    }

    // Update is called once per frame
    void Update()
    {
     
        if(knife == 0 && !Knife.gameover)   //if the knives are zero and the player did not hit any other knife then perform the below
        {
            //setting the gamewinpanel to true
            GameWinPanel.SetActive(true);  
            //setting the bool to true
            GameWon = true;


            //finding all the GameObjects in hierarchy with tag "Knife" and destroying their knife script 
            GameObject[] knives = GameObject.FindGameObjectsWithTag("Knife");

            foreach (GameObject knifeObject in knives)
            {
                Destroy(knifeObject.GetComponent<Knife>());
            }

        }

    }
    public void DecreaseKnife()
    {
        //decreasing the int value
        knife--;
        //and then coverting it to string to show it on display as text
        knifetext.text = knife.ToString();
    }
    public void Gameover()
    {
        //setting the gameoverpanel to true
        Gameoverpanel.gameObject.SetActive(true);
    }

    public void Restart()  //for restart and play again button
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
