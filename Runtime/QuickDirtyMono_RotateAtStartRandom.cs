using UnityEngine;

public class QuickDirtyMono_RotateAtStartRandom : MonoBehaviour
{
    public Vector3 m_rotationAxis = Vector3.forward;
    public Transform m_whatToRotate;
    public Space m_space = Space.Self;

    public bool m_useAtStart = false;

    public void Reset()
    {
        m_whatToRotate = transform;
    }

    void Start()
    {
        if(m_useAtStart)
            ApplyRotation();

    }

    [ContextMenu("Apply Rotation")]
    private void ApplyRotation()
    {
        m_whatToRotate.Rotate(m_rotationAxis, Random.Range(0, 360), m_space);
    }
}
