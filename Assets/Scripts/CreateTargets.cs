using UnityEngine;
using System;
using System.Collections;

public class CreateTargets : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject flatball = null;
    
    public int RADIUS = 5; //radius of circles' trajectory. NOT radius of the flatball.
    public double CENTER_DISTANCE = 5;
    public Material INSIDE_COLOR;
    public Material OUTSIDE_COLOR;

    private int ballCount = 25;
    private int[] balls = new int[25]{0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24};
    private static System.Random rnd = new System.Random();

    public GameObject button;

    public void onStartClicked(){
        setBall(RADIUS, CENTER_DISTANCE, INSIDE_COLOR);
        //setBall(RADIUS*2, CENTER_DISTANCE*2, OUTSIDE_COLOR);
    }

    private float toDegree (double angle){
        float degree = (float)(angle * 180.0 / Math.PI) ;
        return degree;
    }

    void deleteElement(int x) 
         {   
        // Search x in array 
        int index; 
        for (index = 0; index < ballCount; index++) {
            if (balls[index] == x) break;} 
  
        // If x found in array
        // reduce size of array and move all elements on space ahead 
        if (index < ballCount) 
        {      
        ballCount = ballCount - 1; 
        for (int j = index; j < ballCount; j++) 
            balls[j] = balls[j+1]; 
        }
        
    } 

    double setRandomAngle(){
        //init theta
        int ballNowIndex = rnd.Next(0,ballCount); 
        int ballNow = balls[ballNowIndex];
        Debug.Log("ballNow : " + (ballNow).ToString());
        double theta = Math.PI / 12 * ballNow;

        // Delete ballNow from balls[] 
        deleteElement(ballNow); 
        
        return theta;
    }

    void setBall(int radius, double distance_from_center, Material ballcolor){
        
        //theta is rotation degree, radian 기준, 15도
        
        double distance = Math.Sqrt( radius * radius + distance_from_center * distance_from_center );
       
        flatball.GetComponent<MeshRenderer>().material = ballcolor;

        double theta = setRandomAngle();
        Debug.Log("arrayLength : " + (ballCount).ToString());
        double sinValue = Math.Sin(theta);
        double cosValue = Math.Cos(theta);
        float yValue = (float)(radius * sinValue);
        float xValue = (float)(radius * cosValue);

        float zValue = (float)distance_from_center;

        float yRotation = 0;
        float zRotation = toDegree(theta);

        GameObject clone = Instantiate(
        flatball,
        transform.position + new Vector3(xValue ,yValue, zValue),
        Quaternion.Euler(0, yRotation, zRotation)
        );
        

    }

    void Start()
    { }
    // Update is called once per frame
    void Update()
    {

    }
}
