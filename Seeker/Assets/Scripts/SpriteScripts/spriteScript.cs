using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Squaddie");
        GameObject closestEnemy = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject enemy in enemies)
        {
            Vector3 difference = enemy.transform.position - position;
            float currentDistance = difference.sqrMagnitude;

            if (currentDistance < distance)
            {
                closestEnemy = enemy;
                distance = currentDistance;
            }
        }

        return closestEnemy;
    }

    public virtual Transform getMovePoint()
    {
        return null;
    }

    public virtual Animator getAnimator()
    {
        return null;
    }

}
