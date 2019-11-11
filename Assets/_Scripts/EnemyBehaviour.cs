using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    Vector3 direction;
    //State pattern enum
    public enum enemyState
    {
        Move,
        Attack

    }
    private Rigidbody r;
    public Transform player;
    public enemyState enemyMode;

    Vector3 movement;
    void Start()
    {
        enemyMode = enemyState.Move;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        r = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy if falls off
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("Player is " + DistanceThisPlayer().ToString());

        check(enemyMode);
    }
    private void FixedUpdate()
    {
        MoveEnemy(movement);
    }
    float DistanceThisPlayer()
    {
        return Vector3.Distance(transform.position, player.transform.position);
    }

    void check(enemyState enemyMode)
    {
        //State Pattern switch break statement
        switch (enemyMode)
        {
            case enemyState.Move:
                //If not close to player, do nothing
                if (DistanceThisPlayer() < 5)
                {
                    enemyMode = enemyState.Attack;
                    Debug.Log("Attack Mode");
                    //break;
                }
                //transform.LookAt(other.gameObject.transform);

                break;
            case enemyState.Attack:
                //If close to player, seek player

                //The next 4 lines are from Youtube video https://www.youtube.com/watch?v=4Wh22ynlLyk&t=304s
                Vector3 direction = player.position - transform.position; 
                direction.Normalize();
                movement = direction;
                transform.LookAt(player.gameObject.transform);
                transform.position += transform.forward * speed * Time.deltaTime;
                

                if (DistanceThisPlayer() > 5)
                {
                    enemyMode = enemyState.Move;
                    //Debug.Log("Stationary/Move Mode");
                    //break;
                }

                break;

        }
    }
    
    //From Youtube vieo: https://www.youtube.com/watch?v=4Wh22ynlLyk&t=304s
    void MoveEnemy(Vector3 direction)
    {
    
        r.MovePosition((Vector3)transform.position + (direction * speed * Time.deltaTime));
    }
}