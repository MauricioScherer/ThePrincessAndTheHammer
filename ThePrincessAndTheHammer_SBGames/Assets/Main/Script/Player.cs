using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private GameManager gameManager;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    private bool stoped;

    public Animator anim;
    public AudioClip[] clipImpact;
    public AudioSource soundImpact;
    public AudioSource step;

    [Header("Deash")]
    public bool dash;
    private bool isDash;
    private float currentDashTime = 1.0f;
    public Vector3 moveDirection;
    public float maxDashTime = 1.0f;
    public float dashSpeed = 1.0f;
    public float dashStoppingSpeed = 0.1f;
    public AudioSource dashSound;
    public GameObject dashEffect;

    public Image timeDash;
    public float timeDashRestored;
    public GameObject dashBar;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        if(dash)
        {
            dashBar.SetActive(true);
        }
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if(!isDash && !stoped)
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;

                if (!anim.GetBool("Walk"))
                    anim.SetBool("Walk", true);

                if (!step.isPlaying)
                    step.Play();
            }
        }

        if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && anim.GetBool("Walk"))
        {
            anim.SetBool("Walk", false);
            if (step.isPlaying)
                step.Stop();
        }

        if(dash)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && timeDash.fillAmount >= 1.0f)
            {
                anim.SetTrigger("Dash");
                dashSound.Play();
                currentDashTime = 0.0f;
                isDash = true;
                timeDash.fillAmount = 0;
                dashEffect.SetActive(true);
            }
            if (currentDashTime < maxDashTime)
            {
                moveDirection = transform.forward * dashSpeed;/* new Vector3(0, 0, dashSpeed);*/
                //moveDirection *= dashSpeed;
                currentDashTime += dashStoppingSpeed;
            }
            else
            {
                moveDirection = Vector3.zero;
                isDash = false;
                dashEffect.SetActive(false);
            }
            controller.Move(moveDirection * Time.deltaTime);

            if (timeDash.fillAmount < 1.0f)
            {
                timeDash.fillAmount += timeDashRestored * Time.deltaTime;
            }
        }

        ////// Changes the height position of the player..
        ////if (Input.GetButtonDown("Jump") && groundedPlayer)
        ////{
        ////    playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        ////    anim.SetTrigger("Jump");
        ////}

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public bool GetGrounded()
    {
        return groundedPlayer;
    }

    public void ImpactPlayer()
    {
        anim.SetTrigger("Impact");
    }

    public void PlaySoundImpact(bool p_metal)
    {
        if (p_metal)
            soundImpact.clip = clipImpact[1];
        else
            soundImpact.clip = clipImpact[0];

        soundImpact.Play();
    }

    public void GetPowerUpDash()
    {
        dash = true;
        stoped = true;

        Invoke("ResetMovement", 5.0f);
    }

    private void ResetMovement()
    {
        dashBar.SetActive(true);
        stoped = false;

        gameManager.ViewTutorial2();
    }
}
