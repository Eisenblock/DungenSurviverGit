using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private Transform m_transform;

    // Start is called before the first frame update
    void Start()
    {
        m_transform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        LAMouse();
    }

    private void LAMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint
            (Input.mousePosition) - m_transform.position;
        float angle = Mathf.Atan2 (direction.x, direction.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
