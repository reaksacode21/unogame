using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homescript : MonoBehaviour
{
    public GameObject panelhome;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void btnStart()
    {
        panelhome.SetActive(false);
    }  
    public void btnHome()
    {
        panelhome.SetActive(true);
    }
}
