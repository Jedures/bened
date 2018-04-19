using UnityEngine;
using System.Collections;

public class MouseMove : MonoBehaviour
{

    public Transform target;
    public bool autoRotate = false;

    public float x = 0f;
    public float y = 2f;
    public float distance = 3f;
    public float distanceMin = 1f;
    public float distanceMax = 25f;
    public float offsetY = 0.5f;

    public float xSpeed = 0.1f;
    public float ySpeed = 0.25f;

    public float rotAngleX = 180f;
    public float rotAngleY = 180f;

    public float rotAngleYMin = 5f;
    public float rotAngleYMax = 45f;

    public GameObject joystick;

    private Vector3 targetPos = Vector3.zero;


    public void Update()
    {
#if UNITY_ANDROID
        foreach (Touch touch in Input.touches)
        {
            float distance = Vector2.Distance(new Vector2(joystick.gameObject.transform.position.x, joystick.transform.position.y), new Vector2(touch.position.x, touch.position.y));
            if (touch.phase == TouchPhase.Moved && distance > 3 && Input.touchCount < 3)
            {
                Rotate(touch.deltaPosition.x, touch.deltaPosition.y);  // тут может потребоваться коэффициент
            }
        }
#endif
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Rotate(Input.mousePosition.x, Input.mousePosition.y);
        }
#endif
    }
    /// <summary>
    /// Zoom camera
    /// </summary>

    public void Zoom(float zoom)
    {
        if (target && zoom != 0)
        {
            distance += zoom;
            if (distance < distanceMin)
                distance = distanceMin;
            if (distance > distanceMax)
                distance = distanceMax;
        }
    }


    /// <summary>
    /// Rotate camera around target
    /// </summary>

    public void Rotate(float x1, float y1)
    {
        x += x1 * xSpeed;
        y -= y1 * ySpeed;
        y = ClampAngle(y, rotAngleYMin, rotAngleYMax);
    }


    void LateUpdate()
    {
        if (target)
        {
            if (autoRotate)
                x += Time.deltaTime * xSpeed;
            else if (x != 0 && targetPos != target.position)
            {
                // Выравниваем камеру
                x = x > 0 ? x - 2 : x + 2;
                x = x > -2 && x < 2 ? 0 : x;
            }

            transform.position = target.position;
            //transform.rotation = Quaternion.Euler (target.transform.rotation.y + y, target.transform.rotation.x + x, 0);
            transform.rotation = target.transform.rotation;
            transform.Rotate(y, x, 0);
            transform.position = transform.position - (transform.forward * distance) + (transform.up * offsetY);

            targetPos = target.position;
        }
    }


    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }

}