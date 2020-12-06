# Rc-Simulator

C# console application for simulating radio controlled cars in a two dimensional space.

From Rc-Simulator root folder execute "dotnet run --project RcSimulator" in a terminal to start the application. Run "dotnet test" to run unit tests.


## About
The application allows the user to test various commands and see if the radio controlled cars can execute them without hitting the wall. Currently the application only supports one type of car.

Following car commands are accepted: forward, back, left and right. Forward will make the car move forward 1 meter, back will make the car move backwards 1 meter, left will rotate the car 90° counter clockwise and right will rotate the car 90° clockwise.
 
The simulated environment is a two dimensional space seen as a room. The room size is specified in meters with two integers. 

The radio controlled car is seen as a round object with 1 meter in diameter and has a position as well as a heading. 

The application will prompt the user for the simulation room size, start position and heading of the radio controlled car and finally a commands series for the radio controlled car to execute.

When the user have specifed everything needed for the simulation the simulation will run and output the result.


## My thoughts
Simulator class and its prompt methods should probably be rewritten in a more dynamic way. E.g. calling the "Console.WriteLine()" call directly complicates a possible future conversion to gui application.  

Input parsing should probably be handled by another class than the Simulation class entirely.
