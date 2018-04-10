using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : Ads
{
    public GameObject Portal;
    public GameObject Homepoint;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Spieler")
        {
            Debug.Log("Du bist tot!");
            SceneManager.LoadScene("ErasOFMankind");
            triggerAd();
            col.gameObject.transform.position = Homepoint.transform.position;
        }
    }
}
