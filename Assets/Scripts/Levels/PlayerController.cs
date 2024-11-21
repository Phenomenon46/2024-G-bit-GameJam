using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Detect Layer")]
    [SerializeField] public LayerMask detectLayer;
    [Header("Speed")]
    [SerializeField] public int speed = 1;
    private Vector2 moveDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D))
        {
            moveDir = Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            moveDir = Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W))
        {
            moveDir = Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            moveDir = Vector2.down;
        }

        if(moveDir != Vector2.zero)
        {
            if (CanMoveToDir(moveDir))
            {
                Move(moveDir);
            }
        }

        moveDir = Vector2.zero;
    }

    bool CanMoveToDir(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, 1.0f, detectLayer);

        if (!hit)
        {
            return true;
        }
        else
        {
            if (hit.collider.GetComponent<Box>() != null)
            {
                return hit.collider.GetComponent<Box>().CanMoveToDir(dir,speed);
            }
        }
        return false;
    }

    void Move(Vector2 dir)
    {
        this.transform.localPosition += new Vector3(moveDir.x*speed, moveDir.y*speed, 0);                
    }
}
