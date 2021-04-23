using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneTextAppear : MonoBehaviour
{
    public GameObject text;
    public Transform player;
    public GameObject controller;
    public AudioSource phoneRinging;
    public GameObject optionButtons;
    public GameObject movementScript;
    public GameObject mouseScript;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;

        text.SetActive(false);
        optionButtons.SetActive(false);
    }

    private void Update()
    {
        if (Vector3.Distance(player.position, transform.position) > 2.5)
        {
            text.SetActive(false);
        }

        if (GlobalVariables.phone_answered == true)
        {
            text.SetActive(false);
            phoneRinging.Stop();
        }

    }

    private void OnMouseOver()
    {
        if (Vector3.Distance(player.position, transform.position) <= 2)
        {
            text.SetActive(true);

            if ((Vector3.Distance(player.position, transform.position) <= 1.5) && (Input.GetKeyDown(KeyCode.E)))
            {

                movementScript.GetComponent<PlayerMovement>().enabled = false;
                mouseScript.GetComponent<MouseLook>().enabled = false;


                GlobalVariables.phone_answered = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                print("Is cursor visible? " + Cursor.visible);
                optionButtons.SetActive(true);



            }


        }

    }

    private void OnMouseExit()
    {
        text.SetActive(false);
    }
    
    public void setPath_Donuts()
    {
        GlobalVariables.donutPath = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        optionButtons.SetActive(false);

        movementScript.GetComponent<PlayerMovement>().enabled = true;
        mouseScript.GetComponent<MouseLook>().enabled = true;

    }

}
