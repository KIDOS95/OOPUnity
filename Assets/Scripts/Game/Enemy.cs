using UnityEngine;
using System;

public class Enemy : Essence
{
    public static Action onEnemyDestroy;

    private Player _player;
    private Rigidbody2D _enemyPhysics;

    private int _atackDamage;


    void Awake()
    {
        _atackDamage = 1;
        _enemyPhysics = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _player = Player.Instance;
    }

    private void Update()
    {
        WalkEnemy();
        FellAbyss();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.TakeDamage(_atackDamage);
        }
    }

    [SerializeField] private float agroDistance;
    private void WalkEnemy()
    {
        if (_player != null)
        {
            float disToPlayer = Vector2.Distance
            (transform.position, _player.transform.position);

            if (disToPlayer < agroDistance)
            {
                StartHunting();
            }
            else
            {
                StopHunting();
            }
        }
    }

    [SerializeField] private float speed;
    private void StartHunting()
    {
        if (_player.transform.position.x
            < transform.position.x)
        {
            _enemyPhysics.velocity = new Vector2(-speed, 0);
        }
        else if (_player.transform.position.x
            > transform.position.x)
        {
            _enemyPhysics.velocity = new Vector2(speed, 0);
        }
    }

    private void StopHunting()
    {
        _enemyPhysics.velocity = new Vector2(0, 0);
    }

    public override void EntityDeath()
    {
        base.EntityDeath();
        onEnemyDestroy?.Invoke();
    }
}
