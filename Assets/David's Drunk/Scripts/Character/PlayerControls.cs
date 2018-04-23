using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public AudioSource playerAS;
    private bool menuIsActive = false;
    public Text pointCounter;
    public Text pointSetterFinish;
    public GameObject credits;

    private void Awake()
    {
        pointCounter = GameObject.Find("Points").GetComponent<Text>();
        pointSetterFinish = GameObject.Find("PointsC").GetComponent<Text>();
        menu = GameObject.Find("Canvas");
        credits = GameObject.Find("Creditos");
        anim = GetComponent<Animator>();
        
    }

    private void Start()
    {
        playerAS = this.GetComponent<AudioSource>();
        CloseCredits();
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
            Finish();
            
        }
        
    }

    public void Finish()
    {
        if (!menuIsActive)
        {
            playerAS.Play();
            pointSetterFinish.text = pointCounter.text;
        }
        menu.SetActive(true);
        menuIsActive = true;
    }

    public void OpenCredits()
    {
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
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
