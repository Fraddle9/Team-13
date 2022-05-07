using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkDust : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        characterController2 walking = new characterController2();
    }


    void Update()
    {
        
    }
}
