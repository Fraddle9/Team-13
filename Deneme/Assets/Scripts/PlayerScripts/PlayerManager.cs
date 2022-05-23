using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public HealthBarScript healthBar;
    [HideInInspector] public GameObject currentCheckPoint;
    private PlayerController player;
    private Rigidbody2D rb;
    public GameObject reviveEffect;
    private SpriteRenderer spriteRenderer;
    public float flickerSpeed;
    private bool flickering;

    public static PlayerManager instance;

    private int lives = 2;
    public float MaxHealth = 100;
    public float CurrentHealth = 100f;
    
    //[HideInInspector] 
    public bool damageable = true;
    //[HideInInspector] 
    public bool dead = false;
    [HideInInspector] public bool isReviving;
    public int status=1;
    private bool revived = false;


    //Animations
    const string hit = "PlayerHit";
    const string death = "PlayerDeath";
    const string revive = "PlayerRevive";
    const string counter = "PlayerCounter";
    
    [HideInInspector] public bool hitAnimRunning;





    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentCheckPoint = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (flickering)
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Mathf.PingPong(Time.time * flickerSpeed, 1));
        else
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, 1);
        
    }

    private void Awake()
    {
        instance = this;
    }
   
    
    public virtual void DamagePlayer(float damage)
    {
        if (damageable)
        {
            if ((CurrentHealth - damage) >= 0)
            {
                switch (status)
                {
                    //normal damage status
                    case 1:
                        CurrentHealth -= damage;
                        healthBar.SetHealth(CurrentHealth);
                        player.ChangeAnimationState(hit);
                        hitAnimRunning = true;
                        Invoke("CancelHitState", .33f);
                        break;
                }
            }
            else
            {
                CurrentHealth = 0;

            }
            Die();
        }
    }
    void CancelHitState()
    {
        hitAnimRunning = false;
    }
    void Die()
    {
        if (CurrentHealth <= 0)
        {
            lives--;
            if (lives == 1)
            {
                dead = true;
                //rb.simulated = false; character stays in air when he dies if these lines are active
                player.enabled = false;
                player.ChangeAnimationState(death);
                StartCoroutine(DeathDefiance());
                CurrentHealth = (MaxHealth * 40) / 100;

            }
            if (lives == 0)
            {
                dead = true;
                player.ChangeAnimationState(death);
                CurrentHealth = MaxHealth;
                lives = 2;
                //rb.simulated = false; character stays in air when he dies if these lines are active
                player.enabled = false;
                StartCoroutine(RespawnPlayer());
            }
        }
    }

    void StatusChanger(int a)
    {
        status = a;
    }

    IEnumerator DeathDefiance()
    {
        damageable = false;
        yield return new WaitForSeconds(1f);
        isReviving = true;
        Instantiate(reviveEffect, transform.position, Quaternion.identity);
        player.ChangeAnimationState(revive);
        yield return new WaitForSeconds(.5f);
        revived = true;
        isReviving = false;
        dead = false;
        //rb.simulated = true; character stays in air when he dies if these lines are active
        player.enabled = true;
        flickering = true;
        yield return new WaitForSeconds(2f);
        damageable = true;
        flickering = false;
        healthBar.SetMaxHealth(MaxHealth);
        // CurrentHealth = 100;
    }

    IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(1f);
        revived = false;
        transform.position = new Vector3(currentCheckPoint.transform.position.x + 1, transform.position.y, currentCheckPoint.transform.position.z);
        dead = false;
        //rb.simulated = true; character stays in air when he dies if these lines are active
        player.enabled = true;
        healthBar.SetMaxHealth(MaxHealth);
        // CurrentHealth = 100;
    }

}
