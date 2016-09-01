# petsproject

CONSIDERATIONS:
=================
1) We may need to filter any other type of pet  (e.g Dog, Fish etc), therefore, I have given a variable in Default.aspx.cs i.e. PET_TYPE_FILTER. 

2) startProcessing() (in default.aspx.cs) function has been made parameterized for Unit Tests.

3) The "Unknown" gender type was missing in the requirements, but I have covered that as well in code

4) I have used Newtonsoft library to handle JSON in C# and System.Net.WebClient to load the JSON data from URL (not HttpRequest)

5) The entry point in the logic is Page_Load event.

6) The flow of program is that it:

a. Loads the JSON data

b. Seggregates the data according to gender

c. Then for each gender, it filters the pet type and returns a sorted string list


Known Issues
==============
1) I did not write the unit tests (as it was not written in the test requirements).

2) If you keep the PET_TYPE_FILTER variable empty, it will Not print anything. This is not a bug, but just to mention that please do Not expect it to show ALL records.
