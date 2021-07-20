# RobotCodeChallenge

The application is a simulation of a toy robot moving on a square table top, of
dimensions 5 units x 5 units. There are no other obstructions on the table surface. The
robot is free to roam around the surface of the table. Any movement that would result 
in the robot falling from the table must has been prevented.

Once the console app is launched you can issue the following commands:

PLACE X,Y,F  
MOVE  
LEFT  
RIGHT  
REPORT (will return current position)  

Example of commands being issued  

PLACE 1,2,EAST  
MOVE  
MOVE  
LEFT  
MOVE  
REPORT  
Output: 3,3,NORTH  
