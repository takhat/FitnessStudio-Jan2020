# Fitness Studio App allows users to sign up for fitness classes and view activities and transactions. 

## Steps to run the application:
1. Download the Zipped folder from GitHub.
2. Extract all files.
3. Open the solution file in Visual Studio.
4. Delete "Migration" folder if there is any.
5. In "Package Manager Console", enter "Add-Migration SomeMigrationName" command followed by "Update-database" command.
6. Set "FitnessStudioApp" as the startup project and run the project. 
7. Follow the instructions in the Console to create a new account.

## Steps to Test Web UI:
1. Follow the above steps.
2. Set "FitnessStudioUI" as the startup project and run the project in IIS Express.
3. In the web view, use the "Register" link to log in using the same email address as in the above steps and set a password.
4. Use "Customer Account" link to sign up for fitness classes and view transactions.


