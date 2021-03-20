using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMan : spriteScript
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public Animator animator;

    

    public float APMod = 1;
    public int APTotal = 1;

    public string characterName = "Jeff";

    

    // Start is called before the first frame update
    void Start(){
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update(){
        
    }

    public override Transform getMovePoint()
    {
        return movePoint;
    }

    public override Animator getAnimator()
    {
        return animator;
    }

}
