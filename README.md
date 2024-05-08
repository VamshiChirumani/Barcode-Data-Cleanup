This is a Desktop Application developed using .Net Core, Sql Server for database

This application can be used to clean the data scanned by bar-code scanners. There are 100 - 200 cards with each card having a cardId and a Identity tag ( Datamatrix, Barcode, QR etc..,). An OCR camera is used to detect the cardID and the scanner scans the data. All this data will be sent to database.

But due to errors we get some wrong card Id's in the data. It is hard to manually go through thousands of data and check if the card ID belongs to a particular data. 

This Application makes it possible. It checks if the corresponding card Id is assigned to the data. We need to give a reference data for the application so that it can identify card Id's and data.

User Manual For Data CleanUp

 ![image](https://github.com/VamshiChirumani/Barcode-Data-Cleanup/assets/92098361/4e6daaf5-fcfc-49c2-abfa-50c8b39bb0dc)

Check the connection string and press connect. 
After connecting to the database we can see a list of tests in that database.
 Select the testname and press load test
![image](https://github.com/VamshiChirumani/Barcode-Data-Cleanup/assets/92098361/9bd58362-5256-421e-953a-606c076852b7)

 
In the data if there are any errors we can see them here. 
After this press show raw.

 ![image](https://github.com/VamshiChirumani/Barcode-Data-Cleanup/assets/92098361/b2cc4ae5-9471-4803-8427-829640634ba4)

Press load expected and select the csv file that has the data, cardId, computer of all the cards in the test.

 ![image](https://github.com/VamshiChirumani/Barcode-Data-Cleanup/assets/92098361/34cf3b24-ddcc-4573-8320-b9439f8d3838)


After importing the file we can see a list of cards appear on the screen to the right. These are all the cards in the imported fie.
After importing them we need to check the order of the cards and check the box if in ascending order else leave unchecked.
Some of these might not be a part of our current test.
We need to remove them from the list if they are not part of the current test.
![image](https://github.com/VamshiChirumani/Barcode-Data-Cleanup/assets/92098361/761c2284-b9ec-495d-8c2a-510a76dcc540)
 

We might have few unrequired cards in the test. We change their status to null.
Here startID is the start Id of the valid test cards.
End ID is the end id of the valid test cards.
All the cards above and below these with the same testname _status is changed to 1.
 ![image](https://github.com/VamshiChirumani/Barcode-Data-Cleanup/assets/92098361/72492f49-b8da-444e-adfa-65d395bfe5fb)


After removing the cards from the list press the change ID’s button. 
This calls a function that checks the data in Data column and shows its expected card ID in Expected column.
Compare the ID’s in CardID and Expected columns.
 ![image](https://github.com/VamshiChirumani/Barcode-Data-Cleanup/assets/92098361/2913ce0b-ce44-4eff-bdd1-b10b506ecadd)

After comparing we need to update the changes to database.
 
![image](https://github.com/VamshiChirumani/Barcode-Data-Cleanup/assets/92098361/40ccd4da-04a0-481b-acbc-55f8352b93eb)

Press push to database button.
After this close the form and go to form 1.
In form 1 press the load test button again.

