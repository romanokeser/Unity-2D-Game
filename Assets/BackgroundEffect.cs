using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundEffect : MonoBehaviour
{
    [SerializeField] private Material material;

    private Transform player;
    public Transform Player { get => player; set => player = value; }

    private void Update()
    {
        ShaderTest2();
    }

    private void ShaderTest2()
    {
        float distance = Vector2.Distance(player.transform.position, this.gameObject.transform.position);

        float a = material.GetFloat("_FlashSpeed");
        //Debug.Log(distance + " " +a);


        float b = Mathf.InverseLerp(0.1f, 4.0f, distance);

        Debug.Log(b);

        material.SetFloat("_FlashSpeed", b * 1.0f);
    }
}
