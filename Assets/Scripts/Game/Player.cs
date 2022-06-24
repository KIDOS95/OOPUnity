using UnityEngine;
using System;

public class Player : Essence
{
    public static Player Instance { get; private set; }

    public static Action onPlayerAppeared;

    private Rigidbody2D playerRigidbody;
    private SceneController _sceneController;

    private int _atackDamage;

    private void Awake()
    {
        Instance = this;

        onPlayerAppeared?.Invoke();

        _atackDamage = 1;
        playerRigidbody = GetComponent<Rigidbody2D>();
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
        playerRigidbody.velocity = new Vector2
            (moveVector.x * speed, playerRigidbody.velocity.y);
    }

    [SerializeField] private float jumpForse = 7f;
    public void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            playerRigidbody.AddForce(Vector2.up * jumpForse);
        }
    }

    [SerializeField] private bool onGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask ground;
    private void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle
            (groundCheck.position, checkRadius, ground);
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        _sceneController.DeadPlayer();
    }

    public override void FellAbyss()
    {
        base.FellAbyss();
        if (this.gameObject.transform.position.y <= -6)
            _sceneController.DeadPlayer();
    }
}
