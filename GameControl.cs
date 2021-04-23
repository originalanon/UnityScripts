using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public GameObject player;

    public GameObject danaStandard;
    public GameObject danaStuffedLvl1;
    public GameObject danaStuffedLvl2;
    public GameObject danaStuffedLvl3;



    public Animator danaAnim;



    // Start is called before the first frame update
    void Start()
    {
        danaStuffedLvl1.SetActive(false);
        danaStuffedLvl2.SetActive(false);
        danaStuffedLvl3.SetActive(false);

    }

    // Update is called once per frame
    void Update() { 

        if(GlobalVariables.stuffedLevel >= 5.0f)
        {
            danaStandard.SetActive(false);
            danaStuffedLvl1.SetActive(true);
            danaAnim.SetFloat("stuffedLevelAnim", 1);
        }
        if(GlobalVariables.stuffedLevel >= 10.0f)
        {
            danaStuffedLvl1.SetActive(false);
            danaStuffedLvl2.SetActive(true);
        }
        if (GlobalVariables.stuffedLevel >= 15.0f)
        {
            danaStuffedLvl2.SetActive(false);
            danaStuffedLvl3.SetActive(true);
        }
    }
}
