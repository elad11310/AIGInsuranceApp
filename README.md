# AIGInsuranceApp



**Requirements:**    
.NET Framework 4.7.2
 
**Configurations:**  

1. Clone this project.  
2. There is a Resources folder in the project and there are 2 json files inside:  
    a) occupations.json - can dynamically add new profession/hobby  
    b) home_types - can chnage each home type price  
3. There is also .xlsx file example for calculating policies based on the file input     

 **Capabilities:**

 1. Calculate life insurance policy based on the following formula :  
    PolicyPrice = daysForPolicy * BasicPrice
   \+ daysForPolicy * ((Profession.Risk + Hobbies.Sum(o => o.Risk)) * BasicPrice)
   \+ daysForPolicy * GetPriceByAge(BasicPrice, Age);

 2. Calculate home insurance policy based on the following formula:  
    PolicyPrice = daysForPolicy * BasicPrice
  \+ daysForPolicy * (HomeDetails.PriceSquareMeter* SizeSquareMeter)
  \+ daysForPolicy * GetPriceByAge(BasicPrice, HomeAge);

 3. Calculate the above policies within .xlsx file (Please run the application as administrator)


 **API:**

 1. The cities are fetched using Google API - There is an API key inside Resources folder.
 2. The streets are fetched using another API which is only Hebrew result supportive - In the Streets combo box please type Hebrew letters, Then you will see dynamically results based on the text
   
    
