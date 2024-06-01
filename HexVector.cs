using System;
using System.Linq;
using UnityEngine;

[Serializable] public struct HexVector
{
    public int q;
    public int r;

    public readonly int s => -(q + r);

    public HexVector(int q, int r)
    {
        this.q = q;
        this.r = r;
    }

    public static HexVector Zero => new(0, 0);

    public static HexVector SQ => new(1, 0);
    public static HexVector QR => new(-1, 1);
    public static HexVector RS => new(0, -1);

    public static HexVector[] Axis => new HexVector[] { SQ, -RS, QR, -SQ, RS, -QR };

    public static HexVector operator +(HexVector left, HexVector right) => new(left.q + right.q, left.r + right.r);
    public static HexVector operator -(HexVector hex) => new(-hex.q, -hex.r);
    public static HexVector operator -(HexVector left, HexVector right) => left + (-right);
    public static HexVector operator *(int left, HexVector right) => new(left * right.q, left * right.r);
    public static bool operator ==(HexVector left, HexVector right) => left.Equals(right);
    public static bool operator !=(HexVector left, HexVector right) => !(left == right);

    public override readonly bool Equals(object obj) => obj is HexVector hex && q == hex.q && r == hex.r;
    public override readonly int GetHashCode() => HashCode.Combine(q, r, s);
    public override readonly string ToString() => $"({q}, {r}, {s})";

    public readonly int Magnitude => Distance(this, Zero);

    public static HexVector Round(float q, float r, float s)
    {
        int _q = Mathf.RoundToInt(q);
        int _r = Mathf.RoundToInt(r);
        int _s = Mathf.RoundToInt(s);

        float dq = Mathf.Abs(_q - q);
        float dr = Mathf.Abs(_r - r);
        float ds = Mathf.Abs(_s - s);

        if ((dq > dr) && (dq > ds)) { _q = -(_r + _s); }
        else if (dr > ds) { _r = -(_q + _s); }

        return new HexVector(_q, _r);
    }

    public static HexVector Vector2ToHex(Vector2 vector, float size, bool flat)
    {
        float q = (flat ? 2f / 3f * vector.x : Mathf.Sqrt(3f) / 3f * vector.x - 1f / 3f * vector.y) / size;
        float r = (flat ? -1f / 3f * vector.x + Mathf.Sqrt(3f) / 3f * vector.y : 2f / 3f * vector.y) / size;

        return Round(q, r, -(q + r));
    }

    public static Vector2 HexToVector2(HexVector hex, float size, bool flat)
    {
        float x = size * (flat ? 3f / 2f * hex.q : Mathf.Sqrt(3f) * hex.q + Mathf.Sqrt(3f) / 2f * hex.r);
        float y = size * (flat ? Mathf.Sqrt(3f) / 2f * hex.q + Mathf.Sqrt(3f) * hex.r : 3f / 2f * hex.r);

        return new Vector2(x, y);
    }

    public static int Distance(HexVector start, HexVector end)
    {
        HexVector vector = end - start;
        return Mathf.Max(Mathf.Abs(vector.q), Mathf.Abs(vector.r), Mathf.Abs(vector.s));
    }

    public static HexVector HexRotation(HexVector hex, HexVector center, bool clockWise = false)
    {
        return center + (clockWise ? new HexVector(-hex.s, -hex.q) : new HexVector(-hex.r, -hex.s));
    }

    public static HexVector[] Line(HexVector start, HexVector end)
    {
        int len = Distance(start, end);

        HexVector[] results = new HexVector[0];

        for (int index = 0; index < len; index++)
        {
            float t = index * (1f / len);
            results = results.Append(Round(
                Mathf.Lerp(start.q, end.q, t),
                Mathf.Lerp(start.r, end.r, t),
                Mathf.Lerp(start.s, end.s, t)
            )).ToArray();
        }

        return results;
    }

    public static HexVector[] Ring(HexVector center, int radius)
    {
        HexVector[] results = new HexVector[0];

        HexVector hex = center + radius * Axis[0];
        foreach (HexVector axis in Axis)
        {
            for (int radial = 0; radial < radius; radial++)
            {
                results = results.Append(hex).ToArray();
                hex += axis;
            }
        }

        return results;
    }

    public static HexVector[] Range(HexVector center, int radius)
    {
        radius = Mathf.Abs(radius);

        HexVector[] results = new HexVector[0];
        for (int q = -radius; q <= radius; q++)
        {
            for (int r = Mathf.Max(-radius, -q - radius); r <= Mathf.Min(radius, -q + radius); r++)
            {
                results = results.Append(center + new HexVector(q, r)).ToArray();
            }
        }

        return results;
    }
}
