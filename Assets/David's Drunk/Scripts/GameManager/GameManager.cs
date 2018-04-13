using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject charactersList;
    public static GameObject actualCharacter;
    public static int firstCity;

    private void Awake()
    {
        firstCity = 0;
        InstantiatePlayer();
    }

    //Metodo que instancia al personaje
    private void InstantiatePlayer()
    {
        try
        {
            if (charactersList != null)
            {
                actualCharacter = Instantiate(charactersList, charactersList.transform.position, charactersList.transform.rotation);
                actualCharacter.name = "David";
            }
            
        }
        catch (System.Exception ex)
        {
            print(ex);
        }
    }
}
