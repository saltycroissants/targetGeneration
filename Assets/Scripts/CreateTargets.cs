using UnityEngine;
using System;
using System.Collections;

public class CreateTargets : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject flatball = null;
    
    public int RADIUS = 15; //radius of circles. NOT radius of the flatball.
    public double CENTER_DISTANCE = 10;
    public Material INSIDE_COLOR;
    public Material OUTSIDE_COLOR;
    public GameObject button;

    private static double theta = Math.PI / 12; //theta is rotation degree, radian 기준, 15도
    private static int ballCount = 25;

    private static float toDegree (double angle){
        float degree = (float)(angle * 180.0 / Math.PI) ;
        return degree;
    }

    void Start()
    {
        
    }

    public void onStartClicked(){
        setBall(RADIUS, CENTER_DISTANCE, INSIDE_COLOR);
        setBall(RADIUS*2, CENTER_DISTANCE*2, OUTSIDE_COLOR);
    }

    void setBall(int radius, double distance_from_center, Material ballcolor){
        double distance = Math.Sqrt( radius * radius + distance_from_center * distance_from_center );
        Debug.Log(distance);
        flatball.GetComponent<MeshRenderer>().material = ballcolor;

        for (int i = 0; i < ballCount; i++) {

            double sinValue = Math.Sin(theta * i);
            double cosValue = Math.Cos(theta * i);
            float yValue = (float)(radius * sinValue);
            float xValue = (float)(radius * cosValue);

            float zValue = (float)distance_from_center;

            float yRotation = 0;
            float zRotation = toDegree(theta * i);

            GameObject clone = Instantiate(
            flatball,
            transform.position + new Vector3(xValue ,yValue, zValue),
            Quaternion.Euler(0, yRotation, zRotation)
            );
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
