using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tallboiScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    //public Transform movePoint;
    //public Animator animator;

    public LayerMask isNoWalk;

    // Start is called before the first frame update
    void Start()
    {
        //movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            GameObject target = findClosestEnemy();
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed = 1f);
        }
    }

    GameObject findClosestEnemy()
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
}
