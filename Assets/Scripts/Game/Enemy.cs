using UnityEngine;

public class Enemy : Essence
{
    private Player player;

    private Rigidbody2D enemyPhysics;

    [SerializeField] private float speed;
    [SerializeField] private float agroDistance;
    [SerializeField] private bool playerDestroy;
    private int _atackDamage;


    void Awake()
    {
        _atackDamage = 1;
        enemyPhysics = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        player = Player.Instance;
    }

    private void Update()
    {
        WalkEnemy();
        FellAbyss();
    }

    private void WalkEnemy()
    {
        if (player != null)
        {
            float disToPlayer = Vector2.Distance
            (transform.position, player.transform.position);

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

    private void StartHunting()
    {
        if (player.transform.position.x
            < transform.position.x)
        {
            enemyPhysics.velocity = new Vector2(-speed, 0);
        }
        else if (player.transform.position.x
            > transform.position.x)
        {
            enemyPhysics.velocity = new Vector2(speed, 0);
        }
    }

    private void StopHunting()
    {
        enemyPhysics.velocity = new Vector2(0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.TakeDamage(_atackDamage);
        }
    }
}
