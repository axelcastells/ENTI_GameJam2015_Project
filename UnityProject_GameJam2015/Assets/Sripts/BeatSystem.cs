using UnityEngine;
using System.Collections;

public static class BeatSystem {

    public static float beatRateMaster = 1f;
    public static float beatRateCurrent = 0;

    public static bool SetTheBeat()
    {
        if (beatRateCurrent >= beatRateMaster)
        {
            beatRateCurrent = 0;
            return true;
        }

        beatRateCurrent += (1 * Time.deltaTime);

        return false;
    }
}
