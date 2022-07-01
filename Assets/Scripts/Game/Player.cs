using UnityEngine;
using System;

public class Player : Essence
{
    public static Action onPlayerDestroy;

    public static Player Instance { get; private set; }

    private Rigidbody2D _playerRigidbody;
    private SceneController _sceneController;

    private int _atackDamage;


    private void Awake()
    {
        Instance = this;

        _atackDamage = 1;
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _sceneController = GameObject.FindGameObjectWithTag
            ("Scene").GetComponent<SceneController>();
    }

    private void FixedUpdate()
    {
        Walk();
        Jump();
        CheckingGround();
        FellAbyss();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_atackDamage);
        }
    }

    [SerializeField] private Vector2 moveVector;
    [SerializeField] private float speed = 2f;
    public void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        _playerRigidbody.velocity = new Vector2
            (moveVector.x * speed, _playerRigidbody.velocity.y);
    }

    [Space(10)]
    [SerializeField] private float jumpForse = 7f;
    public void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            _playerRigidbody.AddForce(Vector2.up * jumpForse);
        }
    }
    [Space(10)]
    [SerializeField] private bool onGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask ground;
    private void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle
            (groundCheck.position, checkRadius, ground);
    }

    public override void EntityDeath()
    {
        base.EntityDeath();
        onPlayerDestroy?.Invoke();
        _sceneController.DeadPlayer();
    }
}
