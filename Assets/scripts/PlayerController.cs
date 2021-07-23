using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public Vector3 direction;
    public float forwardSpeed = 10;
    public float upJump = 5f;
    public float gravity = -20f;
    public float ground;
    public bool gameStart = false;
    public float num = 0;

    public int count=0;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStart)
        {
            ground = transform.position.y;
            gameStart = true;
        }
        float x = Input.GetAxis("Horizontal");
        direction = transform.right * x;
        
            if (transform.position.y.ToString() == ground.ToString())
            {
                if (Input.GetButton("Jump"))
            {
                direction.y = upJump;

            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }
        
        
        controller.Move(direction * Time.fixedDeltaTime * forwardSpeed);
        Vector3 ForwardDirection = new Vector3(0, 0, 1);
        controller.Move(ForwardDirection * Time.deltaTime * forwardSpeed);
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("colifede");
        print(hit.gameObject.transform.tag);
        if (hit.gameObject.tag == "obs")
        {
            count++;
            Destroy(hit.gameObject);
        }
    }
}
