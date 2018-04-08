using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	[SerializeField]
	private float velocidadCiudad;

    [SerializeField]
    private float cloudsSpeed;
    [SerializeField]
    public Material cloudsMaterial;


    void Update () 
	{
        //Movimiento del material de la ciudad a una determinada velocidad 
		Vector2 newOffset = cloudsMaterial.mainTextureOffset;
		newOffset.y += cloudsSpeed * Time.deltaTime;
		cloudsMaterial.mainTextureOffset = newOffset;
        
    }


}
