cscript ExampleScript(OnlyCalledFromBatFile).vbs "Program is started. Notice the Splash screen. You can hit cancel and this script will end abruptly. Or press OK to have splash screen end and see the next message in this script."
echo ProgramLaunchComplete
cscript ExampleScript(OnlyCalledFromBatFile).vbs "Notice Startup Program has ended but this script is still running. This means any programs started with this script will continue to run. Press OK to end this example."