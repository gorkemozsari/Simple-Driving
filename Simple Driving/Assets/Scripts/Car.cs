using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float acc = 0.2f;
    [SerializeField] private float turnSpeed = 125f;
    //[SerializeField] private float turnAcc = 1f;    
     private int steerValue;

    void Update()
    {
        if(Touchscreen.current.primaryTouch.press.isPressed)
        {
            speed += acc * Time.deltaTime;
        }
        else
        {
            speed -= acc * Time.deltaTime;
        }
        //turnSpeed += turnAcc * Time.deltaTime;

        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("Scene_MainMenu"); // SceneManager.LoadScene(0) works as well cuz Menu is the first scene
        }
    }
   
    public void Steer(int value)
    {
        steerValue = value;
    }
}
