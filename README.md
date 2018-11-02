# ASP_Net_DZ3

Create an ASP.Net MVC WebMoney Web Application<br/>

In the task you need at least 2 controllers:<br/>
- for managing accounts<br/>
- for role management<br/>

Each controller must have CRUD operations methods and corresponding View for each operation.<br/>

Classes (min. Set of properties):
User {<br/>
+ Id: int<br/>
+ FirstName: string<br/>
+ LastName: string<br/>
+ Login: string<br/>
+ Password: string<br/>
+ Email: string<br/>
+ Phone: string<br/>
+ Role: Role<br/>
}<br/>

Role {<br/>
+ Id: int<br/>
+ Name: string<br/>
}<br/>


Additional task:<br/>
Implement validation of the entered data before adding to the repository (eg. FirstName, Login, Password, etc. properties should not be empty.<br/>
Login and Password should contain the minimum number of characters, etc.)
