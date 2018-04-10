using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeWarpLevel : Ads {

    
   

   public GameObject Homepoint;
   public GameObject Portal;
   public GameObject Spieler;
   public Vector3 Killzone;
   
   
  
  


    // Use this for initialization
    void Start ()
    {
        Killzone = new Vector3(0,0,0);
    }

    private void PlayerReturn()
    {
        Spieler.transform.position = Homepoint.transform.position;
    }
    
    private void Update()
    {/*
        if (Spieler.position.y <= Killzone)
        {

            Debug.Log("Du bist tot!");
            SceneManager.LoadScene("ErasOFMankind");
            triggerAd();
            PlayerReturn();
        }*/
    }


    void OnColliderEnter (Collider col)
    {
     
        
        if (col.gameObject.tag == "Portal")
        {
            Debug.Log("Du hast es geschaft");
            SceneManager.LoadScene("ErasOFMankind");
            triggerAd();
            randomBonus();
            PlayerReturn();
        }
        
    }
  
}

