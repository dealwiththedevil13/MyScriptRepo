using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;


public class Enemy : MonoBehaviour
{
    //stats for the enemies
    public int curHp, maxHp;
    // Movement and the offset
    public float moveSpeed, attackRange, yPathOffset;
    //Path Coordinates
    private List<Vector3> path;
    //Target to follow
    private GameObject target;
    //Weapon


    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        //Get Components
        // weapon = GetComponent<Weapons>();
        target = FindObjectOfType<PlayerController>().gameObject;
        InvokeRepeating("UpdatePath", 0.0f, 0.5f);

        curHp=maxHp;
        
    }

    // Update is called once per frame
    void UpdatePath()
    {
        //Calculate a path
        NavMeshPath navMeshPath = new NavMeshPath();
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        path= navMeshPath.corners.ToList();
    }

    void ChaseTarget()
    {
        if(path.Count == 0)
            return;
        // Move to the closet path
        transform.position = Vector3.MoveTowards(transform.position, path[0]+ new Vector3(0, yPathOffset, 0), moveSpeed * Time.deltaTime);

        if(transform.position == path[0] + new Vector3(0, yPathOffset, 0))
            path.RemoveAt(0);
    }

    public void TakeDamage(int damage)
    {
        curHp -= damage;

        //if(curHp <=0)die();
    }

    void Update()
    {
        //Look at the player
        Vector3 dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.x, dir.z)* Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.up * angle;

        //Calculate the distance between the player and the enemy
        float dist = Vector3.Distance(transform.position, target.transform.position);

        //if within attackrange shoot at player
        if(dist<= attackRange)
        {
           // if(weapon.CanShoot())
          //  weapon.Shoot();
        }
        else{
            ChaseTarget();
        }
    }
}
