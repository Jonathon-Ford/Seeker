using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public LevelCamera levelCam;
    private Vector3 levelCamPosition;
    private float cameraZoom = 5;
    public Transform partyLead;
    public bool camIsFixed = true;

    public float moveSpeed = 5f;
    public Transform movePoint;
    public Animator animator;

    public LayerMask isNoWalk;


    //TODO get start turn from mission data load
    public string whoseTurn = "player";

    public GameObject[] party;
    public int partyIndex = 0;

    public int APRemaining = 1;
    public int APTotal = 1;

    public string activeAction;

    private Rect commandBar = new Rect((Screen.width / 4), Screen.height - 100, 750, 100);


    // Start is called before the first frame update
    void Start(){
        levelCam.Setup(() => partyLead.position, () => cameraZoom);
        party = GameObject.FindGameObjectsWithTag("Squaddie");

        if (whoseTurn == "enemy")
        {
            GameObject.Find("Main Camera").GetComponent(Camera).GUILayer = false;
        }
    }

    private void OnGUI()
    {
        commandBar = GUI.Window(1, commandBar, commandFunc, "Actions");
        
    }

    // Update is called once per frame
    void Update(){
        ZoomCamera(Input.GetAxis("Mouse ScrollWheel"));

        if (Input.GetKeyDown(KeyCode.Tab)) ToggleCamera();

        if (!camIsFixed){
            float distanceFromEdge = 40;
            if (Input.mousePosition.x > Screen.width - distanceFromEdge){
                levelCamPosition.x += .008f;
            }
            if (Input.mousePosition.x < distanceFromEdge){
                levelCamPosition.x -= .008f;
            }
            if (Input.mousePosition.y > Screen.height - distanceFromEdge){
                levelCamPosition.y += .008f;
            }
            if (Input.mousePosition.y < distanceFromEdge){
                levelCamPosition.y -= .008f;
            }
        }

        if (activeAction == "move")
        {
            movePoint = party[partyIndex].GetComponent<spriteScript>().getMovePoint();
            Animator anim = party[partyIndex].GetComponent<spriteScript>().getAnimator();
            Transform tran = party[partyIndex].GetComponent<Transform>();

            if (Vector3.Distance(tran.position, movePoint.position) <= .1f && !Input.GetKey(KeyCode.LeftShift))
            {//Move only if in a square and tab is not pressed
                anim.SetFloat("speed", 0);

                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, isNoWalk))
                    {
                        anim.SetFloat("speed", 1);
                        movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                        
                        while (tran.position != movePoint.position)
                        {
                            tran.position = Vector3.MoveTowards(tran.position, movePoint.position, moveSpeed = 0.003f);
                        }

                        if (tran.position == movePoint.position)
                        {
                            APRemaining -= 1;
                            if (APRemaining == 0)
                            {
                                activeAction = "";
                            }
                        }
                    }
                }

                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, isNoWalk))
                {
                    if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                    {
                        anim.SetFloat("speed", 1);
                        movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);

                        while (tran.position != movePoint.position)
                        {
                            tran.position = Vector3.MoveTowards(tran.position, movePoint.position, moveSpeed = 0.003f);
                        }

                        if (tran.position == movePoint.position)
                        {
                            APRemaining -= 1;
                            if (APRemaining == 0)
                            {
                                activeAction = "";
                            }
                        }
                    }
                }
            }
        }
    }

    public void ZoomCamera(float amount){
        cameraZoom -= amount;
        if (cameraZoom < 2f) cameraZoom = 2f;
        if (cameraZoom > 40f) cameraZoom = 40f;
    }
    public void ToggleCamera(){
        camIsFixed = !camIsFixed;
        if (camIsFixed) levelCam.Setup(() => partyLead.position, () => cameraZoom);

        else{
            levelCamPosition = partyLead.position;
            levelCam.Setup(() => levelCamPosition, () => cameraZoom);
        }
    }

    public void commandFunc(int id)
    {
        GUI.enabled = (whoseTurn == "player");
        //TODO have this label get the character name from the data
        GUI.Label(new Rect(20, 18, 200, 20), "Jeff"+ " the"+ " Spaceman", "box");
        GUI.Label(new Rect(220, 18, 100, 20), "AP: " + APRemaining + "/" + APTotal, "box");

        GUI.enabled = (APRemaining != 0);
        if(GUI.Button(new Rect(20,38,60,60),"Move", "button"))
        {
            activeAction = "move";
        }
        GUI.enabled = true;


        if (GUI.Button(new Rect(90, 38, 60, 60), "End Turn", "button"))
        {
            endTurn();
        }
    }

    public void endTurn()
    {
        //TODO add "are you sure? you still have AP left yadda yadda"
        whoseTurn = "enemy";
        GUI.
        enemyTurn();
    }

    public void enemyTurn()
    {
        //TODO get individual logic from script based on enemy with general name
        party = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < party.Length; i++)
        {
            int APRemaining = 1;

            //TODO logical selection of move or attack
            if (APRemaining != 0)
            {
                movePoint = party[partyIndex].GetComponent<spriteScript>().getMovePoint();
                Transform tran = party[partyIndex].GetComponent<Transform>();

                GameObject closestEnemy = party[partyIndex].GetComponent<spriteScript>().getClosestEnemy();

                tran.position = Vector3.MoveTowards(tran.position, closestEnemy.transform.position, moveSpeed = 1f);
            }
        }

        whoseTurn = "player";
    }

}
