using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAndSpawnSystem : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Player")){
            player.transform.position = respawnPoint.position;
        }
    }
}
