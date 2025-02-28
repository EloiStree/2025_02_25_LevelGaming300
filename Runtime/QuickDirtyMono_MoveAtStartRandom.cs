using UnityEngine;

public class QuickDirtyMono_MoveAtStartRandom : MonoBehaviour
{

    public Vector3 m_moveDirection = Vector3.forward;
    public float m_distanceToMove = 1;
    public Transform m_center;
    public Transform m_whatToRotate;
    public Space m_space = Space.Self;

    public bool m_useAtStart = false;

    public void Reset()
    {
        m_whatToRotate = transform;
    }

    void Start()
    {
        if (m_useAtStart)
            ApplyMove();

    }

    [ContextMenu("Apply Rotation")]
    private void ApplyMove()
    {
        Vector3 vector3 = Random.insideUnitSphere;
        vector3 = new Vector3(
            vector3.x * m_moveDirection.x,
            vector3.y * m_moveDirection.y ,
            vector3.z * m_moveDirection.z );
        m_whatToRotate.position = m_center.position;
        m_whatToRotate.Translate(vector3 * m_distanceToMove, m_space);
    }
}
