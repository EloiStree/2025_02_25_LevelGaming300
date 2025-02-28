using UnityEngine;

public class QuickDirtyMono_TouchToTeleport : MonoBehaviour
{
    public Transform m_teleportTarget;
    public bool m_usePlayerTag=true;
    public void OnCollisionEnter(Collision collision)
    {
        if (m_usePlayerTag && !collision.transform.CompareTag("Player"))
            return;

        Transform rigPlayer= collision.rigidbody.transform;
        if (rigPlayer == null)
            return;

        if (m_teleportTarget == null)
            return;

        rigPlayer.position = m_teleportTarget.position;
    }
}
