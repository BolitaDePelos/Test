using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody m_Rb;
    [SerializeField] private float speed;

    [SerializeField] private LayerMask FloorMask;
    [SerializeField] private Transform FeetTransform;
    [SerializeField] private float JumpForce;
    [SerializeField] private string currentAnimaton;
    
    //Animation States
    const string PLAYER_IDLE = "Player_idle";
    const string PLAYER_RUN = "Player_run";
    const string PLAYER_JUMP = "Player_jump";

   // private float animationDelay;
    public bool isJumping;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)){
            ChangeAnimationState(PLAYER_JUMP);

            if (Physics.CheckSphere(FeetTransform.position, 0.1f, FloorMask))
            {
                isJumping = true;
                m_Rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);

                Invoke("JumpCompleted", 0.7f);
            }
        }
    }
    void FixedUpdate(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;
        if (!isJumping) { 
            if (movement == Vector3.zero)
            {
               ChangeAnimationState(PLAYER_IDLE);
                return;
            }
            else
                 ChangeAnimationState(PLAYER_RUN);
        }
        // 



        Quaternion targetRotation = Quaternion.LookRotation(movement);
        targetRotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                360 * Time.fixedDeltaTime);
        m_Rb.MovePosition(m_Rb.position + movement * speed * Time.fixedDeltaTime);
        m_Rb.MoveRotation(targetRotation);

    }
    void JumpCompleted()
    {
       
        isJumping = false;
    }
    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;
        // anim.Play(newAnimation);
        anim.CrossFade(newAnimation, 0.5f);

        //anim.Play(newAnimation);
       currentAnimaton = newAnimation;
    }
}
