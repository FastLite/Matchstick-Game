using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CMF;

public class AnimationController : MonoBehaviour
{    
    AdvancedWalkerController controller;
    Animator animator;


    void Start()
    {
        controller = GetComponent<AdvancedWalkerController>();
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        //Get controller velocity;     
        Vector3 _velocity = controller.GetVelocity();

        //Get controller grounded status;
        bool _isGrounded = controller.IsGrounded();

        //Pass values to animator component;
        animator.SetBool("IsGrounded", _isGrounded);
        animator.SetFloat("Speed", _velocity.magnitude);
    }
}
