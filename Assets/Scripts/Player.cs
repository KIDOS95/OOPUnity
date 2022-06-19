using UnityEngine;

public class Player : MonoBehaviour
{
    private Enemy EnemyClass;
    private Collider2D EnemyCollider;
    private Rigidbody2D PlayerRigidbody;

    private int _health;
    private int _atackDamage;



    private void OnEnable()
    {
        SceneController.onEnemyAppeared += LinkEnemy;
    }
  
    private void OnDestroy()
    {
        SceneController.onEnemyAppeared -= LinkEnemy;
    }
    
    private void LinkEnemy()
    {
        EnemyClass = GameObject.FindGameObjectWithTag
            ("Enemy").GetComponent<Enemy>();
        EnemyCollider = GameObject.FindGameObjectWithTag
            ("Enemy").GetComponent<Collider2D>();
    }
 
    private void Awake()
    {
        _health = 1;
        _atackDamage = 1;
        PlayerRigidbody = GetComponent<Rigidbody2D>();
    }
        
    private void FixedUpdate()
    {
        Walk();
        Jump();
        CheckingGround();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (EnemyCollider == collision)
        {
            EnemyClass.TakeDamage(_atackDamage);
        }
    }


    [SerializeField] private Vector2 moveVector;
    [SerializeField] private float speed = 2f;

    public void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        PlayerRigidbody.velocity = new Vector2
            (moveVector.x * speed, PlayerRigidbody.velocity.y);
    }


    [SerializeField] private float jumpForse = 7f;

    public void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            PlayerRigidbody.AddForce(Vector2.up * jumpForse);
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

    private int _minHealth = 0;
    public void TakeDamage(int amount)
    {
        _health -= amount;
        if (_health <= _minHealth)
        {
            Destroy(this.gameObject);
        }
    }
}
