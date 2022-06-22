using UnityEngine;

public class Enemy : Essence
{
    private Player player;
    private Collider2D playerCollider;

    private Rigidbody2D enemyPhisics;

    private int _atackDamage;
    public float speed;
    public float agroDistance;
    public bool playerDestroy;


    public void LinkPlayer()
    {
            player = GameObject.FindGameObjectWithTag
                ("Player").GetComponent<Player>();
            playerCollider = GameObject.FindGameObjectWithTag
                ("Player").GetComponent<Collider2D>();         
    }


    void Awake()
    {
        _atackDamage = 1;
        enemyPhisics = GetComponent<Rigidbody2D>();
        LinkPlayer();
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
            enemyPhisics.velocity = new Vector2(-speed, 0);
        }
        else if (player.transform.position.x
            > transform.position.x)
        {
            enemyPhisics.velocity = new Vector2(speed, 0);
        }
    }

    private void StopHunting()
    {
        enemyPhisics.velocity = new Vector2(0, 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (playerCollider == collision)
        {
            player.TakeDamage(_atackDamage);
        }
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
    }
}
