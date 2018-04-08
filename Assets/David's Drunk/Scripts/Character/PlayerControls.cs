using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Animator anim;
    private Vector3 initialPosition;
    private Vector3 initialRotation;
    private float beforeSlide;
    private float slidePositionsOperation;
    private float beforeJump;
    private float jumpPositionsOperation;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (MobileInput.Instance.SwipeLeft)
        {
            StartCoroutine(MovementCoroutine(-0.1f));
        }
        if (MobileInput.Instance.SwipeRight)
        {
            StartCoroutine(MovementCoroutine(0.1f));
        }
        if (MobileInput.Instance.SwipeUp)
        {
            anim.SetTrigger("Jump");
        }
        if (MobileInput.Instance.SwipeDown)
        {
            anim.SetTrigger("Slide");
        }
    }

    private IEnumerator MovementCoroutine(float moveQuantity)
    {
        for (int i = 0; i < 10; i++)
        {
            transform.position += new Vector3(moveQuantity, 0, 0);
            yield return new WaitForSeconds(0.02f);
        }
    }
    
}
