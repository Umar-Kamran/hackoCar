using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDistances : MonoBehaviour
{
    public LayerMask colMask;

    const float skinWidth = 0.015f;

    BoxCollider2D playerCol;
    Vector2[] raycastOrigins;
    Transform transf;
    SpriteRenderer sprite;

    private void Start()
    {
        playerCol = GetComponent<BoxCollider2D>();
        transf = GetComponent<Transform>();
        raycastOrigins = new Vector2[5];
        sprite = GetComponent<SpriteRenderer>();
        UpdateRaycastOrigins();
        
    }

    void UpdateRaycastOrigins()
    {
        //sets the position of the players colliders corner
        raycastOrigins[0] = sprite.transform.TransformPoint(0,0.5f,0);
        raycastOrigins[1] = sprite.transform.TransformPoint(0.5f,0.5f,0);
        raycastOrigins[2] = sprite.transform.TransformPoint(0.5f, 0, 0);
        raycastOrigins[3] = sprite.transform.TransformPoint(0.5f, -0.5f, 0);
        raycastOrigins[4] = sprite.transform.TransformPoint(0, -0.5f, 0);


    }

    public double[] distances()
    {
        UpdateRaycastOrigins();
        double[] distances = new double[5];
        Vector2[] dirs ={
            transf.up,
            (transf.up + transf.right).normalized,
            transf.right,
            (transf.right - transf.up).normalized,
            -transf.up
        };
        for (int i = 0; i < 5; i++)
        {
            Vector2 rayOrigin = raycastOrigins[i];
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, dirs[i], 5f, colMask);

            if (hit)
            {
                distances[i] = hit.distance;
            }
            //Debug.DrawRay(rayOrigin, dirs[i] *5f/Time.deltaTime, Color.red);
        }
        return distances;
        }
    }

