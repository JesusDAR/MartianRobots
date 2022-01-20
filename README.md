
# MartianRobots

SPA application to deploy robots that explore the surface of Mars.

To use it you need first to input the surface of Mars in X/Y coordinates, then set a new initial robot position, once done, with the arrow buttons a new position for the robot is assigned. The output window and information boxes will be updated during the process and creating a new surface for Mars will reset all the values to default.



## Prerequirements

* .NET 5 SDK

* Node JS

## Run Locally

Clone the project

```bash
  git clone https://github.com/JesusDAR/MartianRobots
```

Go to the WebApi project

```bash
 cd MartianRobots.WebApi
```

Start the WebApi

```bash
  dotnet run
```

Go to the Front project

```bash
 cd MartianRobots.Front
```
Install the needed dependencies

```bash
 npm install
```
Start the Front

```bash
  npm run serve
```