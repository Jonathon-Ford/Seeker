using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMan : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public Animator animator;

    public LayerMask isNoWalk;

    // Start is called before the first frame update
    void Start(){
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update(){
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed = 0.003f);

        if (Vector3.Distance(transform.position, movePoint.position) <= .1f && !Input.GetKey(KeyCode.LeftShift)){//Move only if in a square and tab is not pressed
            animator.SetFloat("speed", 0);

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f){
                if(!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, isNoWalk)){
                    animator.SetFloat("speed", 1);
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }

            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, isNoWalk)){
                if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f){
                    animator.SetFloat("speed", 1);
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        }
    }
}
