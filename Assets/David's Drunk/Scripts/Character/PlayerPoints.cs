using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour {
    public Text pointsText;
    GameObject player;
    //Script para calcular los puntos del jugador
    private void Start()
    {
        player = GameObject.Find("David");
    }

    // Los puntos estan basados en la posición en el eje z del jugador * 10
    void Update ()
    {
        pointsText.text = "Puntos:\n " + (player.transform.position.z * 10).ToString("0");
	}
}
