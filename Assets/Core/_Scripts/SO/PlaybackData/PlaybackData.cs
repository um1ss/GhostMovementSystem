using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Playback Data", menuName = "Playback/Playback Data")]
public class PlaybackData : ScriptableObject
{
    [System.Serializable]
    public class FrameData
    {
        public Vector3 position;
        public Quaternion rotation;
    }

    public List<FrameData> frames = new List<FrameData>();

    public void Clear()
    {
        frames.Clear();
    }
}