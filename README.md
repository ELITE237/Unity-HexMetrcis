# Unity-HexMetrcis
Unity Metrics System for hexagonal grid.

## Content
- **HexVector.cs** : Contains the HexVector structure. It's a coordinate system based on the [axial coordinate system](https://gamedevelopment.tutsplus.com/introduction-to-axial-coordinates-for-hexagonal-tile-based-games--cms-28820t).
- **HexPolar.cs** : Contains the HexPolar structure. It's a coordinate system of my own thinking (well, I think) that takes up the principle of the [polar coordinates of the plane](https://fr.wikipedia.org/wiki/Coordonn%C3%A9es_polaires) to adapt it to the hexagonal grids.
- **HexMetrics.cs** : Contains the HexMetrics static class. It encompasses a set of functions that can be useful in hexagonal grids.

## Documentation

### HexVector Structure
- **int HexVector.q** : Value on q-axis.
- **int HexVector.r** : Value on r-axis.
- **int HexVector.s** : Value on s-axis automatically calculated using the formula s = -(q + r).
- **HexVector HexVector.Zero** : Null vector.
- **HexVector HexVector.SQ** : Unit vector of r-axis.
- **HexVector HexVector.QR** : Unit vector of s-axis.
- **HexVector HexVector.RS** : Unit vector of q-axis.
- **HexVector[] HexVector.Axis** : The 6 counterclockwise unit vectors.
- **HexVector -(HexVector hex)** : Returns the opposite vector.
- **HexVector -(HexVector left, HexVector right)** : Returns the substract result vector.
- **HexVector +(HexVector left, HexVector right)** : Returns the add result vector.
- **HexVector \*(int left, HexVector right)** : Returns the scale result vector.
- **HexVector \*(HexVector left, int right)** : Returns the scale result vector.
- **bool ==(HexVector left, HexVector right)** : Commpare the equality between the coordinates of the two vectors.
- **bool !=(HexVector left, HexVector right)** : Denial of ==.
- **int HexVector.Magnitude** : The length of the vector.
- **HexVector HexVector.Round(float q, float r, float s)** : Round the float coordinates to int
- **HexVector HexVector.Vector2ToHex([Vector2](https://docs.unity3d.com/ScriptReference/Vector2.html) vector, float size, bool flat)** : Convert the Cartesian coordinates of the plane to axial coordinates.
- **[Vector2](https://docs.unity3d.com/ScriptReference/Vector2.html) HexVector.HexToVector2(HexVector hex, float size, bool flat)** : Convert the axial coordinates to Cartesian coordinates of the plane.
- **int HexVector.Distance(HexVector start, HexVector end)** : Returns the distance in number of hexes between the two points.
- **HexVector HexVector.HexRotation(HexVector hex, HexVector center, bool clockwise = false)** : Returns the rotation of the point by the center and angle PI/3.
- **HexVector[] HexVector.Line(HexVector start, HexVector end)** : Returns the set of points that make up the line between the start and the end.
- **HexVector[] HexVector.Ring(HexVector center, int radius)** : Returns the set of points whose distance from the center is equal to the radius.
- **HexVector[] HexVector.Range(HexVector center, int radius)** : Returns the set of points whose distance from the center is less than or equal to the radius.

### HexPolar Structure
- **int HexPolar.m** : It is the radial coordinate that represents the distance from the center.
- **int HexPolar.a** : It is the angular coordinate taht represents the counterclockwise angle between the point and the semi-straight line of angle 0°.
- **int HexPolar.Range** : It is the absolute value of distance coordinate (*it is recommended that you use this property instead of HexPolar.m*).
- **int HexPolar.Angle** : It is the equivalent of the angular coordinate clamped between [0, 6 * Range[. The equivalent value in radians is in the range [0, 2 * PI[. (*it is recommended that you use this property instead of HexPolar.a*).
- **int HexPolar.SignedAngle** : It is the equivalent of the angular coordinate clamped between ]-3 * Range, 3 * Range]. The equivalent value in radians is in the range ]-PI, PI].
- **HexPolar HexPolar.Zero** : Null polar.
- **HexPolar -(HexPolar hex)** : Returns the opposite polar.
- **HexPolar -(HexPolar left, HexPolar right)** : Returns the substract result polar.
- **HexPolar +(HexPolar left, HexPolar right)** : Returns the add result polar.
- **HexPolar \*(int left, HexPolar right)** : Returns the scale result polar.
- **HexPolar \*(HexPolar left, int right)** : Returns the scale result polar.
- **bool ==(HexPolar left, HexPolar right)** : Commpare the equality between the coordinates of the two polar.
- **bool !=(HexPolar left, HexPolar right)** : Denial of ==.
- **HexPolar HexPolar.Vector2ToHex([Vector2](https://docs.unity3d.com/ScriptReference/Vector2.html) vector, float size, bool flat, bool floret = false)** : Convert the Cartesian coordinates of the plane to HexPolar coordinates.
- **[Vector2](https://docs.unity3d.com/ScriptReference/Vector2.html) HexPolar.HexToVector2(HexPolar hex, float size, bool flat, bool floret = false)** : Convert the HexPolar coordinates to Cartesian coordinates of the plane.
- **int HexPolar.Distance(HexPolar start, HexPolar end)** : Returns the distance in number of hexes between the two points.
- **HexPolar[] HexPolar.Ring(HexPolar center, int radius)** : Returns the set of points whose distance from the center is equal to the radius.
- **HexPolar[] HexPolar.Range(HexPolar center, int radius)** : Returns the set of points whose distance from the center is less than or equal to the radius.
