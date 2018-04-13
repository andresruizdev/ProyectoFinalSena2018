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
    public GameObject menu;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        menu = GameObject.Find("Canvas");
        menu.SetActive(false);
    }

    private void Update()
    {
        Movement();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            menu.SetActive(true);
        }
        
    }

    // Este método se encarga del movimiento de acuerdo al movimiento que detecta el MobileInput
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


    //Corrutina de movimiento
    private IEnumerator MovementCoroutine(float moveQuantity)
    {
        for (int i = 0; i < 10; i++)
        {
            transform.position += new Vector3(moveQuantity, 0, 0);
            yield return new WaitForSeconds(0.02f);
        }
    }
    
}
