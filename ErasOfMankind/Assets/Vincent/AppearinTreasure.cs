using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearinTreasure : Ads {

    public GameObject Treasure;
    public float Timer = 0;
    public float FinishingTime = 6;
    public int Auswahl;
    
    // Use this for initialization
	void Start () {

        Treasure = GameObject.FindGameObjectWithTag("Treasure");
        VanishingCheast();
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        if (Time.time >= Timer + FinishingTime && Treasure.activeInHierarchy == false)
        {
            Debug.Log("erscheinen");
            AppearingChest();
            
        }
    }

    public void AppearingChest()
    {
        Treasure.SetActive(true);
       
    }
    public void VanishingCheast()
    {

   
        Debug.Log("verschwinden");
        Treasure.SetActive(false);
        Timer = Time.time;
    }

    public void Choseoptions()
    {
       Auswahl = Random.Range(1, 2);

        switch (Auswahl)
        {
            case 1:
                triggerAd();
            
                break;
            case 2:
              giveChest();
                break;   
        }
    }

}
