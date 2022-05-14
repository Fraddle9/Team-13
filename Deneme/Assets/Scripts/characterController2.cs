using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController2 : MonoBehaviour
{
    public float jumpForce = 6.0f;
    public float speed = 2.0f;
    private float moveDirection;

    private bool jump;
    private bool grounded = true;
    //private bool moving;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private Animator anim;
    [SerializeField] GameObject _camera;

    private void Awake()
    {
        anim = GetComponent<Animator>(); // caching animator
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = new Vector2(speed * moveDirection, _rigidbody2D.velocity.y);

        if (jump == true)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
            jump = false;
        }
    }

    private void Update()
    {
        //Yürüme animasyonu icin
        if (grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                anim.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                anim.SetFloat("speed", speed);
            }
        }
        else if (grounded == true)
        {
            moveDirection = 0.0f;
            anim.SetFloat("speed", 0.0f);
        }

        //Zýplama animasyonu icin
        if (grounded == true && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            anim.SetTrigger("jump");
            anim.SetBool("grounded", false);
        }
    }

    private void LateUpdate()
    {
        //Kamera karakterimizi takip etsin.
        _camera.transform.position = new Vector3(transform.position.x + 2.5f, transform.position.y + 2.0f, transform.position.z - 1.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Karakterimiz zemine temas ettiðinde çalýþýr.
        if (collision.gameObject.CompareTag("Zemin"))
        {
            anim.SetBool("grounded", true);
            grounded = true;
        }
    }
}
