# pcg-solar-system
Just makin spheres into planets and stars.


# Proceduraly Generation Solar System Project   
Hello.    
This is was my attempt at creating a proceduraly generated solarsystem. I was heavily inspired by Sebastian Lague's youtube series "Coding Adeventures"  where he worked through different parts of his procedually generated solar system to a different complexity. I have little to no experience creating sohpisticated projects on unity, so the learning curve was a bit difficult.
I also used a bit of Blender to create a rocket asset which was very difficult and turned out less than optimal because I have no idea how to use Blender. This project was fun to work throught and there are sections that I'll comeback to spice up to make it actually work as intended.   

## Starting Out
The first steps to this project was figuring out how to make spheres. Through this tutorial series I learned that using the default unity sphere would not really work for the project because of
how the verticies were generated on them. The  verticies would be constant as the size increases of the sphere. I wanted to be able to control the number of verticies used to generate the sphere.
![defaultSphere](https://github.com/8coolguy/pcg-solar-system/blob/master/Images/defaultSphere.png)   
My first attempt at this was trying to create an octasphere which was an object based on the octahedron. On each face of the octahedron you would put vertcies based on the resolution you wanted and create triangeles to create the mesh of 
the sphere. My attempt at this did not go well and at the time I did not have any idea how the meshes were formed. My problem here was probably that I connected the wrong verticeis for the triangle which created an absoulte abberation of an object. 
![octasphere](https://github.com/8coolguy/pcg-solar-system/blob/master/Images/octasphere.png)
My succesful attempt at creating a sphere was by following this tutorial where I used a cube and normalized all the verticies I generated on that cube. I was able to increase the resolution to the sphere which was nice, but I did not use that feature later on.
![newSphere](https://github.com/8coolguy/pcg-solar-system/blob/master/Images/newSphere.png)   

## Gravity
I next implented a gravity script which just used the well known Newton equation. I definetly had a rough dealing with this because it would try to calculate gravity on itself which would lead to errors. 
After I fixed the bugs, I realized how volatile gravity really was. The objects would have to be in the perfect place and velocity to get a orbit and if not the objects would try to fly each other or sling shot far away which 
was really intresting.
## 2D Noise   
My next steps was trying to create coherant noise to make terrains
