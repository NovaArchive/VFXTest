using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed Melee");
            animator.SetTrigger("Melee");
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Pressed Ranged");
            animator.SetTrigger("Ranged");
        }
    }
}
