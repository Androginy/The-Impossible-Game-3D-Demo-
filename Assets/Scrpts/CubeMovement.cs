using UnityEngine;
using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.Events;
using UnityEngine.UI;

public class CubeMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] GameManager gm;
    [SerializeField] AudioSource music;

    [SerializeField] float currentXPosition;
    [SerializeField] float currentYPosition;
    [SerializeField] float currentZPosition;

    [SerializeField] float runSpeed = 200f;
    [SerializeField] float jumpForce = 15f;
    [SerializeField] float jumpImpulse = 10f;
    [SerializeField] float strafeSpeed = 75f;

    [SerializeField] bool leftInput = false;
    [SerializeField] bool rightInput = false;
    [SerializeField] bool jumpInput = false;
    [SerializeField] bool isDead;
    [SerializeField] UnityEvent death;

    [SerializeField] Rotation Visual;
    [SerializeField] GameObject deathEffect;

    [SerializeField] int attempts;
    [SerializeField] Text attemptsText;

    [SerializeField] bool isGrounded;
    [SerializeField] string groundTag = "Ground";
    [SerializeField] string speedTag = "SpeedBoost";
    [SerializeField] string jumpTag = "GroundJump";

    [SerializeField] KeyCode left = KeyCode.A;
    [SerializeField] KeyCode right = KeyCode.D;
    [SerializeField] KeyCode jump = KeyCode.Space;

    private void Start()
    {
        Cursor.visible = false;
    }
    public void OnEnable()
    {
        Visual.gameObject.SetActive(true);
        deathEffect.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            Visual.gameObject.SetActive(false);
            deathEffect.SetActive(true);
            gm.EndGame();
            music.Pause();
            isDead = true;
            death?.Invoke(); // ? - проверка на null; если нет, то Invoke = false;
            Attempts.attempts += 1;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        Visual.jump = false;
        if (collision.gameObject.tag == groundTag)
        {
            isGrounded = true;
        }
        else
        {
            runSpeed = 100f;
            JumpOff();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == groundTag)
        {
            isGrounded = false;
            runSpeed = 35f;
        }
        if(collision.gameObject.tag == jumpTag && !jumpInput)
        {
            JumpStartFrom();
        }
    }   

    void JumpStart()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Acceleration);
        Visual.jump = true;
    }
    void JumpStartFrom()
    {
        rb.AddForce(Vector3.up * 200000, ForceMode.Force);
        Visual.jump = true;
        runSpeed = 35f;
    }    
    void JumpOff()
    {
        Visual.jump = false;
        jumpInput = false;
    }

    void Update()
    {
        leftInput = Input.GetKey(left);
        rightInput = Input.GetKey(right);
        jumpInput = Input.GetKey(jump);

        if (transform.position.y < -5f)
        {
            gm.EndGame();
            music.Pause();
            Visual.gameObject.SetActive(false);
            deathEffect.SetActive(true);
            Attempts.attempts += 1;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + Vector3.forward * runSpeed * Time.fixedDeltaTime);
        

        if (leftInput)
        {
            rb.AddForce(-strafeSpeed, 0, 0, ForceMode.Force);
        }

        else if (rightInput)
        {
            rb.AddForce(strafeSpeed, 0, 0, ForceMode.Force);
        }

        if (isGrounded && jumpInput)
        {
            JumpStart();
        }



    }

}


