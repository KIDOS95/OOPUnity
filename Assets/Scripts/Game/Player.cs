using System;
using UnityEngine;


public class Player : Essence
{
    public static Action onPlayerDestroy;

    public static Player Instance { get; private set; }

    private Rigidbody2D _playerRigidbody;
    private SceneController _sceneController;


    [SerializeField] private Vector2 moveVector;
    [Space(10)]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpForse = 7f;
    [Space(10)]
    [SerializeField] private bool onGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask ground;
    [SerializeField] private GameObject partiñleDeath;
    [Space(10)]

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
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_atackDamage);
        }
    }

    protected override void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        _playerRigidbody.velocity = new Vector2
            (moveVector.x * speed, _playerRigidbody.velocity.y);
    }

    public void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            _playerRigidbody.AddForce(Vector2.up * jumpForse);
        }
    }

    private void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle
            (groundCheck.position, checkRadius, ground);
    }

    protected override void EntityDeath()
    {
        partiñleDeath.transform.position =
            gameObject.transform.position;
        Instantiate(partiñleDeath);

        base.EntityDeath();
        onPlayerDestroy?.Invoke();
        _sceneController.DeadPlayer();
    }
}
