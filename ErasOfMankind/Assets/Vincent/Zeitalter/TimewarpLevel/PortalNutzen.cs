using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalNutzen  : MonoBehaviour 
{

	private int PortalLevel;

   public bool Transferiert = false;

  
	public void klick()
	{
	PortalLevel = Random.Range(1,3);
	
	switch (PortalLevel)
	{
	case 1:
	Portalzugriff1();
	break;
	case2:
	Portalzugriff2();
	break;
	case3:
	Portalzugriff3();
	break;
	default:
	break;
	}
	}

   void Portalzugriff1()
   {
	SceneManager.LoadScene("TimeWarpLevel");
    Debug.Log("Portal");
	Transferiert = true; 
   }
   
    void Portalzugriff2()
	{
    Debug.Log("Portal");
    SceneManager.LoadScene("TimeWarpLevel");
    Transferiert = true;    
	}

	void Portalzugriff3()
    {
        Debug.Log("Portal");
            SceneManager.LoadScene("TimeWarpLevel");
                    Transferiert = true;   
    }

}