using UnityEngine;
using System.Collections;
public class HitStopManager : MonoBehaviour
{
    public static HitStopManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void Stop(float duration)
    {
        StartCoroutine(HitStop(duration));
    }
    IEnumerator HitStop(float duration)
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1f;
    }
}
