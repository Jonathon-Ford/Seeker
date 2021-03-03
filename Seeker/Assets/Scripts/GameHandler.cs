using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public LevelCamera levelCam;
    private float cameraZoom = 5;
    public Transform partyLead;

    // Start is called before the first frame update
    void Start()
    {
        levelCam.Setup(() => partyLead.position, () => cameraZoom);
    }

    // Update is called once per frame
    void Update()
    {
        ZoomCamera(Input.GetAxis("Mouse ScrollWheel"));
    }

    public void ZoomCamera(float amount)
    {
        cameraZoom -= amount;
        if (cameraZoom < 2f) cameraZoom = 2f;
        if (cameraZoom > 40f) cameraZoom = 40f;
    }
}
