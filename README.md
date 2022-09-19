# EmporiumAssessment
Requirement Document 


Requirement Scope :
          The Retailer wants to provide reward points to their customers who purchased the product’s in their stores. Reward point are calculated against the each transaction made by the consumer in the store and based on the requirement if the total amt against the transaction is more the $50 1 reward point will be earned and if it the total amt is more than $100 will be earned 1 more reward point

Requirement Analysis :
             Reward points are calculated against each transaction made by the consumer in the store and we need the entities to be part of the requirement Consumer , Products,Purchase.
               Consumer is the key for their requirement against which we will be calculating the reward points and the products are more related to the items which are purchased which is an entity consisting of price and quantity and the purchase it is the transaction made by the customer entity which has items and on the transaction total the reward point are calculated.

Pre-Requisites.

1)	Visual Studio 2019
2)	SQL Server 2019
3)	.Net Core 3.1
4)	Entity Framework 3.1
5)	Swagger (https://swagger.io/tools/swagger-ui/ )


Functional Requirement :
                     In order to accomplish the above articulated need, the retailer reward points requires a community-wide data collection and management system that includes the following base functionality for each entity.

Consumer Management:

  The following functionality are  exposed using which consumer management will be accomplished for which consumer api’s are developed which has the following functionalities.

1)	Consumer Creation API : 
                   The API is used to create Consumer which accept Customer details as request which includes ( CosumerID , FirstName, LastName , Address1 , Address2 ,  ZipCode , PhoneNumber ) Fields  and return it will provide the status true if it is created  successfully and return false in case of failure..
2)	Consumer Deletion API : 
                  The API is used to delete Consumer which accepts ConsumerID as request Parameter and in return  true if it successfully deleted the Consumer Object from DB and  return false in case of failure.
3)	Consumer Modification API :
                  The API is used to modify Consumer  against ConsumerID , The API will accept the request parameters which includes ( CustomerID  FirstName, LastName , Address1 , Address2 ,  ZipCode , PhoneNumber ) Fields and in response the status is will be true if it is successful and false in case of failure.
4)	GetAllCosumers : The API used to pull All Consumer Details.
5)	GetConsumerDetailById : The API used to pull the Consumer details based on consumerId.
 


Product Management : 
      
The following functionality are  exposed using which product management will be accomplished for which Product api’s are developed which has the following functionalities.

1)	Product Created.
2)	Product Cancellation.
3)	Product Modification.
4)	GetAllProducts.
5)	GetAllProductById.

 
 

Purchase Management:

The following functionality are exposed using which Purchase Management will be accomplished for which the api’s are developed which has the following functionalities.

1)	Transaction Creation : which is used to create and complete one transaction.
2)	GetAllTranscationDetailByCustomerId: get Consumer transactions.
3)	GetAllTranscationDetailsByMonth: get All Consumer transactions by month.

 

Assumptions :

1)	Consumers reward points are calculated on the purchase which is completed.
2)	Consumers' reward points are not  earned if the purchase is in-complete.
3)	Reward points are earned and calculated on the total amount of the transaction made by the consumer.
4)	1 Reward point is earned for  each $50 and will be calculated against the total amount of the transaction. 
           Example : if the total amount is $160 he will earn 3 reward points.

Host/Deploy Application in IIS

1)	Install IIS in Windows 10 
2)	Install SQL Server Management studio 2019.
3)	Install the .Net Core Hosting Bundle
4)	Install Visual Studio 2019
5)	Open the Application provided in the Zip Folder.
6)	Publish and Deploy the application In IIS

DataBase Details 

Consumers Table:

 




Emporium Transactions Table:

 


Products Table:

 





Swagger Tool API Testing :

Consumer Creation :

Step1 : Click on the Add Customer Api
 
Step2: Click on “Try it out” button

 


Step3: provide the necessary details in the request body

 

Step 4: click on the execute button once provided the details .

 
Step5: The result will be displayed once it is successful in the response body.

 


Note : The sample steps to be followed for the rest of the api’s , each Api  will vary by request parameters and we need to provide the necessary data to execute the api.
Please find the Screenshots in README doc folder
