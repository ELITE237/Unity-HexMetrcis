using System;
using System.Linq;
using UnityEngine;

[Serializable]
public struct HexPolar
{
    public int m;
    public int a;

    public int Radius { readonly get => Mathf.Abs(m); set => m = value; }
    public int Angle { readonly get => Radius == 0 ? 0 : a - Mathf.RoundToInt(a / (6f * Radius)); set => a = value; }
    public int SignedAngle { readonly get => 1 - (3 * Radius) + Angle; set => a = value; }

    public HexPolar(int m, int a)
    {
        this.m = m;
        this.a = a;
    }

    public static HexPolar Zero => new(0, 0);

    public static HexPolar operator +(HexPolar left, HexPolar right) => new(left.Radius + right.Radius, Mathf.RoundToInt((left.Angle + right.a) / 2f));
    public static HexPolar operator -(HexPolar hex) => new(hex.Radius, hex.Angle + 3 * hex.Radius);
    public static HexPolar operator -(HexPolar left, HexPolar right) => left + (-right);
    public static HexPolar operator *(int left, HexPolar right) => new(left * right.Radius, right.Angle);
    public static HexPolar operator *(HexPolar left, int right) => right * left;
    public static bool operator ==(HexPolar left, HexPolar right) => left.Equals(right);
    public static bool operator !=(HexPolar left, HexPolar right) => !(left == right);

    public override readonly bool Equals(object obj) => obj is HexPolar hex && Radius == hex.Radius && Angle == hex.Angle;
    public override readonly int GetHashCode() => HashCode.Combine(m, a);
    public override readonly string ToString() => $"({m}, {a})";

    private static float SizeFactor => Mathf.Sqrt(3);
    private static float MaxAngle => 2 * Mathf.PI;
    private static float AngleOffset(bool flat, bool floret) => flat ^ floret ? Mathf.PI / 6f : 0f;

    public static HexPolar Vector2ToHex(float radius, float angle, float size, bool flat, bool floret = false)
    {
        int hexRadius = Mathf.RoundToInt(radius / (SizeFactor * size));

        if (hexRadius == 0) { return Zero; }

        angle -= AngleOffset(flat, floret);
        angle -= Mathf.RoundToInt(angle / MaxAngle) * MaxAngle;

        int hexAngle = Mathf.RoundToInt(6 * hexRadius * angle / MaxAngle);

        return new HexPolar(hexRadius, hexAngle);
    }

    public static HexPolar Vector2ToHex(Vector2 vector, float size, bool flat, bool floret = false)
    {
        float offset = vector.y < 0 ? (vector.x < 0 ? Mathf.PI : MaxAngle) : (vector.x < 0 ? Mathf.PI : 0f);
        float angle = offset + Mathf.Atan(vector.y / vector.x);

        return Vector2ToHex(vector.magnitude, angle, size, flat, floret);
    }

    public static Vector2 HexToVector2(HexPolar hex, float size, bool flat, bool floret = false)
    {
        float magnitude = SizeFactor * size * hex.Radius;

        if (magnitude == 0f) { return Vector2.zero; }

        float angle = AngleOffset(flat, floret) + (MaxAngle * hex.Angle / (6 * hex.Radius));

        return magnitude * new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    public static int Distance(HexPolar start, HexPolar end)
    {
        return Mathf.Abs(end.Radius - start.Radius);
    }

    public static HexPolar[] Ring(HexPolar center, int radius)
    {
        HexPolar[] results = new HexPolar[0];
        for (int angle = 0; angle < 6 * radius; angle++)
        {
            results = results.Append(new HexPolar(radius, angle) + center).ToArray();
        }

        return results;
    }

    public static HexPolar[] Range(HexPolar center, int radius)
    {
        HexPolar[] results = new HexPolar[0];
        for (int radial = 0; radial < radius; radial++)
        {
            results = results.Concat(Ring(center, radial)).ToArray();
        }

        return results;
    }
}
