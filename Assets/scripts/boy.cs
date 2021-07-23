using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class boy : MonoBehaviour
{
    private CharacterController controller;
    public Vector3 direction;
    public float forwardSpeed = 20;
    public float upJump = 5f;
    public float gravity = -20f;
    public int count=0;
    public Animator anim;
    public int total = 0;
    public bool shouldBeIdle = false;
    public MotivationalQuotes mq;
    public bool startGame = false;
    public TMP_Text countdown;
    public GameObject countDownCanvas;
    public GameObject gameCanvas;
    public AudioSource backgroundMusic;
    public AudioSource hitSound;
    public static bool jump = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        StartCoroutine(countdownRoutine());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!shouldBeIdle&&startGame)
        {
            if (total >= userData.hurdles)
            {
                StartCoroutine(gameOver());
            }
            if (controller.isGrounded)
            {
                forwardSpeed = 20;
                if (Input.GetButton("Jump")||jump)
                {
                    Debug.Log("WE jummped");
                    direction.y = upJump;
                    forwardSpeed = 45f;
                   jump = false;
                    //anim.SetBool("jump", true);
                    //StartCoroutine(jumpDown(0.5f));

                }
            }
            else
            {
                direction.y += gravity * Time.deltaTime;
            }
            controller.Move(direction * Time.fixedDeltaTime * forwardSpeed);
            Vector3 forward = new Vector3(0, 0, 1);
            controller.SimpleMove(forward * forwardSpeed);

        }
        else if (!controller.isGrounded)
        {
            direction.y += gravity * Time.deltaTime;
            controller.Move(direction * Time.fixedDeltaTime * forwardSpeed);
        }


    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
        if (hit.gameObject.tag == "obs")
        {
            count++;
            mq.setMQ();

            hitSound.Play(0);
            Destroy(hit.gameObject);


            //grounded = new Vector3(transform.position.x,0,transform.position.z);
            
           
            //transform.position = grounded;
            shouldBeIdle = true;
            anim.SetBool("idle", true);
            Invoke("Idle", 1.0f);
            

        }

        if (hit.gameObject.tag == "pass")
        {
            Destroy(hit.gameObject);
            total++;
            Debug.Log("pass"+total);
        }
    }
    
    private void Idle()
    {
        mq.removeText();
        shouldBeIdle = false;
        anim.SetBool("idle", false);
        
        

        //forwardSpeed = 15;
        //anim.SetBool("jump", false);
    }
    public IEnumerator gameOver()
    {
        shouldBeIdle = true;
        anim.SetBool("idle", true);
        mq.goodText();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("end");

    }

    public IEnumerator countdownRoutine()
    {
        
        countdown.text = "3";
        yield return new WaitForSeconds(.7f);
        countdown.text = "2";
        yield return new WaitForSeconds(.7f);
        countdown.text = "1";
        yield return new WaitForSeconds(.7f);
        startGame = true;
        countDownCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        backgroundMusic.Play(0);
        yield break;
    }

    
}
