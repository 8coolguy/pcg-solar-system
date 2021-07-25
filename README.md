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
![gravityequation](https://github.com/8coolguy/pcg-solar-system/blob/master/Images/gravityequation.png)
## 2D Noise   
My next steps was trying to create coherant noise to make terrains on a 2d plane which I would try to move over to my newly created spheres.Coherent noise is a noise that creates random values that related to the values that are generated next to it. I used the unity Perlin function to do this. I did this by creating a texture that would give color to each pixel based on the genreated value from the perlin noise function. For each color, I gave it a height value in which I moved the vertex up to give it the hilly look. The results of different iteration looked promsing, so next I looked to make this terrain the faces of planets.    
![2dpcg](https://github.com/8coolguy/pcg-solar-system/blob/master/Images/2dpcg.png)   

## The Journey from 2d to 3d
Creating a planet with the terrain, I generated in the first part of the project actually took many different attempts till I found a workable solution. The difference between the 2D terrains and the 3D planet surface was that the 2d terrains used a non cyclic noise function which means that if I used those terrains for a planet the ends would not meet. My first idea of creating a 3d-like terrain was by using 3d perlin noise function. With this 3d perlin noise I created a Texture3d and gave color to every point based on the coherent noise and tried to develop land based off that. This did not work at all and generated nothing at all.  My next idea was to use this algorithm called the Marching Cubes Algorithm to generate a mass based on my noise function.   
### Marching Cubes
There should be many papers linked below better explaining this algorithm. Basically, the algorithm works through many cubes each with 8 verticies. Each verticie would have a value of 0 or 1 based on the 3d perlin function. Based on the configuration of the 8 bits(verticies), it would create triangles which would be used to create the mesh. My implementaion of the triangles did not work very well and led me to another dead end. My generations looked like they worked, but they were always on triangle from creating a complete mesh. This must have been a mistake on my end. Also, generating large chunks would always crash the application. Implementaions of this algorithm are very cool to see espiclally when a rendering distance is applied making it run smoother. 
![marching](https://github.com/8coolguy/pcg-solar-system/blob/master/Images/marching.png)

### New Noise Function
After many tries of finding a way to use Perlin Noise, I gave up on that and used a Noise script from a tutorial that would be able to deliver on what I was looking for. I was able to use this noise script and implemented some a shape and color settings to make it more cuztomizable. Examples of some planets I created are below. Some of the variables I had for the noise generation was strength and roughness. Persistance was used to show how much the noise amplified per layer.
![planet](https://github.com/8coolguy/pcg-solar-system/blob/master/Images/planet.png)      
somewhat earth like    
![planet1](https://github.com/8coolguy/pcg-solar-system/blob/master/Images/planet1.png)         
magma planet
![planet2](https://github.com/8coolguy/pcg-solar-system/blob/master/Images/planet2.png)       
turqouish ocean planet
![planet3](https://github.com/8coolguy/pcg-solar-system/blob/master/Images/planet3.png)   

## Finishing up
After the planet, I rushed to finsish the other parts. I created some quick ui elements. I created a script to give the planets a initial velocity that would lead to an orbit. This script had varying results because sometimes it did work, but it usually didn't. The reason it doesn't work is becuase there are other planets with mass that led to weird pushes and pulls between the project. I created a final rocket that had some cool effects. The final project would generate a solar system with a varying amount of planets that 
you can look around in with the rocket. The background would be starlight and you can travel to other newly generated solar systems by traveling away from the center of the solar system. The solar system would also generate a star at the center. Unfortunatley, I wasn't able to get the statr to glwo enough. I was able to reuse some code from a previous project for the camera and lighting.    
![solarsystem](https://github.com/8coolguy/pcg-solar-system/blob/master/Images/solarsystem.png)   
Star   
![star](https://github.com/8coolguy/pcg-solar-system/blob/master/Images/star.png)   

## Conclusion   
This project was a whole lot of fun I got to leanrn a whole lot about unity and c#. The noise functions and mesh generation is also very valuable in other visual based project like this. Hopefully, I will comback to this and add a whole lot more to this to make it even spicier and visualy appealing. This was created on Unity 20.2, so if any one would like to take a a gander you are welcome. Maybe you can figure out what went wrong with my marching cubes algorithm. I am trying to put a final version online, but here is also a cool gif.   
![pcg-gif](https://github.com/8coolguy/pcg-solar-system/blob/master/Images/pcg-gif.gif)    
ps: You can run it only if you clone the pcg folder, run a server with it, and open the webpage in it.
