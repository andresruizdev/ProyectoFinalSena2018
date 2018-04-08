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

    private void InstantiatePlayer()
    {
        actualCharacter = Instantiate(charactersList, charactersList.transform.position, charactersList.transform.rotation);
    }
}
