# Unity-HexMetrcis
Unity Metrics System for hexagonal shape.

## Content
- **HexVector.cs** : Contains the HexVector structure. The HexVector structure is a coordinate system for hexagonal grids based on the axial coordinate system.

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
