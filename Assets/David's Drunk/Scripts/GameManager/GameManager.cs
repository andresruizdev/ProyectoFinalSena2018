using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject charactersList;
    public static GameObject actualCharacter;
    
    private void Awake()
    {
        actualCharacter = Instantiate(charactersList, charactersList.transform.position, charactersList.transform.rotation);
    }
}
