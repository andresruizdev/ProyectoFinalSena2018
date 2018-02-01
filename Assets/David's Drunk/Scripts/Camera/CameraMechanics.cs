using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMechanics : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] Transform player;

    private Vector3 offset;
    private Vector3 finalPlayerPos;
    private Vector3 finalOffset;

    private void Start()
    {
        player = GameManager.actualCharacter.transform;
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        finalPlayerPos.y = player.position.y;
        finalPlayerPos.z = player.position.z;
        finalOffset.y = offset.y;
        finalOffset.z = offset.z;
        transform.position = finalPlayerPos + finalOffset;
    }



}
