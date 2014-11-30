JED
===

Internationalization Using JED



This is an early attempt implement internationalization using JED. 
JED shows promise with its close coupling with the traditional approach that helped developers to implement internationalization 
in other languages such as C++,Java, Ruby etc. 


JED being AMD compliant pushes itself as the best choice in the require js driven environment. 


HOW TO MAKE IT WORK?
====================

Download the repository or clone it. 

The XMLHTTPRequest fetches the language json file on the change of the language selected by the user. This requires the files to be placed 
on the server. Put the downloaded folder in the Server execution folder 

Or

Traverse to the root of the downloaded/cloned folder. Start the terminal and type 

` python -m SimpleHTTPServer `

, this will instantiate a local server on the default port (8000)
You need to have python installed to work this through.


Once the server is up. Go to the browser and hit `http://localhost:8000`.
This will push the index.html page up.
