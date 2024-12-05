# ObjectInAreaSimulation
ObjectInAreaSimulation is a simple dotnet console app that will simulate an object moving, according a set of commands, over a defined area.
- On simulation setup the user will be promted to input high and width for the area and a set of starting coordinates for the object.
- After setup the simulation the simulation will read and execute an arbitrary stream of commands until instructed to end simulation and display result
- Simulation is succesful if object remains within the bounderies of the area.
- Successful simulations will print the current coordinates and an unsuccessful simulation will print [-1, -1]

### Available commands
	0 = End Simulation and print result
    1 = Move forward one step
    2 = Move backwards one step
    3 = Rotate clockwise 90 degrees (eg north to east)
    4 = Rotate counter-clockwise 90 degrees (eg west to south)

### Simulation conditions
	- If multiple commands are provided, any command followed by '0' will be ignored",
    - Invalid Commands will be ignored and the simulation will proceed to the next command"

## Requirements
- dotnet 8.0 (https://dotnet.microsoft.com/download/dotnet/8.0)

## Run simulation in console
1. Open console
2. Navigate to `.../ObjectInAreaSimulation/ObjectInAreaSimulation`:
3. Run the following commands: 
	```
	dotnet build
	dotnet run
	```