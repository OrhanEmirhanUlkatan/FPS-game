using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    float _rotateSpeed = 2;

    void Start ()
    {
		
	}
	
	
	void Update ()
    {
        transform.Rotate(_rotateSpeed * Time.deltaTime, 0, 0);
    }
}
