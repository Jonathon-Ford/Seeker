using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tallboiScript : spriteScript
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    //public Animator animator;

    public LayerMask isNoWalk;

    // Start is called before the first frame update
    void Start()
    {
        //movePoint.parent = null;
        if (Input.anyKeyDown)
        {
            
            GameObject target = base.getClosestEnemy();
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed = 1f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override Transform getMovePoint()
    {
        return movePoint;
    }

}
