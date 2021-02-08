using UnityEngine;
using System;
using System.Collections;

public class CreateTargets : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject flatball = null;
    private int ballCount = 5;
    public int radius = 3;

    private static float toDegree (double angle){
        float degree = (float)(angle * 180.0 / Math.PI) ;
        return degree;
    }

    void Start()
    {
        //theta is rotation degree, radian 기준
        // 0 <= theta <= PI , - PI/2 <= alpha <= 0 
        double theta = (Math.PI / (ballCount - 1));
        double alphaRange = - Math.PI / 4;

        System.Random rnd = new System.Random();
        double alpha = rnd.NextDouble() * alphaRange;
        

        for (int i = 0; i < ballCount; i++) {

            double sinValue = Math.Sin(theta * i);
            double cosValue = Math.Cos(theta * i);
            float xValue = (float)(radius * sinValue);
            float zValue = (float)(radius * cosValue);
            
            float yValue = (float)(Math.Abs(radius* Math.Sin(alpha)));

            float yRotation = toDegree(theta * i);
            float xRotation = toDegree(alpha);

            GameObject clone = Instantiate(
            flatball,
            transform.position + new Vector3(xValue ,yValue, zValue),
            Quaternion.Euler(xRotation, yRotation, 0)
            );
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
