using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnController : MonoBehaviour
{
    public static Action onEnemyAppeared;

    [SerializeField] private GameObject enemyPrefab;
    private GameObject _enemy;

    [SerializeField] private GameObject playerPrefab;
    private GameObject _player;

    public NewRandom randomNumber;

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
            _enemy.transform.position = new Vector2(randomNumber.Roulette(-9, 9), 5);
            onEnemyAppeared?.Invoke();
        }
    }
}
