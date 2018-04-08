using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarCiudad : MonoBehaviour {
    [SerializeField]
    GameObject city;

	void Start ()
    {
        //Se invocan los metodos InstantiateCity despues de unos segundos segun el caso y posteriormente tambien a DeleteThisOne, sirven para instanciar y destruir sucesivamente
        if (GameManager.firstCity == 0)
        {
            StartCoroutine(InstantiateCityCoroutine(6f));
            GameManager.firstCity++;
        }
        else if (GameManager.firstCity == 1)
        {
            StartCoroutine(InstantiateCityCoroutine(25f));
        }
        //StartCoroutine(DeleteStreet(50f));

    }


    IEnumerator InstantiateCityCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        InstantiateCity();
    }

    /*IEnumerator DeleteStreet(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        DeleteThisOne();
    }*/

    void InstantiateCity()
    {
        //Instanca el prefab de la ciodad en la posicion y rotacion dada en los parametros
        Instantiate(city, transform.position + new Vector3(0,0,100), transform.rotation);
    }

    /*void DeleteThisOne()
    {
        //Elimina esta cuando se activa el metodo
        Destroy(this.transform.gameObject);
    }*/
	
}
