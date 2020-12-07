using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscillation : MonoBehaviour
{
    public float v0;

    private float alpha;
    private float l;
    private float A;
    private float omega0;
    private float t = 0;
    private float x0;
    private float g = 9.8f;
    

    private float phi(float x)
    {
        return A * Mathf.Sin(x * omega0 + alpha);
    }

    void Start()
    {
        l = transform.position.magnitude;
        x0 = Mathf.Atan2(transform.position.y, transform.position.x);
        omega0 = Mathf.Sqrt(g / l);
        if (v0 == 0)
        {
            alpha = -Mathf.PI / 2;
        }
        else
        {
            alpha = Mathf.Atan(x0 * omega0 / v0);
        }

        A = Mathf.Sqrt(Mathf.Pow(x0, 2) + Mathf.Pow(v0 / omega0, 2));

    }

    
    void FixedUpdate()
    {
        t += Time.fixedDeltaTime;
        transform.position = new Vector3(-Mathf.Sin(phi(t)) * l, -Mathf.Cos(phi(t)) * l, 0);
    }
}
