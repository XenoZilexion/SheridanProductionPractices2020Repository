using UnityEngine;

public class CameraControl : MonoBehaviour
{
    #region Variables
    public float m_DampTime = 0.2f;                 
    public float m_ScreenEdgeBuffer = 4f;           
    public float m_MinSize = 6.5f;
    public float m_MaxZoom = 15;
    [HideInInspector] public Transform[] m_Targets; 


    private Camera m_Camera;                        
    private float m_ZoomSpeed;                      
    private Vector3 m_MoveVelocity;                 
    private Vector3 m_DesiredPosition;
    #endregion
    #region StartRegion
    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }
    #endregion
    #region Updates
    private void FixedUpdate()
    {
        Move();
        Zoom();
    }
    #endregion
    #region Code
    private void Move()
    {
        FindAveragePosition();
        transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }
    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;
        for (int i = 0; i < m_Targets.Length; i++)
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue;
            averagePos += m_Targets[i].position;
            numTargets++;
        }
        if (numTargets > 0)
            averagePos /= numTargets;
        averagePos.y = transform.position.y;
        m_DesiredPosition = averagePos;
    }
    private void Zoom()
    {
        float requiredSize = FindRequiredSize();
        m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, requiredSize, ref m_ZoomSpeed, m_DampTime);
    }
    private float FindRequiredSize()
    {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(m_DesiredPosition);
        float size = 0f;
        for (int i = 0; i < m_Targets.Length; i++)
        {
            if (!m_Targets[i].gameObject.activeSelf)
                continue;
            Vector3 targetLocalPos = transform.InverseTransformPoint(m_Targets[i].position);
            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;
            size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.y));
            size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.x) / m_Camera.aspect);
        }
        // code modified to limit the zoom out of the camera to help prevent camera from showing excessive ammount of artless background even when the players are at an extreme distance from one another
        if (m_Targets.Length>=1&&Mathf.Abs(Vector3.Distance(m_Targets[0].transform.position, m_Targets[1].transform.position))>15)
        {
            size = m_MaxZoom;
        }
        else
        {
            size += m_ScreenEdgeBuffer;
            size = Mathf.Max(size, m_MinSize);
        }
        
        return size;
    }
    public void SetStartPositionAndSize()
    {
        FindAveragePosition();
        transform.position = m_DesiredPosition;
        m_Camera.orthographicSize = FindRequiredSize();
    }
    #endregion
}