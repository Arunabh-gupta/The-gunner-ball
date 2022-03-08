using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //grapple gun feature
    Vector3 direction;
    [SerializeField]
    private float dis;
    public Transform shootPoint;

    private LineRenderer Rope;
    private SpringJoint2D grappleJoint;
    Vector3 grapplePoint;
    //grapple gun feature

    // shooting pew pew
    public GameObject bullet_prefab;
    private gun_aim Gun_aim;
    private Vector3 shoot_dir;
    [SerializeField]
    private float bullet_speed = 0f;

    // shooting pew pew
    void Start()
    {
        // grapple gun
        grappleJoint = gameObject.AddComponent<SpringJoint2D>();
        grappleJoint.enabled = false;   
        Rope = gameObject.GetComponent<LineRenderer>();
        // grapple gun

        // gun shooting
        Gun_aim = gameObject.GetComponent<gun_aim>();
        // gun shooting
    }

    void Update()
    {
        // grapple gun
        if(Input.GetMouseButtonDown(1)){
            StartGrapple();
        }
        else if(Input.GetMouseButtonUp(1)){
            StopGrapple();        
        }
        DrawRope();
        // grapple gun

        //gun shooting 
        if(Input.GetMouseButtonDown(0)){
            firing();
        }
        //gun shooting 
    }
    // grapple gun feature functions
    void StartGrapple()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - shootPoint.position;
        RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, direction, dis);
        if (hit.collider != null)
        {
            grapplePoint = hit.point;
            grappleJoint.enabled = true;
            grappleJoint.connectedAnchor = grapplePoint;
            grappleJoint.autoConfigureConnectedAnchor = false;
            grappleJoint.distance = hit.distance*Time.deltaTime*0.5f;
            grappleJoint.dampingRatio = 10f;
        }        
    }
    void StopGrapple(){
        grappleJoint.enabled = false;
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
        if(grappleJoint.isActiveAndEnabled){
            Rope_Line(shootPoint.position, grapplePoint);
        }
        else{
            EndLine();
        }
    } 
    // grapple gun feature functions


    // bullet firing
    void firing(){
        shoot_dir = Gun_aim.dir_vector;
        GameObject fired_bullet = Instantiate(bullet_prefab, shootPoint.position, Quaternion.identity);
        fired_bullet.GetComponent<Rigidbody2D>().velocity = -shoot_dir * bullet_speed;
        // bullets destroying is written in bullet script
    } 
    //bullet firing
   

}
