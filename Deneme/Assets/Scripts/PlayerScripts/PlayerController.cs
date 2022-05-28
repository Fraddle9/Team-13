using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Camera
    [SerializeField] GameObject _camera;
    //Movement
    [Header("Movement")]
    public float runSpeed;
    public float walkSpeed;
    private float xAxis;
    private bool walkToggle;
    [HideInInspector] public bool facingRight = true;
    private Rigidbody2D rb;
    [HideInInspector] public bool canMove = true;
    //Jumping
    [Header("Jumping")]
    public float jumpForce;
    private bool isJumping = false;
    public float jumpTimer;
    private float jumpTimeCounter;
    [HideInInspector] public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    //Combat
    [Header("Combat")]
    public Transform attackPoint;
    private float attackTime = 0.0f;
    private int attackCount = 0;
    public float attackRange = 0.5f;
    public int attackDamage = 10;
    public LayerMask enemyLayers;
    private bool isAttacking;
    private PlayerManager playerManager;
    [HideInInspector] public bool inCheckpointRange;
    [HideInInspector] public bool dead = false;
    [HideInInspector] public bool isCombo = false;


    //Animations
    private Animator animator;
    private string currentState;
    const string idle = "PlayerIdle";
    const string run = "PlayerRun";
    const string jump = "PlayerJump";
    const string fall = "PlayerFall";

    [SerializeField]
    GameObject Kitap, PanelOptions,PanelDialogue;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerManager = GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {     
            CheckState();
            CheckInputs();
            CheckAttack();
            ChangeAnimations();
            FlipPlayer(); 
    }

    void FixedUpdate()
    {
        Move();
        //Jump();
        _camera.transform.position = new Vector3(transform.position.x + 1.0f, transform.position.y + 2.5f, transform.position.z - 1.0f);

    }
    void CheckState()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void CheckInputs()
    {
        //Get Horizontal Input
        xAxis = Input.GetAxisRaw("Horizontal");
        //Walk Toggle
        if (Input.GetKeyDown(KeyCode.LeftAlt))
            walkToggle = !walkToggle;
        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                isJumping = true;
                jumpTimeCounter = jumpTimer;
                Jump();
            }
        }
        if (Input.GetButton("Jump") && isJumping)
            if (jumpTimeCounter > 0)
            {
                jumpTimeCounter -= Time.deltaTime;
                Jump();
            }
            else
                isJumping = false;

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }

    }



    void Move()
    {
        if (!canMove)
        {
            rb.velocity = new Vector2(0, 0);
            return;
        }

        if (!isAttacking)
        {

            if (!walkToggle)
                rb.velocity = new Vector2(xAxis * runSpeed, rb.velocity.y);
            else
                rb.velocity = new Vector2(xAxis * walkSpeed, rb.velocity.y);
        }
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

    }


    void FlipPlayer()
    {
        if (xAxis < 0 && facingRight)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            facingRight = !facingRight;
        }
          else if (xAxis > 0 && !facingRight)
         {
              transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
              facingRight = !facingRight;
          }
    }

    void ChangeAnimations()
    {
        //Ground Animations --> Idle, Run, Attack and Roll
        if (isGrounded)
        {
                if (!isAttacking)
                {
                    if (xAxis == 0)
                        ChangeAnimationState(idle);
                    else
                        ChangeAnimationState(run);
                }

                if (isAttacking)
                {
                    ChangeAnimationState("PlayerAttack" + attackCount);
                    if (attackTime > 0.6f)
                        isAttacking = false;
                }
        }

        //Air Animations --> Jump and Fall
        if (!isGrounded)
        {
            if (rb.velocity.y > 0)
                ChangeAnimationState(jump);
            if (rb.velocity.y < 0)
                ChangeAnimationState(fall);
        }

    }

    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;
        animator.Play(newState);
        currentState = newState;
    }

    private void CheckAttack()
    {
        attackTime += Time.deltaTime;
        if (attackTime > 0.6f)
            isCombo = false;
     
            if (Input.GetMouseButtonDown(0))
            {
                if (isGrounded)
                    if (isCombo && attackTime > 0.3f)
                        Attack();
                    else if (!isCombo)
                        Attack();
            }
                        
    }

    void Attack()
    {
        isAttacking = true;
        rb.velocity = new Vector2(0, 0);
        attackDamage += 2;
        attackCount++;
        isCombo = true;
       
        if (attackCount > 2 || attackTime > 0.6f)
        {
            attackCount = 1;
            attackDamage = 20;
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            
            if (enemy.CompareTag("Sword"))
                enemy.GetComponent<Sword_Behaviour>().TakeDamage(attackDamage);
            if (enemy.CompareTag("MinionwPoke"))
                enemy.GetComponent<Minion_wpoke>().TakeDamage(attackDamage * 1.25f);

        }
        attackTime = 0f;
    }

    private bool UIOpen()
    {

        if (Kitap.activeSelf || PanelDialogue.activeSelf || PanelOptions.activeSelf)
        {
            return true;
        }
        else return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
