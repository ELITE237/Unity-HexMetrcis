# Unity-HexMetrcis
Unity Metrics System for hexagonal shape.

## Content
- **HexVector.cs** : Contains the HexVector structure. The HexVector structure is a coordinate system for hexagonal grids based on the axial coordinate system.

## Documentation

### HexVector Structure
- **int HexVector.q** : value on q-axis.
- **int HexVector.r** : value on r-axis.
- **int HexVector.s** : value on s-axis automatically calculated using the formula s = -(q + r).
