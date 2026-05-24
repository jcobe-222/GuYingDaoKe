using System.Collections;
using UnityEngine;
public class HitStop: MonoBehaviour
{
    public static HitStop Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void StopTime(float duration)
    {
        StartCoroutine(Stop(duration));
    }
    IEnumerator Stop(float duration)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1;
    }
}
