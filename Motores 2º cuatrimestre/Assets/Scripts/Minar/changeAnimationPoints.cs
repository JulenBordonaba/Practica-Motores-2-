using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeAnimationPoints : MonoBehaviour
{
    public int points;
    public Text txtPoints;
    // Start is called before the first frame update
    void Start()
    {
        txtPoints.text = points.ToString();
        if(points>=0)
            txtPoints.color = Color.green;
        else
            txtPoints.color = Color.red;
        
    }

}
