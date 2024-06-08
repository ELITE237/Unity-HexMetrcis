using System;
using UnityEngine;

public static class HexMetrics
{
    public static float HexAngleOffset(bool flat, bool floret) => (flat ? 0 : -Mathf.PI / 6) + (floret ? -19f * Mathf.Deg2Rad : 0f);

    public static HexPolar VectorToPolar(HexVector vector)
    {
        int radius = vector.Magnitude;

        if (radius == 0)
        {
            return HexPolar.Zero;
        }
        else if (Mathf.Abs(vector.q) == radius)
        {
            return vector.q < 0 ? new HexPolar(radius, 2 * radius + vector.s) : new HexPolar(radius, 5 * radius - vector.s);
        }
        else if (Mathf.Abs(vector.r) == radius)
        {
            return vector.r < 0 ? new HexPolar(radius, radius - vector.q) : new HexPolar(radius, 4 * radius + vector.q);
        }
        else
        {
            return vector.s < 0 ? new HexPolar(radius, vector.r) : new HexPolar(radius, 3 * radius - vector.r);
        }
    }

    public static HexVector PolarToVector(HexPolar polar)
    {
        int offset = polar.Radius == 0 ? 0 : polar.Angle % polar.Radius;
        int hexCount = polar.Radius == 0 ? 0 : (polar.Angle - offset) / polar.Radius;

        return polar.Radius * HexVector.Axis[hexCount] + offset * HexVector.Axis[(hexCount + 2) % 6];
    }
}
