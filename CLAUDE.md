# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

```bash
# Build the solution
dotnet build OrbitalMechanics.sln

# Run all tests
dotnet test OrbitalMechanicsTests/OrbitalMechanicsTests.csproj

# Run a single test
dotnet test OrbitalMechanicsTests/OrbitalMechanicsTests.csproj --filter "FullyQualifiedName~TestName"

# Run tests with coverage
dotnet test OrbitalMechanicsTests/OrbitalMechanicsTests.csproj --collect:"XPlat Code Coverage"
```

## Architecture

This is a C# (.NET) 2-body orbital mechanics library targeting `netstandard2.0`. It models Keplerian orbits and solves for position over time.

### Core Design

The library uses a **Strategy pattern**: an abstract `ISolver` base class defines the interface for orbital calculations, with concrete implementations for different orbit types.

**Data flow:** `Orbit` (Keplerian elements) → `ISolver` subclass → `Offset` (X/Y position)

### Key Classes

- **`Orbit`** — Stores the 6 Keplerian orbital elements (semi-major axis, eccentricity, inclination, longitude of ascending node, argument of periapsis, periapsis epoch). Setting `SemiMajorAxis_m` or `Eccentricity` triggers automatic recalculation of periapsis/apoapsis via `CalculateApsides()`. Contains an internal `Ellipse` instance.

- **`Ellipse`** — Pure math for an ellipse: semi-minor axis (`b = a√(1-e²)`) and focal distance.

- **`ISolver`** (abstract) — Base solver with shared anomaly calculations:
  - `CalculateOrbitalPeriod_sec()`: Kepler's 3rd law `T = 2π√(a³/GM)`
  - `CalculateMeanAnomaly()`, `CalculateEccentricAnomaly()` (iterative, max 12 iterations, tolerance 10⁻⁸), `CalculateTrueAnomaly()`
  - Abstract methods: `GetOrbitAngle_deg()`, `CalculateOffset_m()`

- **`CircleSolver`** — Handles circular orbits (eccentricity = 0). Position is `(cos(M)·a, sin(M)·a)` where M is mean anomaly.

- **`EllipseSolver`** — Handles elliptical orbits. **Currently broken**: position calculation based on eccentric anomaly is incorrect (see known issues).

- **`Numbers`** — Static physics constants (`G`, `C`) and unit conversion factors (AU, km, solar masses, time units).

- **`Offset`** — Simple 2D position wrapper (X, Y as doubles).

### Known Issues

- **`EllipseSolver` position calculation is incorrect** for default starting positions. The eccentric anomaly → Cartesian conversion is wrong. Several orbital period/position tests in `SolverTest.cs` are commented out because of this.
- `PlanetOrbits.cs` in the test project contains real planetary orbital data (Mercury through Neptune + Moon) for use as test fixtures once the solver is fixed.
