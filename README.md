# StartupProgram

Most of my Java/Clojure programs I have been running with a simple bat script on Windows.

This little program provides a more professional method to start the program with a splash screen to display while the program is loading.

It is also designed for the build files of this startup program to be slotted into a project without having to configure the source code (and thus have a unique project build) for each use of this program.

# Features
1) A .PNG image will be shown as the splash screen. If multiple PNG images provided, then a random image will be selected each time to show. This allows for a rotating set of pictures in the splash screen.
2) Progress is shown by cycling dots (.  ..  ...) near the center of the image (color of dots set by configurable text file)
3) A cancel button to stop the bat script is also provided in case the user accidentally starts the program and wants to stop it. 


# Build the Project
Very standard...
1) Clone the project into a local directory
2) Build the project using either visual studio (.sln file included) or dotnet cli
3) Test that the program works. The examples included should show a message box and the splash screen will wait until the ok button is pressed to simulate the time that the program spent loading.


# Configure the Project
Once the project is built and working, you can replace/overwrite the following resources files to achieve a different splash screen and style.

  PNG pictures - Delete and replace with more PNG files. If you select one file, that will be the only file that is used as a splash screen, two or more files and a random file from the collection will be selected each time the launching program is run
  
  StyleConfig.txt file - currently only a couple options to configure the text color of the dots and the style of the cancel button. See the included file for the syntax and available options
  
  bat file - Only a single bat file should be provided in the build directory. Regardless of the filename, the program will look for a bat file in the directory and run it.

# Modify your Program to use this launcher.
The only change you need to make to your program is have it output "ProgramLaunchComplete" to the output of the bat file process. In most languages this is likely just a console output.

Once that specific text string is read in the output of the bat file script, the launcher program will end itself. Leaving the process started by the bat file untouched and running.

