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
            beforeJump = transform.position.x;
            anim.SetTrigger("Jump");
            StartCoroutine(AfterJump());
        }
        if (MobileInput.Instance.SwipeDown)
        {
            beforeSlide = transform.position.x;
            anim.SetTrigger("Slide");
            StartCoroutine(AfterSlide());
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

    private IEnumerator AfterSlide()
    {
        yield return new WaitForSeconds(1.5f);
        slidePositionsOperation = ( transform.position.x - beforeSlide ) / 8;
        print(slidePositionsOperation);
        for (int i = 0; i < 7; i++)
        {
            transform.position -= new Vector3(slidePositionsOperation, 0, 0);
            yield return new WaitForSeconds(0.05f);
        }
    }

    private IEnumerator AfterJump()
    {
        yield return new WaitForSeconds(1.5f);
        jumpPositionsOperation = ( transform.position.x - beforeJump ) / 8;
        for (int i = 0; i < 7; i++)
        {
            transform.position -= new Vector3(jumpPositionsOperation, 0, 0);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
