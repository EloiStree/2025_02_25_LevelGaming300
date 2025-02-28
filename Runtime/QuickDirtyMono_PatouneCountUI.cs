using UnityEngine;
using UnityEngine.Events;

public class QuickDirtyMono_PatouneCountUI : MonoBehaviour
{


    public CheckpointRaceMono m_source;
    public int m_totaleCount;
    public int m_activeCount;

    public float m_timeSinceStarted;

    public string m_format = "{0}/{1}";    
    public UnityEvent<string> m_onUpdateTextDebug;
    public UnityEvent<string> m_onSecondsChanged;
    public int m_seconds;

    [ContextMenu("Reset timer")]
    public void RestartTimer()
    {
        m_timeSinceStarted = 0;
    }

    public void Update()
    {
       
        m_totaleCount = m_source.m_checkpoints.Length;
        m_activeCount = 0;
        foreach (GameObject go in m_source.m_checkpoints)
        {
            if (go.activeSelf)
            {
                m_activeCount++;
            }
        }
        m_onUpdateTextDebug.Invoke(string.Format(m_format, m_activeCount, m_totaleCount));
        int seconds = m_seconds;
        m_seconds = Mathf.FloorToInt(m_timeSinceStarted);
        if (seconds != m_seconds)
        {
            m_onSecondsChanged.Invoke(m_seconds.ToString());
        }
        if(m_activeCount>0)
            m_timeSinceStarted += Time.deltaTime;
    }
}
