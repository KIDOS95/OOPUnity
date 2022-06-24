using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnController : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;

    [SerializeField] private GameObject playerPrefab;
    private GameObject _player;


    private void Awake()
    {
        if (_player == null)
        {
            _player = Instantiate(playerPrefab) as GameObject;
            _player.transform.position = new Vector2(-9, -4.5f);
        }
    }

    private void Update()
    {
        if (_enemy == null)
        {
            _enemy = Instantiate(enemyPrefab) as GameObject;
            _enemy.transform.position = new Vector2
                (UnityEngine.Random.Range(-9,10), transform.position.y);
        }
    }
}
