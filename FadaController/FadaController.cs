using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadaController : MonoBehaviour
{
    [SerializeField]
    public Animator fadaAnimator;

    [SerializeField]
    public PlayerController pc;

    [SerializeField]
    SpriteRenderer fada;

    [SerializeField]
    public Dialogue dc;
    public float speed = 2f;
    public float norm;
    void Update()
    {

        if(dc.falando){
            this.fadaAnimator.SetBool("isTalking", true);
            if(pc.input_x < 0){
            fada.flipX = false;
            }else if(pc.input_x > 0){
            fada.flipX = true;
            }
        }else if(dc.falando == false){
            this.fadaAnimator.SetBool("isTalking", false);
            if(pc.input_x < 0){
            fada.flipX = false;
            }else if(pc.input_x > 0){
            fada.flipX = true;
            }
        }
       
        norm = (Mathf.Sin(Time.time * speed) + 1) / 2;

        fada.transform.localPosition = Vector3.Lerp(new Vector3(0, -0.1f, 0), new Vector3(0, 0.1f, 0), norm);
    }
    
}
