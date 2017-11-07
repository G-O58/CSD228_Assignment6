# CSD228_Assignment6

Course Work for Assignment 6

This assignment is about delegates, events, and lambda expressions.  Read Chapter 10 in the text and examine the Car event samples.  This assignment will start with the solution to either assignment 4 or assignment 5.

You are to make the following changes:

    Add a new class called ManagerEventArgs (similar to CarEventArgs in the text). Instead of a string, the ManagerEventArgs class defines two data members to hold references to the Manager and Employee passed to the AddReport method call.  Change the constructor to take these two arguments and initialize the data members.  Add a member virtual Message method to the ManagerEventArgs class that returns the following message string:
        <name of manager> has <MaxReports> reports, can not add report <name of report>
    Remove the TooManyReportsException you created in assignment 4, and replace it with a generic event using the EventHandler generic class using the ManagerEventArgs class you created in step 1.  Change the AddReport method to raise this event where you previously used the TooManyReportsException,  passing the manager and report from the AddReports method call to the ManagerEventArgs constructor.
    Change the static Main method to register three handlers for the TooManyReports immediately after the employee list is defined - one handler using the traditional delegate syntax (i.e., a static method in the Program class), one using the anonymous method delegate syntax, and one using a lambda expression.  All three events should call the Message virtual method that you created in step 1 and print out the message to the console.  Remove the catch block entirely, but keep the statements from the try block - just remove the 'try' keyword and the extra set of braces {} from the try block.

If done correctly, the same error message should be printed three times.  As always, follow the object-oriented programming principles we've discussed in class in all the code you write.
