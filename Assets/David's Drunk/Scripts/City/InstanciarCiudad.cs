using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarCiudad : MonoBehaviour {
    [SerializeField]
    GameObject city;
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject[] obstacles;
    Transform obstacleTransform;
    
    void Start ()
    {
        player = GameObject.Find("David");
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
        StartCoroutine(InstantiateObstacles());

    }


    IEnumerator InstantiateCityCoroutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        InstantiateCity();
    }
    

    void InstantiateCity()
    {
        try
        {
            if (city != null)
            {
                Instantiate(city, transform.position + new Vector3(0, 0, 100), Quaternion.identity);
            }
            else
            {
                return;
            }
        }
        catch (System.Exception ex)
        {
            print(ex);
        }
        
    }

    IEnumerator InstantiateObstacles()
    {
        int obstacleIndex = Random.Range(0,2);
        int counter = 0;
        float secondsRange = Random.Range(6f, 13f);
        float pos = Random.Range(-1.4f, 1.5f);

        try
        {
            if (obstacles[obstacleIndex] != null && counter < 8)
            {
                GameObject obstacle = Instantiate(obstacles[obstacleIndex], player.transform.position + new Vector3(pos, 0, 40), Quaternion.identity);
                obstacle.transform.SetParent(this.gameObject.transform);
                counter++;
            }
        }
        catch (System.Exception ex)
        {
            print(ex);
        }
        yield return new WaitForSeconds(secondsRange);
        StartCoroutine(InstantiateObstacles());
    }
    
    
	
}
