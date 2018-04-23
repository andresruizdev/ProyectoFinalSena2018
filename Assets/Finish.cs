using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private GameObject player;
    private bool isCreditsOn;
	
	void Start ()
    {
        player = GameObject.Find("David");
	}
	
	
	public void FinishGame()
    {
        player.GetComponent<PlayerControls>().Finish();
    }

    public void Credits()
    {
        if (!isCreditsOn)
        {
            player.GetComponent<PlayerControls>().OpenCredits();
            isCreditsOn = true;
        }
        else
        {
            player.GetComponent<PlayerControls>().CloseCredits();
            isCreditsOn = false;
        }
        
    }

}
