using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameHandler : MonoBehaviour
{

    public LevelCamera levelCam;
    private Vector3 levelCamPosition;
    private float cameraZoom = 5;
    public Transform partyLead;
    public bool camIsFixed = true;

    // Start is called before the first frame update
    void Start() {
        levelCam.Setup(() => partyLead.position, () => cameraZoom);
    }

    // Update is called once per frame
    void Update() {
        ZoomCamera(Input.GetAxis("Mouse ScrollWheel"));

        if (Input.GetKeyDown(KeyCode.Tab)) ToggleCamera();

        if (!camIsFixed) {
            float distanceFromEdge = 40;
            if (Input.mousePosition.x > Screen.width - distanceFromEdge) {
                levelCamPosition.x += .008f;
            }
            if (Input.mousePosition.x < distanceFromEdge) {
                levelCamPosition.x -= .008f;
            }
            if (Input.mousePosition.y > Screen.height - distanceFromEdge) {
                levelCamPosition.y += .008f;
            }
            if (Input.mousePosition.y < distanceFromEdge) {
                levelCamPosition.y -= .008f;
            }
        }
    }

    public void CreateMap() {

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
}
