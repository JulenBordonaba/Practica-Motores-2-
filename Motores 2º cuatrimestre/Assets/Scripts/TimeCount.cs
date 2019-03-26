using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    public Text timeText;
    public float time;
    public static TimeCount i;

    // Start is called before the first frame update
    void Start()
    {
        i = this;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
    }
}
