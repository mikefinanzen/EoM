using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animationcontrollwalking : MonoBehaviour {
public Animator anim;
    public float offset;
    public float aktuelleZeit;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (Time.time - offset >= aktuelleZeit)
        {
            anim.SetBool("Run", false);
        }
	}

    public void NeueZeit()
    {
        aktuelleZeit = Time.time;
        anim.SetBool("Run", true);
        
    }


}
