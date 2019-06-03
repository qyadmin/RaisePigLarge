using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    public static CameraMove Instance;
    private Vector3 startFingerPos;
    private Vector3 nowFingerPos;
    private float xMoveDistance;
    private float yMoveDistance;
    private int backValue = 0;
    private int updownValue = 0;
    public GameObject my_Cube;
    public float TouchSpeed = 1;

    float distance = 0;//触控缩放的距离
    private float lastDist = 0;//用于计算触控缩放
    private float curDist = 0;//用于计算触控缩放
    int t;//判断缩放触控

    public bool IsLock = false;

    public bool IsTurnAround = false;


    public bool BigLock = false;
    [SerializeField]
    Transform Min, Max;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        InvokeRepeating("Timesecond", 0, 0.1f);
    }

    void Timesecond()
    {
        Lastx = x;
        Lasty = y;
    }

    void Update()
    {
        //没有触摸  
        if (!IsLock)
        {
#if UNITY_EDITOR
            JudgeFinger();
#elif UNITY_STANDALONE_WIN
                   JudgeFinger();
#elif UNITY_IPHONE
                    JudgeFinger();
#elif UNITY_ANDROID
                    JudgeFinger();
#endif

        }

        //      if ( (Input.touchCount>1) && (Input.GetTouch(0).phase==TouchPhase.Moved||Input.GetTouch(1).phase==TouchPhase.Moved))
        //{

        //	var touch1 = Input.GetTouch(0); //第一根手指
        //	var touch2 = Input.GetTouch(1); //第二根手指

        //	curDist = Vector2.Distance(touch1.position, touch2.position);//两指间距

        //	//当手指移动时，重置起始距离为当前距离
        //	if( t==0 )
        //	{
        //		lastDist = curDist;
        //		t=1;
        //	}
        //	distance=curDist-lastDist;
        //	if (distance > 0) 
        //	{
        //		if (Vector3.Distance (my_Cube.transform.position, transform.position) < 4)
        //			IsLock = true;
        //	}
        //	if (!IsLock)
        //		transform.position = Vector3.MoveTowards (transform.position, my_Cube.transform.position, Time.deltaTime * distance * 0.2f);
        //	else
        //	{
        //		if(distance<0)
        //			IsLock = false;
        //	}
        //	lastDist = curDist;
        //}

        ////没有触控事件
        //if( Input.touchCount==0 )
        //	t=0;
    }

    public void JudgeMouse()
    {
        //没有触摸  
        if (Input.touchCount <= 0 || Input.touchCount > 1)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            startFingerPos = Input.GetTouch(0).position;
        }

        nowFingerPos = Input.GetTouch(0).position;

        if ((Input.GetTouch(0).phase == TouchPhase.Stationary) || (Input.GetTouch(0).phase == TouchPhase.Ended))
        {

            startFingerPos = nowFingerPos;
            return;
        }
        if (startFingerPos == nowFingerPos)
        {
            return;
        }
        xMoveDistance = Mathf.Abs(nowFingerPos.x - startFingerPos.x);

        yMoveDistance = Mathf.Abs(nowFingerPos.y - startFingerPos.y);

        if (nowFingerPos.x - startFingerPos.x > 0)
        {
            backValue = -1; //沿着X轴负方向移动  
        }
        else
        {
            backValue = 1; //沿着X轴正方向移动  
        }


        if (nowFingerPos.y - startFingerPos.y > 0)
        {
            updownValue = 2; //沿着Y轴正方向移动  
        }
        else
        {
            updownValue = -2; //沿着Y轴负方向移动  
        }

        if (backValue == 1)
        {
            //my_Cube.transform.Rotate(Vector3.up * Time.deltaTime * xMoveDistance*0.6f, Space.World);
            this.transform.Translate(Vector3.left * Time.deltaTime * xMoveDistance * 0.1f * TouchSpeed, Space.World);
        }
        else if (backValue == -1)
        {
            //my_Cube.transform.Rotate(Vector3.up* -1 * Time.deltaTime * xMoveDistance*0.6f, Space.World);
            this.transform.Translate(Vector3.left * -1 * Time.deltaTime * xMoveDistance * 0.1f * TouchSpeed, Space.World);
        }

        if (updownValue == 2)
        {
            //my_Cube.transform.Rotate(Vector3.up * Time.deltaTime * xMoveDistance*0.6f, Space.World);
            this.transform.Translate(Vector3.forward * Time.deltaTime * yMoveDistance * 0.2f * TouchSpeed, Space.World);
        }
        else if (updownValue == -2)
        {
            //my_Cube.transform.Rotate(Vector3.up* -1 * Time.deltaTime * xMoveDistance*0.6f, Space.World);
            this.transform.Translate(Vector3.forward * -1 * Time.deltaTime * yMoveDistance * 0.2f * TouchSpeed, Space.World);
        }
    }
    float xSave = 1;
    float ySave = 1;
    Transform center;
    Vector3 lookedPosition;
    Quaternion q;
    Vector3 direction;



    float x = 0;
    float y = 0;
    float Lastx = 0;
    float Lasty = 0;

    public void JudgeFinger()
    {
        //没有触摸  
        if (Input.touchCount <= 0 || Input.touchCount > 1)
        {
            return;
        }

        if ((Input.GetMouseButtonDown(0) || Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved))
        {
#if IPHONE || ANDROID
			        if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#else
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
#endif
            {
                return;
            }
        }

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            x = Input.GetTouch(0).position.x * 0.01f * TouchSpeed;
            y = Input.GetTouch(0).position.y * 0.01f * TouchSpeed;
            Lastx = x;
            Lasty = y;
            startFingerPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            x = Input.GetTouch(0).position.x * 0.01f * TouchSpeed;
            y = Input.GetTouch(0).position.y * 0.01f * TouchSpeed;
        }

        nowFingerPos = Input.GetTouch(0).position;

        if ((Input.GetTouch(0).phase == TouchPhase.Stationary) || (Input.GetTouch(0).phase == TouchPhase.Ended))
        {

            startFingerPos = nowFingerPos;
            return;
        }
        if (startFingerPos == nowFingerPos)
        {
            return;
        }
        StopAllCoroutines();
        xMoveDistance = Mathf.Abs(nowFingerPos.x - startFingerPos.x);
        yMoveDistance = Mathf.Abs(nowFingerPos.y - startFingerPos.y);
        if (!IsTurnAround)
        {
            float chazhix = x - Lastx;
            float chazhiz = y - Lasty;
            if (transform.position.x <= Max.position.x && chazhix > 0)
            {
                transform.Translate(x - Lastx, 0, 0, Space.World);
                Debug.Log("X+++" + "  " + transform.position.x + "   " + Max.transform.position.x);
            }
            if (transform.position.z <= Max.position.z && chazhiz > 0)
            {
                transform.Translate(0, 0, y - Lasty, Space.World);
                Debug.Log("Y+++" + "  " + transform.position.z + "   " + Max.transform.position.z);
            }
            if (transform.position.x >= Min.position.x && chazhix < 0)
            {
                transform.Translate(x - Lastx, 0, 0, Space.World);
                Debug.Log("X---" + "  " + transform.position.x + "   " + Max.transform.position.x);
            }
            if (transform.position.z >= Min.position.z && chazhiz < 0)
            {
                transform.Translate(0, 0, y - Lasty, Space.World);
                Debug.Log("Y---" + "  " + transform.position.z + "   " + Max.transform.position.z);
            }
        }

        if (nowFingerPos.x - startFingerPos.x > 0)
        {
            backValue = -1; //沿着X轴负方向移动  
        }
        else
        {
            backValue = 1; //沿着X轴正方向移动  
        }
        if (nowFingerPos.y - startFingerPos.y > 0)
        {
            updownValue = 2; //沿着Y轴正方向移动  
        }
        else
        {
            updownValue = -2; //沿着Y轴负方向移动  
        }
        if (backValue == 1)
        {
            if (IsTurnAround)
            {
                xSave = xSave - xMoveDistance * Time.deltaTime * 0.5f;
                ySave = ySave - yMoveDistance * Time.deltaTime * 0.5f;

                //center = ModleClick.Instance.Target_.transform;
                center = my_Cube.transform;
                lookedPosition = new Vector3(center.transform.position.x, center.transform.position.y + height, center.transform.position.z);
                RotateLookPos = new Vector3(center.transform.position.x, center.transform.position.y + rotateheight, center.transform.position.z);
                q = Quaternion.Euler(0, xSave, ySave);
                direction = q * Vector3.forward;
                this.transform.position = lookedPosition - direction * distances;
                this.transform.LookAt(RotateLookPos);
            }
        }
        else if (backValue == -1)
        {
            if (IsTurnAround)
            {
                xSave = xSave + xMoveDistance * Time.deltaTime * 0.5f;
                ySave = ySave + yMoveDistance * Time.deltaTime * 0.5f;
                //center = ModleClick.Instance.Target_.transform;
                center = my_Cube.transform;
                lookedPosition = new Vector3(center.transform.position.x, center.transform.position.y + height, center.transform.position.z);
                RotateLookPos = new Vector3(center.transform.position.x, center.transform.position.y + rotateheight, center.transform.position.z);
                q = Quaternion.Euler(0, xSave, ySave);
                direction = q * Vector3.forward;
                this.transform.position = lookedPosition - direction * distances;
                this.transform.LookAt(RotateLookPos);
            }
        }
    }
    Vector3 RotateLookPos;
    public float distances = 3.0f;
    public float height = 1.0f;
    public float damping = 5.0f;
    public float targetheight = 2f;
    public float rotateheight = 0f;

    public void TargetMove(Transform target)
    {
        if (!BigLock)
            return;
        StopAllCoroutines();
        IsTurnAround = true;
        StartCoroutine("TargetMoving", target);
    }

    Vector3 wantedPosition;
    Vector3 lookPosition;
    IEnumerator TargetMoving(Transform target)
    {
        wantedPosition = target.TransformPoint(0, height, -distances);
        lookPosition = new Vector3(target.transform.position.x, target.transform.position.y + targetheight, target.transform.position.z);
        ModleClick.Instance.BigLock = true;
        IsLock = true;
        while (Vector3.Distance(transform.position, wantedPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * damping);
            transform.rotation = Quaternion.LookRotation(lookPosition - transform.position, target.up);
            yield return null;
        }
        IsLock = false;
    }



    [SerializeField]
    Transform InitiPos;
    public void CameraReset()
    {
        if (!BigLock)
            return;
        StopAllCoroutines();
        StartCoroutine("ResetMoving");
    }
    IEnumerator ResetMoving()
    {
        IsLock = true;

        while (Vector3.Distance(transform.position, InitiPos.position) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, InitiPos.position, Time.deltaTime * damping);
            transform.rotation = Quaternion.Lerp(transform.rotation, InitiPos.rotation, Time.deltaTime * damping);
            yield return null;
        }
        IsTurnAround = false;
        IsLock = false;

    }
}
