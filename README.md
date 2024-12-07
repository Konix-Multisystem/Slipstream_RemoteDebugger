# Remote Debugger For Slipstream

Compile slipstream with the MEMORY_MAPPED_DEBUGGER=1 set in the CMakeLists.txt and then run slipstream. At that point you should be ok to run this debugger. It's very crude, just uses shared memory objects to pass text dumps between the emulator and the debugger. This uses winforms so is windows only, but the protocol is simple, so creating a version based on qt or imgui should not pose too much difficulty.
