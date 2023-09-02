using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{
    public float rotationSpeed;
    private Rigidbody logRigidbody;

    private bool isReversing=false;  //making a bool variable for rotation changing

    private void Start()
    {
        logRigidbody = GetComponent<Rigidbody>();  //accessing the rigidbody
        StartCoroutine(ChangeRotation());  //starting the corutine for irregular rotation of the log
    }

    private void Update()
    {
        if (!isReversing) //if the bool is false the the z rotation of the log will be in positive direction
        {
            transform.Rotate(transform.rotation.x, transform.rotation.y, rotationSpeed);
        }
        else if (isReversing) //if the bool is true the the z rotation of the log will be in negative direction
        {
            transform.Rotate(transform.rotation.x, transform.rotation.y, -rotationSpeed);
        }

    }
    IEnumerator ChangeRotation()
    {

        yield return new WaitForSeconds(2f);//changing the bool to true after two seconds
        isReversing = true;
        yield return new WaitForSeconds(4f);//and changing it to false after 4 sec after it is set to true
        isReversing = false;
    }
}
