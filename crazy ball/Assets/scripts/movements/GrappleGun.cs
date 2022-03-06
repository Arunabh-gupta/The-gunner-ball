using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleGun : MonoBehaviour
{
    public float dis = 0f;

    


    // grapple gun function
    public GameObject shootPoint;

    Vector2 direction;
    public LineRenderer Rope;
    SpringJoint2D grapplingHook;
    Vector3 grapplePoint;
    // grapple gun function

    void Start()
    {
        
        Rope = shootPoint.GetComponent<LineRenderer>();
        
    }
    void Awake() {
        grapplingHook = shootPoint.AddComponent<SpringJoint2D>();
        grapplingHook.enabled = false;
    }


    void Update()
    {
        

        // grapple gun 
        

        if (Input.GetMouseButtonDown(0))
        {
            StartGrapple();
            // DrawRope();

        }
        else if(Input.GetMouseButtonUp(0))
        {
            StopGrapple();
        }
        //grapple gun


    }
    

    void StartGrapple()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - shootPoint.transform.position;
        RaycastHit2D hit = Physics2D.Raycast(shootPoint.transform.position, direction, dis);
        if (hit.collider != null)
        {
            grapplePoint = hit.point;
            grapplingHook.enabled = true;
            grapplingHook.connectedAnchor = grapplePoint;
            grapplingHook.autoConfigureConnectedAnchor = false;
            grapplingHook.distance = hit.distance;
            grapplingHook.dampingRatio = 10f;
            

        }
        
    }
    void StopGrapple(){
        grapplingHook.enabled = false;
    }

    void Rope_Line(Vector3 start_point, Vector3 end_point){
        Rope.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = start_point;
        points[1] = end_point;
        Rope.SetPositions(points);
    }

    void EndLine(){
        Rope.positionCount = 0;
    }

    void DrawRope(){
        if(grapplingHook.isActiveAndEnabled){
            Rope_Line(shootPoint.transform.position, grapplePoint);
        }
        else{
            EndLine();
        }
    } 
}
