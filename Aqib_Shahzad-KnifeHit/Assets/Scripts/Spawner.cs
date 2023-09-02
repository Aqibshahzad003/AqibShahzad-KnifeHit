using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject knife;


    public void SpawnKnife()
    {
        if (!GameManager.GameWon && !Knife.gameover)  //simply spawning knives using instantiate mathod at given position and rotation with -90 degrees at x axis
        {
            Instantiate(knife, new Vector3(0, 0, -7.5f), Quaternion.Euler(-90, 0, 0));
        }
    }
}
