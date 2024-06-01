# Unity-HexMetrcis
Unity Metrics System for hexagonal shape.

## Content
- **HexVector.cs** : Contains the HexVector structure. The HexVector structure is a coordinate system for hexagonal grids based on the [axial coordinate system](https://www.redblobgames.com/grids/hexagons/#coordinates-axial).

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
- **[Vector2](https://docs.unity3d.com/ScriptReference/Vector2.html) HexVector.HexToVector2(Hexvector hex, float size, bool flat)** : Convert the axial coordinates to Cartesian coordinates of the plane.
- **int HexVector.Distance(HexVector start, HexVector end)** : Returns the distance in number of hexes between the two points.
- **HexVector HexVector.HexRotation(HexVector hex, HexVector center, bool clockWise = false)** : Returns the rotation of the point by the center and angle PI/3.
- **HexVector[] HexVector.Line(HexVector start, HexVector end)** : Returns the set of points that make up the line between the start and the end.
- **HexVector[] HexVector.Ring(Hexvector center, int radius)** : Returns the set of points whose distance from the center is equal to the radius.
- **HexVector[] HexVector.Range(HexVector center, int radius)** : Returns the set of points whose distance from the center is less than or equal to the radius.
