<<<<<<< HEAD
# Sahara Force India Math Parser - David Retief #

=======
>>>>>>> 03acde8a33f7889b7fbc7d5b351f46ddcab28409
As per the requirements by Mike Beeson.

## Summary ##

I used a TDD methodology throughout, writing tests to fail then write to code to make them pass followed by a refactor.
<<<<<<< HEAD
I have not refactored the code as much as I would usually here so the process I have followed is more obvious and I have also run a few more unit tests than is usually neccessary.
=======
I have not refactored the code as much as I would usually here so the process I have followed is more obvious.
I have also run a few more unit tests than I'd judge neccessary.
>>>>>>> 03acde8a33f7889b7fbc7d5b351f46ddcab28409

I first made a very simple draft GUI to get an idea of what controls would be required.
I then moved onto the backend, starting with simple expressions:
* Parse the string ints & operator.
* Calculate the result.
Once the simple expressions were working in tests, I worked on the GUI to make it work effectively with real user input.

Moving onto the complex expressions:
* Parsing larger strings into respective ints and operators.
* Determining the order of calculation for the expression.
* Getting the result using the methods written for simple expressions
* Restructuring the collections of ints and operators.
* looping the two previous steps for the final result. 

The main limitation of the parser is the exact syntax required in the input expression.
However, all the strings in the requirements followed an exact syntax so it will alert the user of an input error.

<<<<<<< HEAD
=======
## Manual ##

Enter any of the required expressions (or any math expression using single digit ints of the same complexity) into the text box.
Press enter or the calculate button.
>>>>>>> 03acde8a33f7889b7fbc7d5b351f46ddcab28409
