# Start up script for IronPythonConsole
import os
import sys
import rpyc

# Set properties for proper behaviour with PyDoc
os.environ['TERM'] = 'dumb'

# adds python27
#sys.path.append(r"c:\python27\lib\site-packages")

c = rpyc.classic.connect("localhost")
def specialAdd(a, b):
    print a + b + 1