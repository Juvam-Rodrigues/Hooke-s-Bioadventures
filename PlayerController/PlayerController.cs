using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player))]

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    public SpriteRenderer arma;
    public float input_x = 0;
    public float input_y = 0;
    public float speed = 5.5f;
    bool isRunning;
    public bool isTalking;
    public GameObject cameraHooke;
    public Player player;    
    Rigidbody2D rb2D;
    Vector2 movement = Vector2.zero;
    private bool theEnd = false;
    private float period = 0;
    public FixedJoystick joystickMovimentacao;
    void Start()
    {
        // TEMPORÁRIO, APAGAR DEPOIS
        Hooke.getInstance().SaveData();
        isRunning = isTalking = false;
        rb2D = GetComponent<Rigidbody2D>();
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!theEnd){
            input_x = 0;
            input_y = 0;
            if(!player.GetEntity().dead){
                if(!isTalking){
                    //input_x = Input.GetAxisRaw("Horizontal");
                    //input_y = Input.GetAxisRaw("Vertical"); 
                    input_x = (joystickMovimentacao.Horizontal != 0) ? joystickMovimentacao.Horizontal : Input.GetAxisRaw("Horizontal");
                    input_y = (joystickMovimentacao.Vertical != 0) ? joystickMovimentacao.Vertical : Input.GetAxisRaw("Vertical");   
                }
                isRunning = (input_x != 0 || input_y != 0);
                movement = new Vector2(input_x, input_y);
                if(isRunning){
                    cameraHooke.transform.position = Vector3.Lerp(cameraHooke.transform.position, new Vector3(transform.position.x, transform.position.y, -10), 1);
                    playerAnimator.SetFloat("input_x", input_x);
                    playerAnimator.SetFloat("input_y", input_y);
                }
                playerAnimator.SetBool("isRunning", isRunning);
            }
            else{
                playerAnimator.SetBool("isDead", true);
                theEnd = true;
            }
            period += Time.deltaTime;
            if (period >= 2f && !playerAnimator.GetBool("piscando"))
            {
                if (Random.value > 0.6f)
                    playerAnimator.SetBool("piscando", true);
                period = 0f;
            }
        }
    }
    private void FixedUpdate(){
        if(!theEnd){
            rb2D.MovePosition(rb2D.position + movement * speed * Time.fixedDeltaTime);
        }
    }
}
